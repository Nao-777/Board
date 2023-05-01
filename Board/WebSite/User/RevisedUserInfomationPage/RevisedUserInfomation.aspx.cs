using application;
using System;

namespace Board.WebSite.User.RevisedUserInfomationPage
{
    public partial class RevisedUserInfomation : System.Web.UI.Page
    {
        /// <summary>文字認識など共通のメソッドを含むクラス</summary>
        CommonMethod common = new CommonMethod();
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();

        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>ユーザサービスクラス</summary>
            var user = new UserTable();
            if (!IsPostBack)
            {
                var userID = session.Current.userID;
                var loginID = user.GetByField(userID,Constants.FIELD_USER_LOGIN_ID);
                pOldLoginID.InnerText = loginID;
                var userName = user.GetByField(userID, Constants.FIELD_USER_USER_NAME);
                pOldUserName.InnerText = userName;
                var userPassword = user.GetByField(userID, Constants.FIELD_USER_USER_PASSWORD);
                pOldPassword.InnerText = userPassword;
            }
        }

        /// <summary>
        /// 入力されて値の文字チェックを行い確認画面へ遷移する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbRevisedConfirmationButton_Click(object sender, EventArgs e)
        {
            var newLoginID = tbNewLoginID.Text.Trim();
            var newUserName = tbNewUserName.Text.Trim();
            var newUserPassword = tbNewPasswordText.Text.Trim();
            if (common.CheckCharacterIntegrity(newLoginID, 4, 20, true)
                    && common.CheckCharacterIntegrity(newUserName, 0, 20, false)
                        && common.CheckCharacterIntegrity(newUserPassword, 8, 20, true))
            {
                //クエリ文字列で確認画面へ変数を渡す
                var url = new UrlCreator(Constants.PATH_EDIT_USER_INFORMATION_CONFIRMATION)
                    .AddParam(Constants.QUERY_USER_LOGINID, newLoginID)
                    .AddParam(Constants.QUERY_USER_NAME, newUserName)
                    .AddParam(Constants.QUERY_USER_PASSWORD, newUserPassword)
                    .CreateUrl();
                Response.Redirect(url);
            }
            else
            {
                pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            }
        }
    }
}