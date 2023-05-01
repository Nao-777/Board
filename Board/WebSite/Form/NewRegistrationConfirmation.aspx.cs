using application;
using System;
using System.Diagnostics;

namespace Board.WebSite.Form
{
    public partial class NewRegistrationConfirmation : BasePage
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
            if (!IsPostBack)
            {
                //NewRegistration.aspxから値を取得する
                pUserName.InnerText = Request.QueryString[Constants.QUERY_USER_NAME];
                pLoginID.InnerText = Request.QueryString[Constants.QUERY_USER_LOGINID];
                pUserPassword.InnerText = Request.QueryString[Constants.QUERY_USER_PASSWORD];
            }
        }

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbNewRegistrationButton_Click(object sender, EventArgs e)
        {
            var userID = common.CreateRandomId(8, Constants.TABLE_USER);
            Debug.WriteLine("usesr"+userID);
            if (string.IsNullOrEmpty(userID)) return;

            //入力されたユーザ名、ログインID、パスワードをクエリ文字列として受け取る
            var userName = Request.QueryString[Constants.QUERY_USER_NAME];
            var loginID = Request.QueryString[Constants.QUERY_USER_LOGINID];
            var userPassword = Request.QueryString[Constants.QUERY_USER_PASSWORD];

            new UserTable().Insert(userID, loginID, userName, userPassword);
            session.Current.userID = userID;
            Response.Redirect(Constants.PATH_BOARD);
        }
        /// <summary>セッション変数の中身の有無</summary>
        protected override bool JudgeLogin { get { return false; } }
    }
}