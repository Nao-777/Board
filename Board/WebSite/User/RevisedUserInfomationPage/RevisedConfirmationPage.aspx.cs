using application;
using Board.App_Code;
using System;

namespace Board.WebSite.User.RevisedUserInfomationPage
{
    public partial class RevisedConfirmationPage : System.Web.UI.Page
    {
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        /// <summary>
        /// ページロード
        /// RevisedUserInfomation.aspxからログインID、ユーザネーム、パスワードを取得・表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userID = session.Current.userID;
                var loginID = Request.QueryString[Constants.QUERY_USER_LOGINID];
                pConfirmationNewLoginID.InnerText = loginID;
                var userName = Request.QueryString[Constants.QUERY_USER_NAME];
                pConfirmationNewUserName.InnerText = userName;
                var userPassword = Request.QueryString[Constants.QUERY_USER_PASSWORD];
                pConfirmationNewUserPassword.InnerText = userPassword;
            }
        }

        /// <summary>
        /// 変更の決定をする処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDecisionButton_Click(object sender, EventArgs e)
        {
            var userID = session.Current.userID;
            var loginID = Request.QueryString[Constants.QUERY_USER_LOGINID];
            var userName = Request.QueryString[Constants.QUERY_USER_NAME];
            var userPassword = Request.QueryString[Constants.QUERY_USER_PASSWORD];
            new UserTable().Update(userID, loginID, userName, userPassword);
            new BoardTable().UpdateByUserID(userID, userName);
            new ResTable().UpdateByUserID(userID, userName);
            Response.Redirect(Constants.PATH_MYPAGE);
        }
    }
}