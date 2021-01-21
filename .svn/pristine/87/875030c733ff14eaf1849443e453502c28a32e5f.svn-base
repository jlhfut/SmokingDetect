using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.Utils.Localization;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace wayeal.language
{
    
    public class XtraCNLocalizer : XtraLocalizer
    {
        public static string zhCN = "中文";
        public override void LoadLocalizer()
        {
            if (CultureInfo.CurrentCulture.Name == "zh-CN")
            {
                Localizer.Active = new CNEditorsLocalizer();
                GridLocalizer.Active = new CNGridLocalizer();
                BarLocalizer.Active = new CNBarLocalizer();
                FilterUIElementResXLocalizer.Active = new FilterLocalizer();
                PreviewLocalizer.Active = new PreviewResLocalizer();
            }
        }
    }

    public class CNEditorsLocalizer : Localizer
    {
        private XtraLocalizer<StringId> xtraLocalizer = null;
        public CNEditorsLocalizer()
        {
            xtraLocalizer = new EditorsResLocalizer();
        }
        public override string Language { get { return XtraCNLocalizer.zhCN; } }

        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
             //   case StringId.XtraMessageBoxOkButtonText: return "确认";
                case StringId.SearchControlNullValuePrompt: return "请输入搜索内容...";
                case StringId.FilterCriteriaToStringFunctionIsNullOrEmpty: return "空或未定义";
                case StringId.FilterCriteriaToStringGroupOperatorAnd: return "并且";
                case StringId.FilterCriteriaToStringGroupOperatorOr: return "或者";
            }
            string rs = xtraLocalizer.GetLocalizedString(id);
            return rs == null ? base.GetLocalizedString(id) : rs;
        }
    }

    public class CNGridLocalizer : GridLocalizer
    {
        private XtraLocalizer<GridStringId> xtraLocalizer = null;
        public CNGridLocalizer() : base()
        {
            xtraLocalizer = new GridResLocalizer();
        }
        public override string Language { get { return XtraCNLocalizer.zhCN; } }
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.CheckboxSelectorColumnCaption:return "选择";
                case GridStringId.FindNullPrompt: return "输入查询关键字";
            }
            string rs = xtraLocalizer.GetLocalizedString(id);
            return rs == null ? base.GetLocalizedString(id) : rs;
        }
    }
    public class PreviewResLocalizer : PreviewLocalizer
    {
        public PreviewResLocalizer()
        {
        }
        public override string Language { get { return XtraCNLocalizer.zhCN; } }

        public override string GetLocalizedString(PreviewStringId id)
        {
            switch (id)
            {
                case PreviewStringId.PrinterStatus_Ready:
                    return "打印机就绪";
                
            }

            return base.GetLocalizedString(id);
        }
        protected override void PopulateStringTable()
        {
            return;
        }
        public override XtraLocalizer<PreviewStringId> CreateResXLocalizer()
        {
            return null;
        }
    }

    public class CNBarLocalizer : BarLocalizer
    {
        private XtraLocalizer<BarString> xtraLocalizer = null;
        public CNBarLocalizer() : base()
        {
            xtraLocalizer = new BarsResLocalizer();
        }
        public override string Language { get { return XtraCNLocalizer.zhCN; } }

        public override string GetLocalizedString(BarString id)
        {
            switch (id)
            {

            }
            string rs = xtraLocalizer.GetLocalizedString(id);
            return rs == null ? base.GetLocalizedString(id) : rs;
        }

        protected override void PopulateStringTable()
        {

        }

        public override XtraLocalizer<BarString> CreateResXLocalizer()
        {
            return xtraLocalizer;
        }
    }


    public class GridResLocalizer : XtraResXLocalizer<GridStringId>
    {
        public GridResLocalizer() : base(new GridLocalizer())
        {
        }
        public override string GetLocalizedString(GridStringId id)
        {
            try
            {
                return base.GetLocalizedString(id);
            }
            catch
            {
                return null;
            }
        }

        protected override ResourceManager CreateResourceManagerCore()
        {
            try
            {
                string resName = "DevExpress.XtraGrid";
                string version = "v18.2";
                string path = System.AppDomain.CurrentDomain.BaseDirectory + CultureInfo.CurrentCulture.Name + "\\" + resName + "." + version + ".resources.dll";
                return new ResourceManager(resName + ".LocalizationRes." + CultureInfo.CurrentCulture.Name, Assembly.LoadFrom(path));
            }
            catch
            {
                return null;
            }
        }
    }

    public class EditorsResLocalizer : XtraResXLocalizer<StringId>
    {
        public EditorsResLocalizer() : base(new Localizer())
        {
        }
        public override string GetLocalizedString(StringId id)
        {
            try
            {
                return base.GetLocalizedString(id);
            }
            catch
            {
                return null;
            }
        }

        protected override ResourceManager CreateResourceManagerCore()
        {
            try
            {
                string resName = "DevExpress.XtraEditors";
                string version = "v18.2";
                string path = System.AppDomain.CurrentDomain.BaseDirectory + CultureInfo.CurrentCulture.Name + "\\" + resName + "." + version + ".resources.dll";
                return new ResourceManager(resName + ".LocalizationRes." + CultureInfo.CurrentCulture.Name, Assembly.LoadFrom(path)); //typeof(GridResLocalizer).Assembly);
            }
            catch
            {
                return null;
            }
        }
    }

    public class BarsResLocalizer : BarLocalizer
    {
        ResourceManager manager = null;
        public BarsResLocalizer()
        {
            CreateResourceManager();
        }
        protected virtual void CreateResourceManager()
        {
            if (manager != null) this.manager.ReleaseAllResources();
            this.manager = CreateResourceManagerCore();
        }
        protected virtual ResourceManager Manager { get { return manager; } }
        public override string Language { get { return CultureInfo.CurrentUICulture.Name; } }
        public override string GetLocalizedString(BarString id)
        {
            if (id == BarString.None) return "";
            string resStr = "BarString." + id.ToString();
            string ret = Manager.GetString(resStr);
            if (ret == null) ret = "";
            return ret;
        }

        private ResourceManager CreateResourceManagerCore()
        {
            try
            {
                string resName = "DevExpress.XtraBars";
                string version = "v18.2";
                string path = System.AppDomain.CurrentDomain.BaseDirectory + CultureInfo.CurrentCulture.Name + "\\" + resName + "." + version + ".resources.dll";
                return new ResourceManager(resName + ".LocalizationRes." + CultureInfo.CurrentCulture.Name, Assembly.LoadFrom(path)); //typeof(GridResLocalizer).Assembly);
            }
            catch
            {
                return null;
            }
        }
    }

    public class FilterLocalizer : XtraResXLocalizer<FilterUIElementLocalizerStringId>
    {
        public FilterLocalizer() : base(new FilterUIElementResXLocalizer())
        {
        }
        public override string GetLocalizedString(FilterUIElementLocalizerStringId id)
        {
            #region FilterUIElementLocalizerStringId
            switch (id)
            {
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageDescription: return "高于平均值";
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageName: return "平均值以上";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterDescription: return "日期之后";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterName: return "之后";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodDescription: return "范围内的日期";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodName: return "期间内的所有日期 ";
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilName: return "四月";
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustName: return "八月";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeforeDescription: return "日期之前";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeforeName: return "之前";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithDescription: return "以特定文本开始";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithName: return "以开始";
                case FilterUIElementLocalizerStringId.CustomUIFilterBelowAverageDescription: return "平均值以下";
                case FilterUIElementLocalizerStringId.CustomUIFilterBelowAverageName: return "低于平均值";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenDescription: return "范围内的值";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenName: return "介于";
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNName: return "最低值";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsDescription: return "包含特定文本";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsName: return "包含";
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomDescription: return "由并或运算符组合的两个条件";
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomName: return "自定义滤波";
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsDescription: return "通用日期范围";
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsName: return "特定日期段";
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberName: return "十二月";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginsWithDescription: return "不以特定文本开始";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginsWithName: return "不以开始";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithDescription: return "";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithName: return "";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainDescription: return "不包含特定文本";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainName: return "不包含";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndsWithDescription: return "不以特定文本结尾";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndsWithName: return "不以结尾";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithDescription: return "";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithName: return "";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualDescription: return "不等于";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualName: return "≠";
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithName: return "以结尾";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsDescription: return "等于";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsName: return "=";
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryName: return "二月";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanDescription: return "大于";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanName: return ">";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToDescription: return "大于或等于";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToName: return ">=";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankDescription: return "空或未指定";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankName: return "是否为空白";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankDescription: return "非空";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankName: return "是否为空";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullDescription: return "已定义";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullName: return "是否已定义";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullDescription: return "未定义";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullName: return "是否未定义";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsSameDayDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterIsSameDayName: return "同一天";
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryName: return "一月";
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyName: return "七月";
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneName: return "六月";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthName: return "上一月";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastQuarterDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterLastQuarterName: return "上一季";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekName: return "上一周";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearName: return "上一年";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanDescription: return "小于";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanName: return "<";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToDescription: return "小于或等于";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToName: return "<=";
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchName: return "三月";
                case FilterUIElementLocalizerStringId.CustomUIFilterMayDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterMayName: return "五月";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthName: return "下一月";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextQuarterDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNextQuarterName: return "下一季度";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekName: return "下一周";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearName: return "下一年";
                case FilterUIElementLocalizerStringId.CustomUIFilterNoneDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNoneName: return "选择";
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberName: return "九月";
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberName: return "十月";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter1Description:
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter1Name: return "第一季度";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter2Description:
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter2Name: return "第二季度";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter3Description:
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter3Name: return "第三季度";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter4Description:
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter4Name: return "第四季度";
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanDescription:
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanName: return "过滤器";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeDescription:
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeName: return "日期过滤";
                case FilterUIElementLocalizerStringId.CustomUIFiltersEnumDescription:
                case FilterUIElementLocalizerStringId.CustomUIFiltersEnumName: return "过滤器";
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberName: return "九月";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsName: return "条目";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsName: return "比值";
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericDescription:
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericName: return "数值过滤";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextDescription: return "内容过滤描述";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextName: return "内容过滤";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthName: return "本月";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisQuarterDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterThisQuarterName: return "本季";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekName: return "本周";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearName: return "本年";
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayName: return "今天";
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowName: return "昨天";
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNName: return "最高值";
                case FilterUIElementLocalizerStringId.CustomUIFilterUserDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterUserName: return "预定义筛选器";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateDescription: return "从年初到现在";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateName: return "年初至今";
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayDescription:
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayName: return "昨天";
                case FilterUIElementLocalizerStringId.CustomUIFirstLabel: return "第一项";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptChooseOne: return "选择一个";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterADate: return "输入日期";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterAValue: return "输入值";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSearchControl: return "输入查询内容";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectADate: return "选择日期";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectAValue: return "选择值";
                case FilterUIElementLocalizerStringId.CustomUISecondLabel: return "第二项";
                case FilterUIElementLocalizerStringId.CustomUITypeLabel: return "类型";
                case FilterUIElementLocalizerStringId.CustomUIValueLabel: return "值";
                case FilterUIElementLocalizerStringId.FilteringUIClearFilter: return "清除";
                case FilterUIElementLocalizerStringId.FilteringUIClose: return "关闭";
                case FilterUIElementLocalizerStringId.FilteringUITabGroups: return "";
                case FilterUIElementLocalizerStringId.FilteringUITabValues: return "值";
            }
            #endregion
            return base.GetLocalizedString(id);
        }
        protected override ResourceManager CreateResourceManagerCore()
        {
            try
            {
                string resName = "DevExpress.Data";
                string version = "v18.2";
                string path = System.AppDomain.CurrentDomain.BaseDirectory + CultureInfo.CurrentCulture.Name + "\\" + resName + "." + version + ".resources.dll";
                return new ResourceManager(resName + ".LocalizationRes." + CultureInfo.CurrentCulture.Name, Assembly.LoadFrom(path)); //typeof(GridResLocalizer).Assembly);
            }
            catch
            {
                return null;
            }
        }
    }
}
