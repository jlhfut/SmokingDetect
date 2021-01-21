using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.SqlHelp;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.ImDAL
{
    public class ImUserListDAL : IUserListDAL
    {
        SqlSugarClient db = new SqlConnect().GetInstance();

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int IUserListDAL.AddUser(UserList userList)
        {
            return db.Insertable(userList).ExecuteCommand();

        }

        /// <summary>
        /// 根据用户名删除
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int IUserListDAL.DeleteByName(UserList userList)
        {
          return db.Deleteable<UserList>().In(userList.uname).ExecuteCommand();
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        DataTable IUserListDAL.SelectAllUser(UserList userList)
        {
            return db.Queryable<UserList>().ToDataTable();//查询所有
        }

     
        /// <summary>
        /// 根据用户名和用户权限来查找
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        DataTable IUserListDAL.SelectByNameOrPermi(UserList user)
        {

            var exp = Expressionable.Create<UserList>()
           .And(it => it.upermission == user.upermission)
           .Or(it => it.uname.Contains(user.uname)).ToExpression();
            var list = db.Queryable<UserList>().Where(exp).ToDataTable();


            return list;
        }

        /// <summary>
        /// 根据用户名更新数据
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int IUserListDAL.UpdataByUName(UserList userList)
        {
            int result = db.Updateable<UserList>(it => new UserList() { upermission = userList.upermission, uisAlive = userList.uisAlive }).Where(it => it.uname == userList.uname).ExecuteCommand();
            return result;
        }

        

        int IUserListDAL.UpdataByPwd(UserList userList)
        {
            int result = db.Updateable<UserList>(it => new UserList() { upwd = userList.upwd }).Where(it => it.uname == userList.uname).ExecuteCommand();
            return result;
        }

        /// <summary>
        /// 查询密码是否存在
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        int IUserListDAL.QueryPwdByName(UserList userList)
        {

            int isbool = 0;
            var list = db.Queryable<UserList>().Where(it => it.uname == userList.uname).ToList();
            foreach (UserList user in list)
            {
                if (userList.upwd == user.upwd)
                {
                    isbool = 1;
                    break;
                }
            }
            return isbool;
        }

        string IUserListDAL.PageTotal(UserList userList)
        {
         return    db.Queryable<UserList>().Sum(it => it.uname);
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="pagIndex">页面索引</param>
        /// <param name="pageSize">每页有多少条记录</param>
        /// <param name="total">默认 0</param>
        /// <returns></returns>
        List<UserList> IUserListDAL.Pagination(int pagIndex, int pageSize, int total)
        {
            var list = db.SqlQueryable<UserList>("select * from userlist").ToPageList(1, 2, ref total);
            return list;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="beUserName"></param>
        /// <param name="cbePermission"></param>
        /// <returns></returns>
        DataTable IUserListDAL.SelectUserPage(string beUserName, int? cbePermission,int pageIndex,int pageSize,ref int totalPage)
        {
           



            return db.Queryable<UserList>()
               
              .WhereIF(!string.IsNullOrEmpty(cbePermission.ToString()), it => it.upermission == cbePermission)  //车身颜色
               .WhereIF(!string.IsNullOrEmpty(beUserName), it => it.uname.Contains(beUserName))//车牌号码
          .ToDataTablePage(pageIndex, pageSize, ref totalPage);  //分页后的table
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int? IUserListDAL.UserLogin(UserList user)
        {
            UserList permisson = db.Queryable<UserList>().Where(it => it.uname == user.uname && it.upwd == user.upwd).First();
            if (permisson == null)
            {
                UserList userList = new UserList();
                userList.upermission = 10;
                return userList.upermission;
            }
            else
            {
                return permisson.upermission;
            }
            
        }
    }
}

