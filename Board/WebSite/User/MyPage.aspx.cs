using application;
using System;

namespace Board.WebSite.MyPage
{
    public partial class MyPage : BasePage
    {
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>ユーザサービスクラス</summary>
            var user = new UserTable();
            if (!IsPostBack)
            {
                //ユーザIDを取得
                var userID = session.Current.userID;
                var loginID = user.GetByField(userID,Constants.FIELD_USER_LOGIN_ID);
                pLoginID.InnerText = loginID;
                var userName = user.GetByField(userID,Constants.FIELD_USER_USER_NAME);
                pUserName.InnerText = userName;
            }
        }
    }
}