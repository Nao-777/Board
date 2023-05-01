using application;
using Board.App_Code;
using System;

namespace Board.WebSite.MainPage.ArticlPage
{
    public partial class ResEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var messageID = Request.QueryString[Constants.QUERY_MESSAGE];
            pMessage.InnerText = new ResTable().GetByField(messageID,Constants.FIELD_IN_ARTICL_USER_MESSAGE);
        }

        /// <summary>
        /// メッセージの編集処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbChangeMessage_Click(object sender, EventArgs e)
        {
            var messageID = Request.QueryString[Constants.QUERY_MESSAGE];
            var message = tbReMessage.Text.Trim();
            var articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            //入力文字列の確認
            var common = new CommonMethod();
            if (common.CheckCharacterIntegrity(message, 1, 200, false))
            {
                new ResTable().Update(message, messageID);
                var url = new UrlCreator(Constants.PAGE_ARTICL)
                    .AddParam(Constants.QUERY_ARTICLID, articlID)
                    .CreateUrl();
                Response.Redirect(url);
            }
            else
            {
                pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            }
        }

        /// <summary>
        /// 戻るボタン
        ///（メッセージの取得方法がクエリ文字列によってarticlIDを取得しているので、articlIDを渡す）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void backToResEdit_Click(object sender, EventArgs e)
        {
            var articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            var url = new UrlCreator(Constants.PAGE_ARTICL)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .CreateUrl();
            Response.Redirect(url);
        }
    }
}