using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.permission
{
    public class uv_Permission:PermissionLoader<PermissionStringId>
    {
        protected override void PopulatePermissionTable()
        {
        //    //不可见（弃用或不用模块）
        //    PermissionObject povNotVisi = new PermissionObject(-1, PermissionModes.pm_Visible);
        //    //超级管理员WAYEE
        //    PermissionObject povSuper = new PermissionObject(0, PermissionModes.pm_Visible);
        //    //普通管理员
        //    PermissionObject pov = new PermissionObject(1, PermissionModes.pm_Visible);
        //    PermissionObject povEnable = new PermissionObject(1, PermissionModes.pm_Enabled);
        //    //用户（操作员）
        //    PermissionObject povYH = new PermissionObject(2, PermissionModes.pm_Visible);
        //    //游客
        //    PermissionObject povYK = new PermissionObject(3, PermissionModes.pm_Visible);
        //    AddString("menuHome", povYK);
        //    AddString("bbiRealtimeMonitoring", povYK);

        //    AddString("bbiCalibration", povYH);
        //    AddString("bbiDebugging", povYH);
        //    AddString("menuData", povYH);
        //    AddString("bbiExhaustData", povYH);
        //    AddString("bbiAirQuality", povYH);
        //    AddString("menuStation", povYH);
        //    AddString("menuHelp", povYH);

        //    AddString("menuSystem", pov );
        //    AddString("sbNonlinearCorrection", pov);
        //    AddString("tbSmokeSignalControl", pov);
        //    AddString("tbSystemControl", pov);
        //    AddString("lcIntensityFullRange", povEnable);
        //    AddString("teIntensityFullRange", povEnable);
        //    AddString("lcIntensityAlarmRange", povEnable);
        //    AddString("teIntensityAlarmRangeStart", povEnable);
        //    AddString("teIntensityAlarmRangeEnd", povEnable);
        //    AddString("lcIntensityRange", povEnable);
        //    AddString("teIntensityRangeStart", povEnable);
        //    AddString("teIntensityRangeEnd", povEnable);
        //    AddString("lcFilteringTimeConstant", povEnable);
        //    AddString("teFilteringTimeConstant", povEnable);
        //    AddString("lcSamplingPeriod", povEnable);
        //    AddString("teSamplingPeriod", povEnable);
        //    AddString("teTriggerDelay", povEnable);
        //    AddString("lcTriggerDelay", povEnable);
        //    AddString("teIntensityFullRangeOfInfrared", povEnable);
        //    AddString("teIntensityAlarmRangeStartOfInfrared", povEnable);
        //    AddString("teIntensityAlarmRangeEndOfInfrared", povEnable);
        //    AddString("lcLightThreshold", povEnable);
        //    AddString("teLightThresholdOfInfrared", povEnable);
        //    AddString("lcDistance1To2", povEnable);
        //    AddString("lcDistance1To3", povEnable);
        ////    AddString("lcLightThreshold", pov);
        //    AddString("teDistance1To2", povEnable);
        //    AddString("teDistance1To3", povEnable);
        //    AddString("teLightThreshold", povEnable);
        //    AddString("lcIntensity1", povEnable);
        //    AddString("lcIntensity2", povEnable);
        //    AddString("lcIntensity3", povEnable);
        //    AddString("lcTime1To2", povEnable);
        //    AddString("lcTime1To3", povEnable);
        //    AddString("lcIntensity1Value", povEnable);
        //    AddString("lcIntensity2Value", povEnable);
        //    AddString("lcIntensity3Value", povEnable);
        //    AddString("lcTime1To2Value", povEnable);
        //    AddString("lcTime1To3Value", povEnable);

        //    AddString("lcUsedPm", pov);
        //    AddString("ceUsedPm", pov);
        //    AddString("gcOperation1", pov);

        //    AddString("bbiRunningLog", povNotVisi);

        //    AddString("riSpectrum", povEnable);
        //    AddString("riConcentration", povEnable);
        //    AddString("riDebug", povEnable);
        //    //点修正仅超级管理员可见
        //    AddString("sbPointCorrect", povSuper);
        //    //base.PopulatePermissionTable();
        }
    }

    #region enum PermissionStringId
    public enum PermissionStringId
    {
        None,
    }
    #endregion
}
