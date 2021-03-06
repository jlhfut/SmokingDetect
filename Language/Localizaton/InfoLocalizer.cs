﻿
namespace wayeal.language
{
    public class InfoLocalizer : ResourecLocalizer<InfoId>
    {
        public override string Language { get { return "English"; } }

        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
            AddString(InfoId.None, "");
            AddString(InfoId.VersionText, "Version: V1.0");
            AddString(InfoId.ProgressPanelCaption, "Please wait");
            AddString(InfoId.ProgressPanelDescription, "Loading...");

            AddString(InfoId.CorrectItemIsEmpty, "Please select correction item.");
            AddString(InfoId.CalibrateCompleted, "Calibration completed.");
            AddString(InfoId.CalibrateFail, "Calibration failure.");
            AddString(InfoId.SaveCompleted, "Completion of saving parameters.");
            AddString(InfoId.SaveFail, "Failed to save parameters.");

            AddString(InfoId.OpacitySmaking, "Opacity smaking");
            AddString(InfoId.YellowCar, "The car of yellow license");
            AddString(InfoId.CreateReport, "Sure to create report:");
            AddString(InfoId.Report , "Create Report");
            AddString(InfoId.SureDelete, "Sure to delete?");
            AddString(InfoId.SelectNone, "Select none");
            AddString(InfoId.All, "All");
            AddString(InfoId.Qualified, "Qualified");
            AddString(InfoId.Disqualified, "Disqualified");
            AddString(InfoId.Invalid, "Invalid");
            AddString(InfoId.valid, "Valid");
            AddString(InfoId.ResetPassword, "Sure to reset password?");
            AddString(InfoId.Used, "Used");
            AddString(InfoId.Unused, "Unused");
            AddString(InfoId.NewPassword, "Enter the new password twice inconsistent!");

            AddString(InfoId.SaveChange, "Sure to save changes?");
            AddString(InfoId.ChangeSuccess, "Change successfully");
            AddString(InfoId.ChangeFail, "Change Faild");
            AddString(InfoId.LoginFail, "Username or password error");
            AddString(InfoId.InputNotNull, "Please enter a value at last");
            AddString(InfoId.AccountDisabled, "Account is disabled");
            AddString(InfoId.LoginFirst, "Please login firstly");

            AddString(InfoId.FirstInfo, "This is the first information already");
            AddString(InfoId.LastInfo, "This is the last information already");
            AddString(InfoId.OpearteSuccess, "Operation is successful");
            AddString(InfoId.OperateFail, "Operation is failed");
            AddString(InfoId.UserNameExist, "This name already exists");
            AddString(InfoId.UserNameNotAllowed, "The username is not allowed");
            AddString(InfoId.APPExit, "Exit");
            //颜色
            AddString(InfoId.Blue, "Blue");
            AddString(InfoId.Yellow, "Yellow");
            AddString(InfoId.White, "White");
            AddString(InfoId.Black, "Black");
            AddString(InfoId.Green, "Green");
            AddString(InfoId.Blackness, "Blackness");
            AddString(InfoId.OtherColor, "OtherColor");
            AddString(InfoId.Silvery, "Silvery");
            AddString(InfoId.Gray, "Gray");
            AddString(InfoId.Red, "Red");
            AddString(InfoId.DarkBlue, "DarkBlue");
            AddString(InfoId.Brown, "Brown");
            AddString(InfoId.Pink, "Pink");
            AddString(InfoId.Violet, "Violet");
            AddString(InfoId.DarkGrey, "DarkGrey");
            AddString(InfoId.Cyan, "Cyan");
            AddString(InfoId.UnfindColor, "UnKnow");
            //号牌类型
            AddString(InfoId.VCA_STANDARD92_PLATE, "STANDARD92");
            AddString(InfoId.VCA_STANDARD02_PLATE, "STANDARD02");
            AddString(InfoId.VCA_WJPOLICE_PLATE, "WJPOLICE");
            AddString(InfoId.VCA_JINGCHE_PLATE, "JINGCHE");
            AddString(InfoId.STANDARD92_BACK_PLATE, "STANDARD92_BACK");
            AddString(InfoId.VCA_SHIGUAN_PLATE, "SHIGUAN");
            AddString(InfoId.VCA_NONGYONG_PLATE, "NONGYONG");
            AddString(InfoId.VCA_MOTO_PLATE, "MOTO");
            AddString(InfoId.NEW_ENERGY_PLATE, "NEW ENERGY");
            //燃油类型
            AddString(InfoId.DieselCar, "DieselCar");
            AddString(InfoId.GasolineCar, "GasolineCar");
            AddString(InfoId.OtherFuelCar, "OtherFuelCar");
            //车辆类型
            AddString(InfoId.VTR_RESULT_OTHER, "OTHER");
            AddString(InfoId.VTR_RESULT_BUS, "BUS");
            AddString(InfoId.VTR_RESULT_TRUCK, "TRUCK");
            AddString(InfoId.VTR_RESULT_CAR, "CAR");
            AddString(InfoId.VTR_RESULT_MINIBUS, "MINIBUS");
            AddString(InfoId.VTR_RESULT_SMALLTRUCK, "SMALLTRUCK");
            AddString(InfoId.VTR_RESULT_HUMAN, "HUMAN");
            AddString(InfoId.VTR_RESULT_TUMBREL, "TUMBREL");
            AddString(InfoId.VTR_RESULT_TRIKE, "TRIKE");
            AddString(InfoId.VTR_RESULT_SUV_MPV, "SUV/MPV");
            AddString(InfoId.VTR_RESULT_MEDIUM_BUS, "MEDIUMBUS");
            AddString(InfoId.VTR_RESULT_MOTOR_VEHICLE, "MOTOR");
            AddString(InfoId.VTR_RESULT_NON_MOTOR_VEHICLE, "NONMOTORVEHICLE");
            AddString(InfoId.VTR_RESULT_SMALLCAR, "SMALLCAR");
            AddString(InfoId.VTR_RESULT_MICROCAR, "MICROCAR");
            AddString(InfoId.VTR_RESULT_PICKUP, "PICKUP");
            AddString(InfoId.VTR_RESULT_CONTAINER_TRUCK, "CONTAINER_TRUCK");
            AddString(InfoId.VTR_RESULT_MINI_TRUCK, "MINI_TRUCK");
            AddString(InfoId.VTR_RESULT_SLAG_CAR, "SLAG_CAR");
            AddString(InfoId.VTR_RESULT_CRANE, "CRANE");
            AddString(InfoId.VTR_RESULT_OIL_TANK_TRUCK, "OIL_TANK_TRUCK");
            AddString(InfoId.VTR_RESULT_CONCRETE_MIXER, "CONCRETE_MIXER");
            AddString(InfoId.VTR_RESULT_PLATFORM_TRAILER, "PLATFORM_TRAILER");
            AddString(InfoId.VTR_RESULT_HATCHBACK, "HATCHBACK");
            AddString(InfoId.VTR_RESULT_SALOON, "SALOON");
            AddString(InfoId.VTR_RESULT_SPORT_SEDAN, "SPORT_SEDAN");
            AddString(InfoId.VTR_RESULT_SMALL_BUS, "SMALL_BUS");
            //VehicleClassifyType
            AddString(InfoId.VTR_RESULT_CLASSIFY_OTHER, "OTHER");
            AddString(InfoId.VTR_RESULT_CLASSIFY_COACH, "COACH");
            AddString(InfoId.VTR_RESULT_CLASSIFY_CAR, "CAR");
            AddString(InfoId.VTR_RESULT_CLASSIFY_VAN, "VAN");
            AddString(InfoId.VTR_RESULT_CLASSIFY_NONMOTOR, "NONMOTOR");
            AddString(InfoId.VTR_RESULT_CLASSIFY_MINIBUS, "MINIBUS");
            AddString(InfoId.VTR_RESULT_CLASSIFY_TRUCK, "TRUCK");
            //log
            AddString(InfoId.ChangeOtherParam, "ChangeOtherParam:");
            AddString(InfoId.DeleteUser, "DeleteUser:");
            AddString(InfoId.ResetPassword2, "ResetPassword:");
            AddString(InfoId.ChangePassword, "ChangePassword:");
            AddString(InfoId.AddUser, "AddUser:");
            AddString(InfoId.Pression, "Pression:");
            AddString(InfoId.Statue, "Statue:");
            AddString(InfoId.Creator, "Creator:");
            AddString(InfoId.ChangeUser, "ChangeUser:");
            AddString(InfoId.ChangeRunningModel, "ChangeRunningModel:");
            AddString(InfoId.Login, "Login:");
            AddString(InfoId.CloseApp, "Clsoe App");
            AddString(InfoId.OpenApp, "OpenApp:");
            AddString(InfoId.Tourist, "Tourist");
            AddString(InfoId.Operator, "Operator");
            AddString(InfoId.Manager, "Manager");
            AddString(InfoId.SuperManager, "SuperManager");
            AddString(InfoId.LimitingInfoChange, "LimitingInfoChange:");
            AddString(InfoId.VehicleReport, "VehicleInfoReport");
            AddString(InfoId.OldPasswordError, "Old Password Error!");
            AddString(InfoId.NoPowerChangePwd, "You are not allowed to change this password");
            AddString(InfoId.CannotDeleteYourself, "You are not allowed to delete yourself");
            AddString(InfoId.CannotDeleteSM, "You are not allowed to delete super manager");
            AddString(InfoId.BeginEndTime, "The start time must not be greater than the end time");
            AddString(InfoId.Logout, "Logout:");
            AddString(InfoId.DriveData, "DriveData:");
            AddString(InfoId.BackUpDataBase, "BackUpDataBase:");
            AddString(InfoId.ReStoreDataBase, "ReStoreDataBase:");
            #region statistical information
            AddString(InfoId.STAT_TOTAL, "Total");
            AddString(InfoId.STAT_OVERSTANDARD, "Over");
            AddString(InfoId.STAT_STATDARD, "OK");
            AddString(InfoId.STAT_INVAILD, "Invaild");
            AddString(InfoId.STAT_OVERSTANDARD_RATE, "Over Rate");
            #endregion

            #region SettingParamLog
            AddString(InfoId.SetTimingCalParameter, "SetTimingCalParameter");
            AddString(InfoId.SetUVSCtrlParameter, "SetUVSCtrlParameter");
            AddString(InfoId.SetTDLASCtrlParameter, "SetTDLASCtrlParameter");
            AddString(InfoId.SetSmokeHandwareParameter, "SetSmokeHandwareParameter");
            AddString(InfoId.SetAcceleratedParameter, "SetAcceleratedParameter");
            AddString(InfoId.SetSystemParameter, "SetSystemParameter");
            AddString(InfoId.SetNoLinearCalParameter, "SetNoLinearCalParameter");
            #endregion
            AddString(InfoId.SelectNull, "Selected No Data!");
            AddString(InfoId.PageNotExist, "This Page is Not Exist!");
            AddString(InfoId.Checked, "Check");
            AddString(InfoId.Unchecked, "Unchecked");
            AddString(InfoId.EnterCalibrationMode, "EnterCalibrationMode");
            AddString(InfoId.OutCalibrationMode, "OutCalibrationMode");
            AddString(InfoId.ConnectionFail, "ConnectionFail");
            AddString(InfoId.PleaseReStart, "Please Restart Your Program!");
            AddString(InfoId.BackUpDBTips, "Please make sure of your database and filepath are stored on the same computer and your filepath is not contains space or other Special characters!");
            AddString(InfoId.ComCOM, "ComCOM");
            AddString(InfoId.ComTCP, "ComTCP");
            AddString(InfoId.ComUDP, "ComUDP");
            AddString(InfoId.CheckInput, "Please Check Your Input");
            AddString(InfoId.Ringelman, "RingelmanEmittance");
            AddString(InfoId.Opsmoke, "Opsmoke");
            AddString(InfoId.Fixed, "Fixed");
            AddString(InfoId.Moved, "Moved");
            AddString(InfoId.NoOffice  , "Find No Office In Your Computer,Please Check whether your computer has installed");
            AddString(InfoId.DriveGraphData, "DriveGraphData");

            AddString(InfoId.UpAndDown, "The lower limit must be less than the upper limit");

            AddString(InfoId.NoPicture, "No Picture!");
            AddString(InfoId.NoHelpChm, "No Document of Help!");
            AddString(InfoId.vad0To100, " Range is 0-99.99");
            AddString(InfoId.vad0To100000, "Range is 0-99999.99");
            AddString(InfoId.vadOutRange, "Out of Range,Please reset");
            AddString(InfoId.DrivePDF, "Whether to export PDF format?");
        }
        #endregion
    }

    #region enum GridStringId
    public enum InfoId
    {
        #region  ...
        None,
        VersionText,
        ProgressPanelCaption,
        ProgressPanelDescription,

        CorrectItemIsEmpty,
        CalibrateCompleted,
        CalibrateFail,
        SaveCompleted,
        SaveFail,

        OpacitySmaking,
        YellowCar,

        CreateReport,
        Report,
        SureDelete,
        SelectNone,
        All,
        Qualified,
        Disqualified,
        Invalid,
        valid,

        ResetPassword,
        Used,
        Unused,
        NewPassword,
        SaveChange,
        ChangeSuccess,
        ChangeFail,
        LoginFail,
        AccountDisabled,
        InputNotNull,
        LoginFirst,
        FirstInfo,
        LastInfo,
        OpearteSuccess,
        OperateFail,
        UserNameExist,
        UserNameNotAllowed,
        APPExit,
        Logout,

        //color
        Blue,
        Yellow,
        White,
        Black,
        Green,
        Blackness,
        OtherColor,
        Silvery,
        Gray,
        Red,
        DarkBlue,
        Brown,
        Pink,
        Violet,
        DarkGrey,
        Cyan,
        UnfindColor,

        //CarType
        VCA_STANDARD92_PLATE,
        VCA_STANDARD02_PLATE,
        VCA_WJPOLICE_PLATE,
        VCA_JINGCHE_PLATE,
        STANDARD92_BACK_PLATE,
        VCA_SHIGUAN_PLATE,
        VCA_NONGYONG_PLATE,
        VCA_MOTO_PLATE,
        NEW_ENERGY_PLATE,

        //Fuel Type
        DieselCar,
        GasolineCar,
        OtherFuelCar,

        //VehicleType
        VTR_RESULT_OTHER,
        VTR_RESULT_BUS,
        VTR_RESULT_TRUCK,
        VTR_RESULT_CAR,
        VTR_RESULT_MINIBUS,
        VTR_RESULT_SMALLTRUCK,
        VTR_RESULT_HUMAN,
        VTR_RESULT_TUMBREL,
        VTR_RESULT_TRIKE,
        VTR_RESULT_SUV_MPV,
        VTR_RESULT_MEDIUM_BUS,
        VTR_RESULT_MOTOR_VEHICLE,
        VTR_RESULT_NON_MOTOR_VEHICLE,
        VTR_RESULT_SMALLCAR,
        VTR_RESULT_MICROCAR,
        VTR_RESULT_PICKUP,
        VTR_RESULT_CONTAINER_TRUCK,
        VTR_RESULT_MINI_TRUCK,
        VTR_RESULT_SLAG_CAR,
        VTR_RESULT_CRANE,
        VTR_RESULT_OIL_TANK_TRUCK,
        VTR_RESULT_CONCRETE_MIXER,
        VTR_RESULT_PLATFORM_TRAILER,
        VTR_RESULT_HATCHBACK,
        VTR_RESULT_SALOON,
        VTR_RESULT_SPORT_SEDAN,
        VTR_RESULT_SMALL_BUS,

        //VehicleClassifyType
        VTR_RESULT_CLASSIFY_OTHER,
        VTR_RESULT_CLASSIFY_COACH,
        VTR_RESULT_CLASSIFY_CAR,
        VTR_RESULT_CLASSIFY_VAN,
        VTR_RESULT_CLASSIFY_NONMOTOR,
        VTR_RESULT_CLASSIFY_MINIBUS,
        VTR_RESULT_CLASSIFY_TRUCK,

        #endregion
        //Log
        ChangeOtherParam,
        DeleteUser,
        ResetPassword2,
        ChangePassword,
        AddUser,
        Pression,
        Statue,
        Creator,
        ChangeUser,
        ChangeRunningModel,
        Login,
        OpenApp,
        Tourist,
        Operator,
        Manager,
        LimitingInfoChange,
        OldPasswordError,
        CloseApp,
        ReStoreDataBase,
        BackUpDataBase,

        VehicleReport,
        NoPowerChangePwd,
        CannotDeleteYourself,
        CannotDeleteSM,
        BeginEndTime,
        DriveData,
        #region statistical information
        STAT_TOTAL,
        STAT_OVERSTANDARD,
        STAT_STATDARD,
        STAT_INVAILD,
        STAT_OVERSTANDARD_RATE,
        #endregion

        #region SettingParamLog
        SetTimingCalParameter,
        SetUVSCtrlParameter,
        SetTDLASCtrlParameter,
        SetSmokeHandwareParameter,
        SetAcceleratedParameter,
        SetSystemParameter,
        SetNoLinearCalParameter,
        SelectNull,
        #endregion
        PageNotExist,
        Checked,
        Unchecked,
        EnterCalibrationMode,
        OutCalibrationMode,
        ConnectionFail,
        PleaseReStart,
        BackUpDBTips,
        ComCOM,
        ComTCP,
        ComUDP,
        CheckInput,
        Ringelman,
        Opsmoke,
        Fixed,
        Moved,
        NoOffice,
        DriveGraphData,
        SuperManager,

        NoPicture,
        NoHelpChm,

        vad0To100000,
        vad0To100,
        vadOutRange,
        UpAndDown,
        DrivePDF,
    }
    #endregion
}
