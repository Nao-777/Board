using application;
using System;
using System.Data;

namespace Board.App_Code
{
    public class BoardTable:SqlMethod
    {
        /// <summary>
        /// スレIDを使用して要素を取得
        /// </summary>
        /// <param name="articlID">スレID</param>
        /// <param name="columnName">列の名前</param>
        /// <returns>要素</returns>
        public string GetByField(string articlID, string columnName)
        {
            var sqlQuery = string.Format("SELECT {0} FROM {1} WHERE articlID = '{2}'", columnName, Constants.TABLE_BOARD, articlID);
            return Get(sqlQuery, columnName);
        }
        /// <summary>
        /// 掲示板一覧の表示
        /// </summary>
        /// <param name="id">表示するRepeaterコントローラーのID</param>
        /// <param name="skip">スキップする数</param>
        /// <param name="getRecodeCount">表示する数</param>
        public DataTable Display(int skip,int getRecodeCount)
        {
            var sqlQuery = string.Format("SELECT * FROM {0} ORDER BY days DESC OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", Constants.TABLE_BOARD,skip,getRecodeCount);
            //Debug.WriteLine(sqlQuery);
            return Display(sqlQuery);
        }
        
        /// <summary>
        /// 挿入
        /// </summary>
        /// <param name="articlID">スレID</param>
        /// <param name="userId">ユーザID</param>
        /// <param name="userName">ユーザ名</param>
        /// <param name="title">タイトル</param>
        /// <param name="contents">内容</param>
        public void Insert(string articlID, string userId, string userName, string title,string contents)
        {
            ///時間の取得
            DateTime dt = DateTime.Now;
            string days = dt.ToString("yyyy/MM/dd HH:mm:ss");
            var sqlQuery = string.Format(" INSERT  {0} ( articlID,userId,userName,articlTitle,articlContents,days) VALUES ('{1}','{2}',N'{3}',N'{4}',N'{5}','{6}')",Constants.TABLE_BOARD , articlID, userId, userName, title, contents, days);
            Exec(sqlQuery);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="articlID">スレID</param>
        /// <param name="title">タイトル</param>
        /// <param name="contents">内容</param>
        public void Update(string articlID, string title, string contents)
        {
            var sqlQuery = string.Format("UPDATE {0} SET  articlTitle = N'{1}', articlContents = N'{2}' WHERE  articlID = '{3}'", Constants.TABLE_BOARD, title, contents, articlID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// ユーザIDを使用して更新
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="userName">ユーザ名</param>
        public void UpdateByUserID(string userId, string userName)
        {
            var sqlQuery = string.Format("UPDATE {0} SET  userName = N'{1}' WHERE userId = '{2}'", Constants.TABLE_BOARD,userName,userId );
            Exec(sqlQuery);
        }
        /// <summary>
        /// スレの削除
        /// </summary>
        /// <param name="articlID"></param>
        public void Delete(string articlID)
        {
            var sqlQuery = string.Format("DELETE {0} WHERE  articlID = '{1}'", Constants.TABLE_BOARD,articlID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// アカウント削除の時に使用
        /// </summary>
        /// <param name="userID"></param>
        public void DeleteByUserID(string userID)
        {
            var sqlQuery = string.Format("DELETE {0} WHERE  userId = '{1}'", Constants.TABLE_BOARD, userID);
            Exec(sqlQuery);
        }
    }
}