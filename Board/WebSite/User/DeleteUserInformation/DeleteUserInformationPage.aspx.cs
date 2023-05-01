using application;
using System;

namespace Board.WebSite.MyPage.DeleteUserInformation
{
    public partial class DeleteUserInformationPage : System.Web.UI.Page
    {
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        /// <summary>
        /// ユーザ情報・削除されるユーザの記事を削除する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDeleteButton_Click(object sender, EventArgs e)
        {
            var userID = session.Current.userID;
            new UserTable().DeleteAccunt(userID);
            Response.Redirect(Constants.PATH_LOGOUT);
        }
    }
}