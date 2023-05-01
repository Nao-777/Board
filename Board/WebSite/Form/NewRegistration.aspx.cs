using application;
using System;

namespace Board.WebSite.Form
{
    /// <summary>
    /// 新規登録クラス
    /// </summary>
    public partial class NewRegistration : BasePage
    {
        /// <summary>文字認識など共通のメソッドを含むクラス</summary>
        CommonMethod common = new CommonMethod();
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
        /// 確認画面へ遷移する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbNewRegistrationButton_Click(object sender, EventArgs e)
        {
            var newUserName = tbNewNameID.Text.Trim();
            var newLoginID = tbNewLoginID.Text.Trim();
            var newUserPassword = tbNewPasswordID.Text.Trim();
            //入力された上記の値が条件に合うか検証している
            //trueの場合：新規登録確認画面（NewRegistrationConfirmation.aspx）に飛ぶ
            //falseの場合；入力内容に誤りがないか確認する
            if (common.CheckCharacterIntegrity(newLoginID, 4, 20, true)
                    && common.CheckCharacterIntegrity(newUserName, 0, 20, false)
                        && common.CheckCharacterIntegrity(newUserPassword, 8, 20, true))
            {
                var url = new UrlCreator(Constants.PATH_NEWREGISTRATION_CONFIRMATION)
                    .AddParam(Constants.QUERY_USER_NAME, newUserName)
                    .AddParam(Constants.QUERY_USER_LOGINID, newLoginID)
                    .AddParam(Constants.QUERY_USER_PASSWORD, newUserPassword)
                    .CreateUrl();
                Response.Redirect(url);
            }
            else
            {
                pAlertMsg.InnerText = new ErrorMessage().errorMessage;
            }
        }
        /// <summary>セッション変数の中身の有無</summary>
        protected override bool JudgeLogin { get { return false; } }
    }
}