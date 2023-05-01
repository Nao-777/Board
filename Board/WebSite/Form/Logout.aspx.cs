using System;

namespace Board.WebSite.Form
{
    public partial class Logout : BasePage
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
        /// <summary>セッション変数の中身の有無</summary>
        protected override bool JudgeLogin { get { return false; } }
    }
}