using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraEditors;
using System.Configuration;
using wayeal.os.exhaust.DBUtils;
using wayeal.os.exhaust.LogUtils;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucAssistManage : ucManagerBase
    {
       public string strConnection { get; set; }
        string txtBackupPath = @"c:\dbbackup";
        string txtDBName = "smokingdb";
        string backFile;
        public ucAssistManage()
        {
            InitializeComponent();
            //默认数据库名称和备份路径
           string txtDBName = "northwind";
           string txtBackupPath = @"c:\dbbackup";
            strConnection = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
           // GetBackupFiles(txtBackupPath);

        }


        /// <summary>
        /// 数据库还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void sbConfirmRS_Click(object sender, EventArgs e)
        {

            try
            {
                DBBackupHelper.RestoreDataBase(strConnection, txtDBName, backFile);
                MessageBox.Show("数据库还原成功！", "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {

                LogHelper.LogUtlis("RestoreDataBase", ex);
            }
        }

        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbConfirmBK_Click(object sender, EventArgs e)
        {
            try
            {

                //数据库名称
                if (string.IsNullOrEmpty("smokingdb"))
                {
                    MessageBox.Show("请输入需要备份的数据库名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtBackupPath))
                {
                    MessageBox.Show("请输入存放备份的目录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!Directory.Exists(txtBackupPath))
                {
                    MessageBox.Show("路径不存在");
                    return;
                }
                else
                {
                    //yyyyMMddHHmmss为24小时制，yyyyMMddhhmmss为12小时制
                    //string backFile = txtDBName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                     backFile = txtDBName + "backup" + ".bak";
                    DBBackupHelper.BackupDataBase(strConnection, txtDBName, txtBackupPath, backFile);
                    // GetBackupFiles(txtBackupPath);
                    MessageBox.Show("备份成功", "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogUtlis("Assistant-backup",ex);
            }
            
        }
    }
}