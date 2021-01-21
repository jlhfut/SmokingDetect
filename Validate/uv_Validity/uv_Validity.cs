﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.language;

namespace wayeal.validate
{
    class uv_ValidityTable : ValidErrorTextLocalizer
    {
        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
            R1To10 = @"^[1-9]$";
            R0To100 = @"^[1-9][0-9]|[1][0][0]|[0-9]$";
            R1To100 = @"^[1-9][0-9]|[1][0][0]|[1-9]$";
            R1To10000 = @"^[1-9](\d{1,3})?|[1][0][0][0][0]$";
            R0To100000 = @"^[1-9](\d{1,4})?|[1][0][0][0][0][0]|[0]$";
            R0To99999d99 = @"^([1-9](\d{1,4})?|[0-9])(\.\d{1,2})?$";
            Rn90d00To90d00 = @"^(-)?(([0-9]|[1-8][0-9])(\.\d{1,2})?)|([9][0])|(-90)$";
            R0To65535 = @"^[0-9]|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5]$";
            RazAZ09_0618 = @"^\w{6,18}$";
            UserNameLimit = @"^\w{1,20}$";
            Longitude = @"^[-]?(([0-9]|[1-9][0-9]|1[0-7][0-9])(\.\d{1,5})?|180|([0-9]|[1-9][0-9]|1[0-7][0-9]))$";
            Latitude = @"^[-]?(([0-9]|[1-8][0-9])(\.\d{1,5})?|([0-9]|[1-8][0-9]|90))$";
            StationName = @"^[\u4E00-\u9FA5A-Za-z0-9_]{1,20}$";
            DoubleTypeLimit = @"^(0|[1-9][0-9]{0,3})(\.\d{1,5})?$";
            BlacknessTypeLimit = @"^[0-6]|[Ⅰ]|[Ⅲ]|[Ⅱ]|[Ⅵ]|[Ⅳ]|[Ⅴ]$";
            COTypeLimit = @"^([1-9][0-9]|[0-9])(\.\d{1})?|([1-9][0-9]|[1][0][0]|[0-9])$";
            
            R0To100d00 = @"^(([0-9]|[1-9][0-9])(\.\d{1,2})?)|100$";
            R0To99d99 = @"^([0-9]|[1-9][0-9])(\.\d{1,2})?$";
            R0To2000 = @"^[0-9]|[1-9][0-9]|[1-9][0-9][0-9]|1[0-9][0-9][0-9]|2000$";
            R1To1000 = @"^[1-9]|[1-9][0-9]{1,2}|1000$";
            R1To65000 = @"^[1-9][0-9]{0,3}|[1-5][0-9][0-9][0-9][0-9]|[6][0-4][0-9][0-9][0-9]|65000$";
            R0d01To600000 = @"^(0\.0[1-9])|(0\.[1-9][0-9]?)|([1-9][0-9]{0,4}(\.\d{1,2})?)|([1-5][0-9]{5}(\.\d{1,2})?)|600000$";
            R0To2055 = @"^[0-9]|[1-9][0-9]{1,2}|1[0-9]{3}|20[0-4][0-9]|205[0-5]$";
            R1To500 = @"^[1-9]|[1-9][0-9]|[1-4][0-9][0-9]|500$";
            R0To255 = @"^[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]$";
            R1To128 = @"^[1-9]|[1-9][0-9]|1[0-1][0-9]|12[0-8]$";
            R10d00To100d00 = @"^[1-9][0-9](\.\d{1,2})?|100(\.\d{1,2})?$";
            R0d10To50d00 = @"^(0\.[1-9][0-9]?)|([1-9]|[1-4][0-9])(\.\d{1,2})?|50(\.0{1,2})?$";
            Rn32768To32767 = @"^(-)?(\d|[1-2]\d{4}|[1-9]\d|3[0-1]\d{3}|[1-9]\d{2}|32[0-6]\d{2}|[1-9]\d{3}|327[0-5]\d|3276[0-7])|-32768$";
            R0To7 = @"^[0-7]$";
            Rn10d00To50d00 = @"^([1-4][0-9](\.\d{1,2})?)|(50(\.[0]{1,2})?)|(-)?[0-9](\.\d{1,2})?|-10$"; ;
            R0To32767 = @"^\d|[1-2]\d{4}|[1-9]\d|3[0-1]\d{3}|[1-9]\d{2}|32[0-6]\d{2}|[1-9]\d{3}|327[0-5]\d|3276[0-7]$";
            R0To1d00 = @"^0(\.\d{1,2})?|1(\.0{1,2})?$";
            R150d00To300d00 = @"^((1[5-9][0-9]|2[0-9][0-9]|[3][0][0])(\.\d{1,2})?)$";
            R300d00To600d00 = @"^((3[0-9][0-9]|[4-5][0-9][0-9]|[6][0][0])(\.\d{1,2})?)$";
            R0To4095 = @"^(\d|[1-3]\d{3}|[1-9]\d|[1-9]\d{2}|40[0-8]\d|409[0-5])$";
            R1To60 = @"^([1-9]|[1-5]\d|60)$";

            AddString("Regex", "");
            base.PopulateStringTable();
        }
        #endregion
    }

    #region enum ValidStringId
    public enum ValidStringId
    {
        None,
    }
    #endregion

    public class uv_Validity : ValidateLoader<ValidStringId>
    {
        public uv_Validity()
        {
            uv_ValidityTable table = new uv_ValidityTable();
            SortedList<string, string> list = table.StringTable;
            if (list != null)
            {
                foreach (string key in list.Keys)
                {
                    AddString(key, list[key]);
                }
            }
        }       
    }
}