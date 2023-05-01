using Board.App_Code;

namespace application
{
    public class UserTable:SqlMethod
    {
        /// <summary>
        /// ユーザIDを使用して要素を取得
        /// </summary>
        /// <param name="userID">ユーザID</param>
        /// <param name="columnName">列の名前</param>
        /// <returns>要素</returns>
        public string GetByField(string userID,string columnName)
        {
            var sqlQuery = string.Format("SELECT {0} FROM [dbo].[UserInfomation] WHERE userID = '{1}'",columnName,userID);
            return Get(sqlQuery,columnName);

        }
        /// <summary>
        /// ログインIDとパスワードを使用してcolumnsNameで指定した列の要素を取得
        /// </summary>
        /// <param name="loginID">ログインID</param>
        /// <param name="userPassword">ユーザパスワード</param>
        /// <param name="columnName">列の名前</param>
        /// <returns>要素</returns>
        public string GetByLoginIDAndPassword(string loginID,string userPassword,string columnName)
        {
            var sqlQuery = string.Format("SELECT  userID FROM [dbo].[UserInfomation] WHERE loginID = '{0}' AND userPassword = '{1}'",loginID,userPassword);
            return Get(sqlQuery,columnName);
        }
        /// <summary>
        /// UserTableにデータを挿入
        /// </summary>
        /// <param name="userID">ユーザID</param>
        /// <param name="loginID">ログインID</param>
        /// <param name="userName">ユーザ名</param>
        /// <param name="userPassword">ユーザパスワード</param>
        public void Insert(string userID,string loginID,string userName,string userPassword)
        {
            var sqlQuery = string.Format(" INSERT  [dbo].[UserInfomation] (userID,loginID,userName,userPassword) VALUES ('{0}','{1}',N'{2}','{3}')",userID,loginID,userName,userPassword);
            Exec(sqlQuery);
        }
        /// <summary>
        /// データの更新
        /// </summary>
        /// <param name="userID">ユーザID</param>
        /// <param name="loginID">ログインID</param>
        /// <param name="userName">ユーザ名</param>
        /// <param name="userPassword">ユーザパスワード</param>
        public void Update(string userID, string loginID, string userName, string userPassword)
        {
            var sqlQuery = string.Format("UPDATE  [dbo].[UserInfomation] SET loginID = '{0}', userName = N'{1}', userPassword = '{2}' WHERE userID = '{3}'",loginID, userName, userPassword,userID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// データの削除
        /// </summary>
        /// <param name="userID">ユーザID</param>
        public void Delete(string userID)
        {
            var sqlQuery = string.Format("DELETE {0} WHERE  userID = '{1}'", Constants.TABLE_USER, userID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// アカウント削除用
        /// </summary>
        /// <param name="userID"></param>
        public void DeleteAccunt(string userID)
        {
            try
            {
                Delete(userID);
                new BoardTable().DeleteByUserID(userID);
                new ResTable().DeleteByUserID(userID);
            }
            catch
            {
                throw;
            }

        }
    }
}