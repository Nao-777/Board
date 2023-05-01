using application;
using Board.App_Code;
using System;

namespace Board.WebSite.MainPage
{
    public partial class ArticlEdition : BasePage
    {
        /// <summary>文字認識など共通のメソッドを含むクラス</summary>
        CommonMethod common = new CommonMethod();
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        /// <summary>
        /// ページロード
        /// 記事とタイトルの表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var board = new BoardTable();
            if (!IsPostBack)
            {
                var articlID = Request.QueryString[Constants.QUERY_ARTICLID];
                var title = board.GetByField(articlID,Constants.FIELD_BOARD_ARTICL_TITLE);
                pOldTitle.InnerText = title;
                var contents = board.GetByField(articlID, Constants.FIELD_BOARD_ARTICL_CONTENTS);
                pOldContents.InnerText = contents;
            }
        }

        /// <summary>
        /// タイトル・内容の変更をする処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbEditArticlButton_Click(object sender, EventArgs e)
        {
            var board = new BoardTable();
            var articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            var title = tbNewTitle.Text.Trim();
            var contents = tbNewContents.Text.Trim();
            if (common.CheckCharacterIntegrity(title, 1, 100, false)
                    && common.CheckCharacterIntegrity(contents, 1, 500, false))
            {
                board.Update(articlID, title, contents);
                Response.Redirect(Constants.PATH_BOARD);
            }
            else
            {
                pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            }
        }
    }
}