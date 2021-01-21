
namespace wayeal.language
{
    public class ValidErrorTextCNLocalizer :ValidErrorTextLocalizer
    {
        public override string Language { get { return "中文"; } }

        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
            R1To10 = "请输入1-10之间的数值";
            R0To100 = "请输入0-100之间的数值";
            R1To100 = "请输入1-100之间的数值";
            R1To10000 = "请输入1-10000之间的数值";
            R0To100000 = "请输入0-100000之间的数值";
            R0To99999d99 = "请输入0.00-99999.99之间的数值";
            Rn90d00To90d00 = "请输入-90.00到90.00之间的数值";

            R0To100d00 = "请输入0到100之间的数值";
           R0To99d99 = "请输入0到99.99之间的数值";
            R0To2000 = "请输入0到2000之间的数值";
            R1To1000 = "请输入1到1000之间的数值";
            R1To65000 = "请输入1到65000之间的数值";
            R0d01To600000 = "请输入0.01到600000之间的数值";
            R0To2055 = "请输入0到2055之间的数值";
            R1To500 = "请输入1到500之间的数值";
            R0To255 = "请输入0到255之间的数值";
            R1To128 = "请输入1到128之间的数值";
            R10d00To100d00 = "请输入10.00到100.00之间的数值";
            R0d10To50d00 = "请输入0.10到50.00之间的数值";
            Rn32768To32767 = "请输入-32768到32767之间的数值";
            R0To7 = "请输入0到7之间的数值";
            Rn10d00To50d00 = "请输入-10.00到50.00之间的数值";
            R0To32767 = "请输入0到32767之间的数值";
            R0To1d00 = "请输入0到1.00之间的数值";
            R150d00To300d00 = "请输入150.00到300.00之间的数值";
            R300d00To600d00 = "请输入300.00到600.00之间的数值";
            R0To4095 = "请输入0到4095之间的数值";
            R1To60 = "请输入1到60之间的数值";
            
            R0To65535 = "请输入0到65535之间的数值";
            RazAZ09_0618 = "请输入数字字符或下划线，长度在6到18位之间";
            UserNameLimit = "请输入数字字符或下划线，长度在1到20位之间";
            Longitude = "请输入经度,负数代表西经，例:-160.26454";
            Latitude = "请输入纬度，负数代表南纬，例:30.62651";
            StationName = "请输入汉字、数字、下划线或字母，长度在1-20位之间";
            DoubleTypeLimit = "请输入整数部分不超过4位，小数部分不超过5位的数字";
            BlacknessTypeLimit = "请输入0-6中任意数字";
            COTypeLimit = "请输入0.0-100.0之间的数值";

          UserOperate0 = "重置密码";
            UserOperate1 = "修改用户";
            UserOperate2 = "删除用户";
            base.PopulateStringTable();
        }
        #endregion
    }
}

