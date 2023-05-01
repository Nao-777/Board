using System;
using application;


namespace Board.WebSite.Form
{
    public partial class Login : BasePage
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        /// <summary>
        /// 入力された情報を基にログイン処理をする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbLogin_Click(object sender, EventArgs e)
        {
            var loginId = tbLoginID.Text.Trim();
            var loginPassword = tbPasswordID.Text.Trim();
            if (string.IsNullOrEmpty(loginId)
                    || string.IsNullOrEmpty(loginPassword)) pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            else
            {
                if (new UserTable().GetByLoginIDAndPassword(loginId, loginPassword,Constants.FIELD_USER_USER_ID) != null)
                {
                    new SessionManager().Current.userID = new UserTable().GetByLoginIDAndPassword(loginId, loginPassword, Constants.FIELD_USER_USER_ID);
                    Response.Redirect(Constants.PATH_BOARD);
                }
                else pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            }
        }
        /// <summary>セッション変数の中身の有無</summary>
        protected override bool JudgeLogin { get { return false; } }
    }
}