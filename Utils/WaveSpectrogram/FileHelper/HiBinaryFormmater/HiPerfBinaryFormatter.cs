using System;
using System.Collections.Generic ;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ILSerialization.Surrogates;

namespace ILSerialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMember : Attribute
    {
    } 

    [AttributeUsage(AttributeTargets.Assembly)]
    public class HiPerfTraceAssembly : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class HiPerfSerializable : Attribute
    {
    }
}


namespace ILSerialization.Formatters
{
    public sealed class HiPerfBinaryFormatter
    {
        private static Dictionary<string, Type> _eventTypeToNameMap;
        private static Dictionary<string, IHiPerfSerializationSurrogate> _surrogateTypeMap;
        private static int _intHandleCounter = 0;
        private BinaryWriter _binaryWriter;
        private static DefaultSurrogate _defaultSurrogate;

        public static Dictionary<string, Type> EventTypeToNameMap
        {
            get { return HiPerfBinaryFormatter._eventTypeToNameMap; }
        }

        public HiPerfBinaryFormatter()
        {
            _binaryWriter = null;
        }

        static HiPerfBinaryFormatter()
        {
            if (_defaultSurrogate == null)
                _defaultSurrogate = new DefaultSurrogate();

            if (_surrogateTypeMap == null)
                _surrogateTypeMap = new Dictionary<string, IHiPerfSerializationSurrogate>();

            if (_eventTypeToNameMap == null)
                _eventTypeToNameMap = new Dictionary<string, Type>();

            FindAndRegisterDecoratedAssembliesAndTypes();
        }

        private static void FindAndRegisterDecoratedAssembliesAndTypes()
        {
            try
            {
                AssemblyName[] aa = Assembly.GetEntryAssembly().GetReferencedAssemblies();
                foreach (AssemblyName a in aa)
                {
                    AppDomain.CurrentDomain.Load(a);
                }

                Assembly[] asmbs = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in asmbs)
                {
                    if (IsTypeDecoratedByAttribute<HiPerfTraceAssembly>(a.GetCustomAttributes(false)))
                    {
                        foreach (Type t in a.GetTypes())
                        {
                            if (IsTypeDecoratedByAttribute<HiPerfSerializable>(t.GetCustomAttributes(true)))
                            {
                                GenerateSurrogateForEvent(t);
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private static bool IsTypeDecoratedByAttribute<ATTRIBUTE_TYPE>(object[] t)
        {
            foreach (Attribute attr in t)
            {
                if (attr is ATTRIBUTE_TYPE)
                {
                    ATTRIBUTE_TYPE a = (ATTRIBUTE_TYPE)Convert.ChangeType(attr, typeof(ATTRIBUTE_TYPE));
                    return true;
                }
            }
            return false;
        }

        public static IHiPerfSerializationSurrogate GenerateSurrogateForEvent(Type eventType)
        {
            IHiPerfSerializationSurrogate surrogateInstance = _defaultSurrogate;
            Type surrType = null;

            if (!eventType.IsAbstract && !HasSerializableAttribute(eventType.GetCustomAttributes(true)))
            {
                surrType = IntermediateLanguageSurrogateBuilder.GenerateSerializationSurrogateType<IHiPerfSerializationSurrogate>(eventType);
            }

            if (surrType != null)
            {
                surrogateInstance = (IHiPerfSerializationSurrogate)Activator.CreateInstance(surrType);
            }
            surrogateInstance.SetTypeHandle(_intHandleCounter);

            if (!_surrogateTypeMap.ContainsKey(eventType.Name))
                _surrogateTypeMap.Add(eventType.Name, surrogateInstance);

            if (!_eventTypeToNameMap.ContainsKey(eventType.FullName))
                _eventTypeToNameMap.Add(eventType.FullName, eventType);

            return surrogateInstance;
        }

        private IHiPerfSerializationSurrogate GetSurrogateFromType(Type eventType)
        {
            IHiPerfSerializationSurrogate sr = null;

            string n = eventType.Name;

            if (_surrogateTypeMap.ContainsKey(n))
                sr = (IHiPerfSerializationSurrogate)_surrogateTypeMap[n];
            else
                sr = _defaultSurrogate;// GenerateSurrogateForEvent(eventType);

            return sr;
        }

        public object Deserialize(Stream serializationStream)
        {
            object o = null;
            using (BinaryReader binaryReader = new BinaryReader(serializationStream))
            {
                Type t = GetEventTypeFromStream(binaryReader);
                o = GetSurrogateFromType(t).DeSerialize(binaryReader);
            }
            return o;
        }

        private Type GetEventTypeFromStream(BinaryReader br)
        {
            Type evntType = null;
            String className = br.ReadString();
            evntType = _eventTypeToNameMap[className];
            return evntType;
        }

        public static Type GenerateCimBasedEventType(string serverName, string Namespace, String className)
        {
            object o = new object();
            Type evntType = null;
            lock (o)
            {
                if (!_eventTypeToNameMap.ContainsKey(className))
                {
                    evntType = IntermediateLanguageClrTypeBuilder.GenerateClrTypeFromCimType(serverName, Namespace, className);
                    GenerateSurrogateForEvent(evntType);
                }
                else
                    evntType = _eventTypeToNameMap[className];
            }
            return evntType;
        }

        static private bool HasSerializableAttribute(object[] t)
        {
            bool serAttrFound = true;

            foreach (Attribute attr in t)
            {
                if (attr is SerializableAttribute)
                {
                    serAttrFound = true;
                }

                if (attr is HiPerfSerializable)
                {
                    serAttrFound = false;
                }
            }


            return serAttrFound;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            Type eventType = graph.GetType();

            IHiPerfSerializationSurrogate surrogate = GetSurrogateFromType(eventType);
            _binaryWriter = new BinaryWriter(serializationStream);
            _binaryWriter.Write(eventType.FullName);
            surrogate.Serialize(_binaryWriter, graph);

        }
    }
}
