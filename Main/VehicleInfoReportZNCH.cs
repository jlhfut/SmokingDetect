using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json.Linq;
using Wayee.Services;
using System.Collections.Generic;
using wayeal.os.exhaust.ViewModel;
using Wayeal.Services.Configs;

namespace wayeal.os.exhaust
{
    public partial class VehicleInfoReportZNCH : DevExpress.XtraReports.UI.XtraReport
    {
        const string _quality = "合格";
        const string _unQuality = "不合格";
        const string _Invalid = "无效";
        public VehicleInfoReportZNCH()
        {
            InitializeComponent();
        }
        public VehicleInfoReportZNCH(object o)
        {
            InitializeComponent();
            //获取限值信息
            CarLimitingInfo limitingInfo= InitLimitValueFromDataPath(o);
            //绑定数据
            InitializeBindings(o, limitingInfo);
            InitJudgeResult();
        }
        private CarLimitingInfo InitLimitValueFromDataPath(object o)
        {
            if (o is JObject)
            {
                JObject jo = (o as JObject);
                string dataPath = jo.Value<string>("DataPath");
                if (dataPath != null) ResultDataViewModel.VM.Execute(new List<Object>
                {
                    ResultDataViewModel.ExecuteCommand.ec_QueryCarLimitingInfo,
                    dataPath
                });
                if (ResultDataViewModel.VM.QueryCarLimitingInfoEntities != null)
                {
                    return ResultDataViewModel.VM.QueryCarLimitingInfoEntities;
                }
            }
            return null;
        }
        /// <summary>
        /// 限值信息填充
        /// </summary>
        /// <param name="carType">0：柴油车 1：汽油车</param>
        private void InitLimitInfo(object LimitInfo)
        {
            if (LimitInfo == null) return;
            if (LimitInfo is DieselCarInfo)
            {
                //柴油
                DieselCarInfo dt = LimitInfo as DieselCarInfo;
                xrtNOLimitingValue.Text = dt.NOLimiting.ToString();
                xrtOpSmokeLimitingValue.Text = dt.OpSmokeLimiting.ToString();
                xrtBlacknessLimitingValue.Tag =dt.BlacknessLimiting.ToString();
                xrtBlacknessLimitingValue.Text =ConvertIntToRoma(dt.BlacknessLimiting.ToString());
                xrTableCell24.Text = "注:引用《中华人民共和国国家环境保护标准HJ 845—2017》";
            }
            else if (LimitInfo is GasolineCarInfo)
            {
                //汽油
                GasolineCarInfo dt = LimitInfo as GasolineCarInfo;
                xrtNOLimitingValue.Text = dt.NOLimiting.ToString();
                xrtOpSmokeLimitingValue.Text = dt.HCLimiting.ToString();
                xrtBlacknessLimitingValue.Tag = dt.COLimiting.ToString();
                xrtBlacknessLimitingValue.Text = dt.COLimiting.ToString();
                xrTableCell24.Text = "注：引用《汽车污染物排放限值及测量方法（遥感检测法）(二次征求意见稿）》";
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="o">尾气信息</param>
       /// <param name="StationInfo">站点信息</param>
       /// <param name="LimitInfo">限值信息</param>
        private void InitializeBindings(object o,CarLimitingInfo limitInfo)
        {
            try
            {
                if (o is JObject)
                {
                    JObject jo = (o as JObject);
                    //标题栏
                    xlReportNumValue.Text = jo.Value<string>("UniqueKey");
                    xlReportTimeValue.Text = jo.Value<string>("dt");
                    xlReportUserValue.Text = frmMain.UserName;

                    //E1_1-4
                    xrtRelativeHumidityValue.Text = jo.Value<double>("Humidity").ToString("f2");
                    xrtTemperatureValue.Text = jo.Value<double>("Temperature").ToString("f2");
                    xrtWindSpeedValue.Text = jo.Value<double>("WindSpeed").ToString("f2");
                    xrtBarometricPressureValue.Text = jo.Value<double>("Pressure").ToString("f2");

                    //E1_5-8
                    xrtSlopeValue.Text = jo.Value<string>("Slope");
                    xrtTestSiteValue.Text = jo.Value<string>("Station");
                    xrtLongitudeValue.Text = jo.Value<string>("Longitude");
                    xrtLatitudeValue.Text = jo.Value<string>("Latitude");

                    //E3
                    xrtLicenseNumberValue.Text = jo.Value<string>("CarNumber");
                    string s = jo.Value<string>("CarNumberColor");
                    if (!String.IsNullOrEmpty(s))  xrtCarColorValue.Text= ConvertIntToColor(Convert.ToInt32(s));

                    //picture
                    xrpCarPicture1.ImageUrl = jo.Value<string>("PicFarPath");
                    xrPictureBox2.ImageUrl = jo.Value<string>("PicNearPath");

                    //
                    xrtResultValue.Text =ConvertIntToResult( jo.Value<string>("Result").Trim());

                    //    string[] str =jo.Value<string>("PicFarPath").Split('\\');
                    //     xrtPictureSeriesNoValue.Text = str[str.Length - 1].Split('.')[0];
                    xrtPictureSeriesNoValue.Text = jo.Value<string>("UniqueKey");
                    string carType = jo.Value<string>("CarType");
                    if (carType != null)
                    {
                        if (carType.Contains("B"))
                        {
                            //柴油车
                            xtcNOTitle.Text = "NO(ppm)";
                            xtcTitle2.Text = "不透光度(%)";
                            xtcTitle3.Text = "林格曼黑度(级)";
                            xrtNOTsetValue.Text =Convert.ToSingle(jo.Value<string>("NO")).ToString("f2");
                            xrtOpSmokeTestValue.Text = Convert.ToSingle(jo.Value<string>("OpSmoke")).ToString("f2") ;
                            xrtBlacknessTestValue.Tag = jo.Value<string>("Blackness");
                            xrtBlacknessTestValue.Text =ConvertIntToRoma( jo.Value<string>("Blackness"));
                            InitLimitInfo(limitInfo.DieselCarLimitInfo);
                            xtcTitle2.Font = new Font("宋体",12);
                        }
                        else
                        {
                            //汽油车
                            xtcNOTitle.Text = "NO(ppm)";
                            xtcTitle2.Text = "HC(ppm)";
                            xtcTitle3.Text = "CO(%)";
                            xrtNOTsetValue.Text = Convert.ToSingle(jo.Value<string>("NO")).ToString("f2");
                            xrtOpSmokeTestValue.Text = Convert.ToSingle(jo.Value<string>("HC")).ToString("f2");
                            xrtBlacknessTestValue.Tag = Convert.ToSingle(jo.Value<string>("CO")).ToString("f2");
                            xrtBlacknessTestValue.Text = Convert.ToSingle(jo.Value<string>("CO")).ToString("f2");
                            InitLimitInfo(limitInfo.GasolimitCarInfo);
                            xtcTitle2.Font = new Font("Tahoma", 10);
                        }
                    }
                    else
                    {
                        xrtNOTsetValue.Text = jo.Value<string>("NO");
                        xrtOpSmokeTestValue.Text = jo.Value<string>("OpSmoke");
                        xrtBlacknessTestValue.Text =ConvertIntToRoma( jo.Value<string>("Blackness"));
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        private void InitJudgeResult()
        {
            try
            {
                if (Convert.ToDecimal(xrtNOTsetValue.Text) > Convert.ToDecimal(xrtNOLimitingValue.Text))
                {
                    xrtNOResultValue.Text = _unQuality;
                }
                else
                    xrtNOResultValue.Text = _quality;

                if (Convert.ToDecimal(xrtOpSmokeTestValue.Text) > Convert.ToDecimal(xrtOpSmokeLimitingValue.Text))
                {
                    xrtOpSmokeResultValue.Text = _unQuality ;
                }
                else
                    xrtOpSmokeResultValue.Text = _quality;

                if (Convert.ToDecimal(xrtBlacknessTestValue.Tag) > Convert.ToDecimal(xrtBlacknessLimitingValue.Tag))
                {
                    xrtBlacknessResultValue.Text = _unQuality;
                }
                else
                    xrtBlacknessResultValue.Text = _quality ;
                
            }
            catch (Exception ex)
            {
                xrtResultValue.Text = _Invalid;
                ErrorLog.Error(ex.ToString());
            }
        }
        string ConvertIntToColor(int i)
        {
            try
            {
                switch (i)
                {
                    case 0:
                        return "蓝色";
                    case 1:
                        return "黄色";
                    case 2:
                        return "白色";
                    case 3:
                        return "黑色";
                    case 4:
                        return "绿色";
                    case 5:
                        return "民航黑";
                    default:
                        return "其他颜色";
                }
            }
            catch
            {
            }
            return "";
        }
        string ConvertIntToRoma(string e)
        {
            try
            {
                switch (e)
                {
                    case "1":
                        return "Ⅰ";
                    case "2":
                        return "Ⅱ";
                    case "3":
                        return "Ⅲ";
                    case "4":
                        return "Ⅳ";
                    case "5":
                        return "Ⅴ";
                    case "6":
                        return "Ⅵ";
                    default:
                        return e;
                }
            }
            catch { }
            return "";
        }
        string ConvertIntToResult(string i)
        {
            try
            {
                switch (i)
                {
                    case "1":
                        return _quality;
                    case "2":
                        return _Invalid;
                    case "0":
                        return _unQuality;
                    case "-1":
                        return _Invalid;
                }
            }
            catch { }
            return "";
        }
    }
}
