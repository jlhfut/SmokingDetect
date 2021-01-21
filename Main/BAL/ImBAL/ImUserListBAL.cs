using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.ImBAL
{
    public class ImUserListBAL : IUserListBAL
    {
        IUserListDAL dal = new ImUserListDAL();

        /// <summary>
        /// 根据用户名删除账号
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        public int DeleteByName(UserList userList)
        {
          return  dal.DeleteByName(userList);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userList">用户类</param>
        /// <returns>0 表示失败 1 表示成功</returns>
        int IUserListBAL.AddUser(UserList userList)
        {
            return dal.AddUser(userList);
        }

        int IUserListBAL.DeleteByName(UserList userList)
        {
            return dal.QueryPwdByName(userList);
        }

        string IUserListBAL.PageTotal(UserList userList)
        {
            return dal.PageTotal(userList);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<UserList> IUserListBAL.Pagination(int pagIndex, int pageSize, int total)
        {
           return  dal.Pagination(pagIndex, pageSize, total);
        }

        int IUserListBAL.QueryPwdByName(UserList userList)
        {
            return dal.QueryPwdByName(userList);
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        DataTable IUserListBAL.SelectAllUser(UserList userList)
        {
           return dal.SelectAllUser(userList);
        }

        /// <summary>
        /// 根据用户名，用户权限来查找
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       DataTable IUserListBAL.SelectByNameOrPermi(UserList user)
        {
           return dal.SelectByNameOrPermi(user);
        }

        DataTable IUserListBAL.SelectUserPage(string beUserName, int? cbePermission, int pageIndex, int pageSize, ref int totalPage)
        {
            return dal.SelectUserPage(beUserName, cbePermission, pageIndex, pageSize, ref totalPage);
        }

        int IUserListBAL.UpdataByPwd(UserList userList)
        {
            return dal.UpdataByPwd(userList);
        }

        /// <summary>
        /// 根据用户名更新数据
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int IUserListBAL.UpdataByUName(UserList userList)
        {
            return dal.UpdataByPwd(userList);
        }

        int? IUserListBAL.UserLogin(UserList user)
        {
            return dal.UserLogin(user);
        }
    }
}
