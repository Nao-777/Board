using application;
using System;
using System.Data;

namespace Board.App_Code
{
    public class ResTable:SqlMethod
    {
        /// <summary>
        /// 要素を取得
        /// </summary>
        /// <param name="msgID">レスID</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public string GetByField(string msgID, string columnName)
        {
            var sqlQuery = string.Format("SELECT {0} FROM {1} WHERE messageID = '{2}'", columnName, Constants.TABLE_INARTICL, msgID);
            return Get(sqlQuery, columnName);
        }
        /// <summary>
        /// レス一覧表示
        /// </summary>
        /// <param name="id">repeatorID</param>
        /// <param name="articlID">すれID</param>
        /// <param name="skip">スキップ数</param>
        /// <param name="getRecodeCount">表示する件数</param>
        public DataTable Display(string articlID,int skip, int getRecodeCount)
        {
            var sqlQuery = string.Format("SELECT * FROM {0} WHERE  articlID = '{1}' ORDER BY days DESC OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", Constants.TABLE_INARTICL, articlID,skip, getRecodeCount);
            return Display(sqlQuery);
        }

        /// <summary>
        /// 挿入
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="articlID"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="userMsg"></param>
        public void Insert(string msgID,string articlID,string userID,string userName,string userMsg)
        {
            ///時間の取得
            DateTime dt = DateTime.Now;
            string days = dt.ToString("yyyy/MM/dd HH:mm:ss");
            var sqlQuery = string.Format(" INSERT  {0} ( messageID,articlID,userID, userName,userMessage,days) VALUES ('{1}','{2}','{3}',N'{4}',N'{5}','{6}')", Constants.TABLE_INARTICL,msgID, articlID, userID, userName, userMsg,days);
            Exec(sqlQuery);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userMsg">レスの内容</param>
        /// <param name="msgID">レスID</param>
        public void Update(string userMsg,string msgID)
        {
            var sqlQuery = string.Format("UPDATE {0} SET  userMessage = N'{1}' WHERE  messageID = '{2}'", Constants.TABLE_INARTICL, userMsg,msgID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// ユーザIDを使用して更新
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="userName">ユーザ名</param>
        public void UpdateByUserID(string userId, string userName)
        {
            var sqlQuery = string.Format("UPDATE {0} SET  userName = N'{1}' WHERE userId = '{2}'", Constants.TABLE_INARTICL, userName, userId);
            Exec(sqlQuery);
        }
        /// <summary>
        /// メッセージの削除
        /// </summary>
        /// <param name="msgID"></param>
        public void Delete(string msgID)
        {
            var sqlQuery = string.Format("DELETE {0} WHERE messageID='{1}'", Constants.TABLE_INARTICL, msgID);
            Exec(sqlQuery);
        }
        /// <summary>
        /// アカウント削除の時に使用
        /// </summary>
        /// <param name="userID"></param>
        public void DeleteByUserID(string userID)
        {
            var sqlQuery = string.Format("DELETE {0} WHERE  userID = '{1}'", Constants.TABLE_INARTICL, userID);
            Exec(sqlQuery);
        }
    }
}
