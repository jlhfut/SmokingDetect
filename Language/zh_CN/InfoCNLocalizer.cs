
namespace wayeal.language
{
    public class InfoCNLocalizer : InfoLocalizer
    {
        public override string Language { get { return "中文"; } }

        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
            AddString(InfoId.None, "");
            AddString(InfoId.VersionText, "Version: V1.0");
            AddString(InfoId.ProgressPanelCaption, "请等待");
            AddString(InfoId.ProgressPanelDescription, "加载中 ...");

            AddString(InfoId.CorrectItemIsEmpty, "请选择校准项。");
            AddString(InfoId.CalibrateCompleted, "校准已完成!");
            AddString(InfoId.CalibrateFail, "校准失败!");
            AddString(InfoId.SaveCompleted, "保存参数已完成!");
            AddString(InfoId.SaveFail, "保存参数失败!");

            AddString(InfoId.OpacitySmaking, "不透光度");
            AddString(InfoId.YellowCar, "黄牌车");
            AddString(InfoId.CreateReport, "确定生成报告条数：");
            AddString(InfoId.Report , "生成报告");
            AddString(InfoId.SureDelete, "确定删除?");
            AddString(InfoId.SelectNone, "未选中任何!");

            AddString(InfoId.All, "所有");
            AddString(InfoId.Qualified, "合格");
            AddString(InfoId.Disqualified, "不合格");
            AddString(InfoId.Invalid, "无效");
            AddString(InfoId.valid, "有效");
            AddString(InfoId.ResetPassword, "确定重置密码吗?");
            AddString(InfoId.Used, "启用");
            AddString(InfoId.Unused, "禁用");
            AddString(InfoId.NewPassword, "两次输入的密码不一致!");

            AddString(InfoId.SaveChange, "确定保存修改？");
            AddString(InfoId.ChangeSuccess, "保存成功");
            AddString(InfoId.ChangeFail, "保存失败");
            AddString(InfoId.LoginFail, "用户名或密码不正确");
            AddString(InfoId.InputNotNull, "输入不能为空");
            AddString(InfoId.AccountDisabled, "账户被禁用");
            AddString(InfoId.LoginFirst, "请先登录");

            AddString(InfoId.FirstInfo, "已经是第一条数据了");
            AddString(InfoId.LastInfo, "已经是最后一条数据了");
            AddString(InfoId.OpearteSuccess, "操作成功");
            AddString(InfoId.OperateFail, "操作失败");
            AddString(InfoId.UserNameExist, "该名称已存在");
            AddString(InfoId.UserNameNotAllowed, "该用户名不被允许使用，请更换用户名");
            AddString(InfoId.APPExit, "退出");
            //颜色
            AddString(InfoId.Blue, "蓝色");
            AddString(InfoId.Yellow, "黄色");
            AddString(InfoId.White, "白色");
            AddString(InfoId.Black, "黑色");
            AddString(InfoId.Green, "绿色");
            AddString(InfoId.Blackness, "民航黑");
            AddString(InfoId.OtherColor, "其他");
            AddString(InfoId.Silvery, "银色");
            AddString(InfoId.Gray, "灰色");
            AddString(InfoId.Red, "红色");
            AddString(InfoId.DarkBlue, "深蓝");
            AddString(InfoId.Brown, "棕色");
            AddString(InfoId.Pink, "粉色");
            AddString(InfoId.Violet, "紫色");
            AddString(InfoId.DarkGrey, "深灰");
            AddString(InfoId.Cyan, "青色");
            AddString(InfoId.UnfindColor, "未知");

            //号牌类型
            AddString(InfoId.VCA_STANDARD92_PLATE, "标准民用车与军车车牌");
            AddString(InfoId.VCA_STANDARD02_PLATE, "02式民用车牌");
            AddString(InfoId.VCA_WJPOLICE_PLATE, "武警车车牌");
            AddString(InfoId.VCA_JINGCHE_PLATE, "警车车牌");
            AddString(InfoId.STANDARD92_BACK_PLATE, "民用车双行尾牌");
            AddString(InfoId.VCA_SHIGUAN_PLATE, "使馆车牌");
            AddString(InfoId.VCA_NONGYONG_PLATE, "农用车车牌");
            AddString(InfoId.VCA_MOTO_PLATE, "摩托车车牌");
            AddString(InfoId.NEW_ENERGY_PLATE, "新能源车牌");

            //燃油类型
            AddString(InfoId.DieselCar, "柴油");
            AddString(InfoId.GasolineCar, "汽油");
            AddString(InfoId.OtherFuelCar, "其他");

            //车辆类型
            AddString(InfoId.VTR_RESULT_OTHER, "其他");
            AddString(InfoId.VTR_RESULT_BUS, "客车");
            AddString(InfoId.VTR_RESULT_TRUCK, "货车");
            AddString(InfoId.VTR_RESULT_CAR, "轿车");
            AddString(InfoId.VTR_RESULT_MINIBUS, "面包车");
            AddString(InfoId.VTR_RESULT_SMALLTRUCK, "小货车");
            AddString(InfoId.VTR_RESULT_HUMAN, "行人");
            AddString(InfoId.VTR_RESULT_TUMBREL, "二轮车");
            AddString(InfoId.VTR_RESULT_TRIKE, "三轮车");
            AddString(InfoId.VTR_RESULT_SUV_MPV, "SUV/MPV");
            AddString(InfoId.VTR_RESULT_MEDIUM_BUS, "中型客车");
            AddString(InfoId.VTR_RESULT_MOTOR_VEHICLE, "机动车");
            AddString(InfoId.VTR_RESULT_NON_MOTOR_VEHICLE, "非机动车");
            AddString(InfoId.VTR_RESULT_SMALLCAR, "小型轿车");
            AddString(InfoId.VTR_RESULT_MICROCAR, "微型轿车");
            AddString(InfoId.VTR_RESULT_PICKUP, "皮卡车");
            AddString(InfoId.VTR_RESULT_CONTAINER_TRUCK, "集装箱卡车");
            AddString(InfoId.VTR_RESULT_MINI_TRUCK, "微卡，栏板卡");
            AddString(InfoId.VTR_RESULT_SLAG_CAR, "渣土车");
            AddString(InfoId.VTR_RESULT_CRANE, "吊车，工程车");
            AddString(InfoId.VTR_RESULT_OIL_TANK_TRUCK, "油罐车");
            AddString(InfoId.VTR_RESULT_CONCRETE_MIXER, "混凝土搅拌车");
            AddString(InfoId.VTR_RESULT_PLATFORM_TRAILER, "平板拖车");
            AddString(InfoId.VTR_RESULT_HATCHBACK, "两厢轿车");
            AddString(InfoId.VTR_RESULT_SALOON, "三厢轿车");
            AddString(InfoId.VTR_RESULT_SPORT_SEDAN, "轿跑");
            AddString(InfoId.VTR_RESULT_SMALL_BUS, "小型客车");
            //车辆类型归类
            AddString(InfoId.VTR_RESULT_CLASSIFY_OTHER, "其他");
            AddString(InfoId.VTR_RESULT_CLASSIFY_COACH, "客车");
            AddString(InfoId.VTR_RESULT_CLASSIFY_CAR, "轿车");
            AddString(InfoId.VTR_RESULT_CLASSIFY_VAN, "货车");
            AddString(InfoId.VTR_RESULT_CLASSIFY_NONMOTOR, "非机动车");
            AddString(InfoId.VTR_RESULT_CLASSIFY_MINIBUS, "面包车");
            AddString(InfoId.VTR_RESULT_CLASSIFY_TRUCK, "工程车");

            AddString(InfoId.ChangeOtherParam, "修改其他参数:");
            AddString(InfoId.DeleteUser, "删除用户:");
            AddString(InfoId.ResetPassword2, "重置密码:");
            AddString(InfoId.ChangePassword, "修改密码:");
            AddString(InfoId.AddUser, "增加用户:");
            AddString(InfoId.Pression, "权限:");
            AddString(InfoId.Statue, "状态:");
            AddString(InfoId.Creator, "创建人:");
            AddString(InfoId.ChangeUser, "修改用户:");
            AddString(InfoId.ChangeRunningModel, "运行模式:");
            AddString(InfoId.Login, "登录:");
            AddString(InfoId.CloseApp, "关闭应用");
            AddString(InfoId.OpenApp, "应用启动");
            AddString(InfoId.Tourist, "游客");
            AddString(InfoId.Operator, "操作员");
            AddString(InfoId.Manager, "管理员");
            AddString(InfoId.SuperManager, "超级管理员");
            AddString(InfoId.Logout, "注销登录:");
            AddString(InfoId.LimitingInfoChange, "限值信息更改:");
            AddString(InfoId.BackUpDataBase, "备份数据库:");
            AddString(InfoId.ReStoreDataBase, "还原数据库:");

            AddString(InfoId.OldPasswordError, "原密码错误");
            AddString(InfoId.NoPowerChangePwd, "该用户密码不允许修改");
            AddString(InfoId.VehicleReport, "VehicleInfoReportZNCH");
            AddString(InfoId.CannotDeleteYourself, "无法删除自己的账号！请重新操作");
            AddString(InfoId.CannotDeleteSM, "无法删除超级管理员！请重新操作");
            AddString(InfoId.BeginEndTime, "开始时间不能大于或等于结束时间");
            AddString(InfoId.DriveData, "导出数据:");

            #region statistical information
            AddString(InfoId.STAT_TOTAL, "总车次");
            AddString(InfoId.STAT_OVERSTANDARD, "超标");
            AddString(InfoId.STAT_STATDARD, "合格");
            AddString(InfoId.STAT_INVAILD, "无效");
            AddString(InfoId.STAT_OVERSTANDARD_RATE, "超标率");
            #endregion

            #region SettingParamLog
            AddString(InfoId.SetTimingCalParameter, "设置定时校准参数");
            AddString(InfoId.SetUVSCtrlParameter, "设置紫外控制参数");
            AddString(InfoId.SetTDLASCtrlParameter, "设置TDLAS控制参数");
            AddString(InfoId.SetSmokeHandwareParameter, "设置SMOKE模型参数");
            AddString(InfoId.SetAcceleratedParameter, "设置加速度参数");
            AddString(InfoId.SetSystemParameter, "设置系统参数");
            AddString(InfoId.SetNoLinearCalParameter, "设置非线性校准参数");
            #endregion
            AddString(InfoId.SelectNull, "无数据!");
            AddString(InfoId.PageNotExist, "页面不存在");
            AddString(InfoId.Checked, "选中");
            AddString(InfoId.Unchecked, "未选中");
            AddString(InfoId.EnterCalibrationMode, "进入校准模式");
            AddString(InfoId.OutCalibrationMode, "退出校准模式");
            AddString(InfoId.ConnectionFail, "请检查与服务器的连接！");
            AddString(InfoId.PleaseReStart, "请重启程序！");
            AddString(InfoId.BackUpDBTips, "请确保您需要备份的数据库文件\r\n与选择的保存路径在同一台计算\r\n机上，且保存的文件路径不含\r\n空格等特殊字符！");
            AddString(InfoId.ComCOM, "串口");
            AddString(InfoId.ComTCP, "网口_TCP");
            AddString(InfoId.ComUDP, "网口_UDP");
            AddString(InfoId.CheckInput, "含有非法字符，请检查输入！");
            AddString(InfoId.Ringelman, "林格曼黑度");
            AddString(InfoId.Opsmoke, "不透光度");
            AddString(InfoId.Fixed, "固定式");
            AddString(InfoId.Moved, "移动式");
            AddString(InfoId.NoOffice, "找不到office软件，请检查您的计算机是否已安装office");
            AddString(InfoId.DriveGraphData, "导出谱图数据 ");
            AddString(InfoId.UpAndDown, "下限必须小于上限");
            AddString(InfoId.NoPicture, "未找到图片！");
            AddString(InfoId.NoHelpChm, "未找到帮助文档!");
            AddString(InfoId.vad0To100, "输入范围为0-99.99");
            AddString(InfoId.vad0To100000, "输入范围为0-99999.99");
            AddString(InfoId.vadOutRange, "输入超出范围,请重新设置");
            AddString(InfoId.DrivePDF, "是否选择PDF格式？");
        }
        #endregion
    }
}
