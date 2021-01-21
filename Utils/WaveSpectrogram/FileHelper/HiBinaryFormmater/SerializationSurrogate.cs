using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.IO;

namespace ILSerialization.Surrogates
{
    public interface IHiPerfSerializationSurrogate
    {
        void Serialize(BinaryWriter writer, object graph);
        object DeSerialize(BinaryReader reader);
        int  GetTypeHandle();
        void SetTypeHandle(int h);
    }

    sealed public class DefaultSurrogate : IHiPerfSerializationSurrogate
    {
        private int _typeHandle = -1;

        public int GetTypeHandle()
        {
            return _typeHandle;
        }

        public void SetTypeHandle(int h)
        {
            _typeHandle = h;
        }

        public void Serialize(BinaryWriter writer, object graph)
        {
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(writer.BaseStream, graph);
        }

        public object DeSerialize(BinaryReader reader)
        {
            BinaryFormatter b = new BinaryFormatter();
            return b.Deserialize(reader.BaseStream);
        }

    }


}
