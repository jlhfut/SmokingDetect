using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust;
using Wayee.Services;

namespace wayeal.exdevice
{
    class DeviceCommBusinessServerHelper
    {
        #region init
        private IBusinessLogicServer _BusinessServer = null;
        public DeviceCommBusinessServerHelper()
        {
            if (SOAClient.Instance != null)
            {
                _BusinessServer = SOAClient.Instance.GetService<IBusinessLogicServer>();
            }
        }
        #endregion
        #region Define
        private static DeviceCommBusinessServerHelper _Instanse = null;
        /// <summary>
        /// 获取业务服务
        /// </summary>
        public static DeviceCommBusinessServerHelper Instanse
        {
            get
            {
                if (_Instanse == null)
                    _Instanse = new DeviceCommBusinessServerHelper();
                return _Instanse;
            }
        }
        #endregion
        #region public
        /// <summary>
        /// 执行业务命令
        /// </summary>
        /// <param name="messgae"></param>
        /// <returns></returns>
        public BusinessResult ExecuteBusiness(BusinessMessage messgae, bool showBusy = false, string hint = "", string caption = "")
        {
            BusinessResult result = new BusinessResult() { Result = false };
            try
            {
                if (_BusinessServer == null)
                {
                    if (SOAClient.Instance.ServerCount < 4)
                        SOAClient.Instance.LoadServices();
                    _BusinessServer = SOAClient.Instance.GetService<IBusinessLogicServer>();
                    if (showBusy)
                        MessageBox.Show(hint, caption, MessageBoxButtons.OK);
                    return result;
                }
                BusinessResult businessResult = _BusinessServer.ExecuteBusiness(messgae);
                if (businessResult != null)
                {
                    if (!businessResult.Result && showBusy)
                    {
                        if (result.ErrorCode != -1)
                            hint += ":" + result.ErrorCode.ToString();
                        XtraMessageBox.Show(hint, caption, MessageBoxButtons.OK);
                    }
                    return businessResult;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
            return result;
        }
        /// <summary>
        /// 获取业务数据
        /// </summary>
        /// <param name="messgae"></param>
        /// <returns></returns>
        public BusinessResult ExecuteBusiness(string cmdkey, string args = "", BusinessType type = BusinessType.Get)
        {
            try
            {
                if (_BusinessServer == null) return null;
                BusinessMessage msg = new BusinessMessage();
                msg.BusinessCommand = cmdkey;
                msg.BusiType = type;
                msg.BusiPriority = BusinessPriority.Highest;
                msg.BusinessParam = args;
                BusinessResult bs = DeviceCommBusinessServerHelper.Instanse.ExecuteBusiness(msg);
                if (bs == null || !bs.Result) return null;
                return bs;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
            return null;
        }
        #endregion

    }
}
