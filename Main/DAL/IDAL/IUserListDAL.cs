using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.IDAL
{
    interface IUserListDAL
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int AddUser(UserList userList);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        DataTable SelectAllUser(UserList userList);


        /// <summary>
        /// 根据用户名和用户权限来查找用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        DataTable SelectByNameOrPermi(UserList user);

        /// <summary>
        /// 根据用户名更新权限和启用状态
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int UpdataByUName(UserList userList);

        /// <summary>
        /// 根据用户名删除用户
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int DeleteByName(UserList userList);

        int QueryPwdByName(UserList userList);

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int UpdataByPwd(UserList userList);

        /// <summary>
        /// 总页数
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        string PageTotal(UserList userList);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagIndex">页面索引</param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<UserList> Pagination(int pagIndex,int pageSize,int total);


        /// <summary>
        /// 多条件查询分页
        /// </summary>
        /// <param name="beUserName">用户名</param>
        /// <param name="cbePermission">用户权限</param>
        /// <returns></returns>
        DataTable SelectUserPage(string beUserName, int? cbePermission, int pageIndex, int pageSize, ref int totalPage);


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns>返回权限</returns>
        int? UserLogin(UserList user);

    }
}
