using application;
using Board.App_Code;
using System;
using System.Web.UI.WebControls;

namespace Board.WebSite.MainPage.ArticlPage
{
    public partial class InArticlPage :BasePage
    {
        /// <summary>文字認識など共通のメソッドを含むクラス</summary>
        CommonMethod common = new CommonMethod();
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        string articlID;
        /// <summary>
        /// ページロード
        /// スレのタイトル・スレの内容・各ユーザからのメッセージを取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var board = new BoardTable();
            articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            if (!IsPostBack)
            {
                var title = board.GetByField(articlID, Constants.FIELD_BOARD_ARTICL_TITLE);
                hArticlTitle.InnerText =title;
                var contents = board.GetByField(articlID, Constants.FIELD_BOARD_ARTICL_CONTENTS);
                pArticlContents.InnerText = contents;
                var userName = board.GetByField(articlID, Constants.FIELD_BOARD_USER_NAME); ;
                pUserName.InnerText = string.Format("制作者：{0}", userName);
                //画面の表示
                Display(articlID);
            }
        }

        /// <summary>
        /// 画面に表示
        /// </summary>
        /// <param name="articlID">articlID</param>
        private void Display(string articlID)
        {
            var message = new ResTable();
            //10ページごとにページング処理
            var value = Request.QueryString[Constants.QUERY_VALUE];
            //「前へ」ボタンの表示処理
            if (string.IsNullOrEmpty(value) || value.Equals("0"))
            {
                value = "0";
                lbBeforeButton.Visible = false;
            }
            else
            {
                lbBeforeButton.Visible = true;
            }
            //Repeaterコントロールを使った表示
            //1ページに表示するためのデータを取得
            var getRecodeCount = 10;
            //１ページずつ表示する件数
            var skipRecodeCount = 10 * int.Parse(value);
            var messages = message.Display(articlID,skipRecodeCount, getRecodeCount);
            rMessage.DataSource = messages;
            rMessage.DataBind();
            //「次へ」ボタンの表示処理
            var nextRecodeCount = skipRecodeCount + 10;
            if (message.Display(articlID, nextRecodeCount, getRecodeCount).Rows.Count == 0)
            {
                lbNextbutton.Visible = false;
            }
            //CreateIndex(articlID, getRecodeCount, nextRecodeCount);
            DisplayButton();
        }

        /// <summary>
        /// 表示するメッセージに番号を割り振る
        /// </summary>
        /// <param name="articlID">articlID</param>
        /// <param name="getRecodeCount">表示する件数</param>
        /// <param name="skipRecodeCount">スキップする件数</param>
        /*private void CreateIndex(string articlID, int getRecodeCount, int skipRecodeCount)
        {
            var message = new ResTable();
            var count = 1;
            //ページングの次の画面に要素があるか確認
            if (message.Display(articlID, skipRecodeCount, getRecodeCount) == null)
            {
                //画面に含まれる要素を全て数える
                foreach (RepeaterItem item in rMessage.Items)
                {
                    count++;
                }
            }
            else
            {
                var nextCount = message.Display(articlID, skipRecodeCount, getRecodeCount).Length;
                //存在する要素は画面に表示する範囲を超えていないか
                if (nextCount <= getRecodeCount)
                {
                    //次のページに存在する要素数＋画面に表示できる要素数
                    count += nextCount + getRecodeCount;
                }
                else
                {
                    //画面に含まれる要素を全て数える
                    foreach (RepeaterItem item in rMessage.Items)
                    {
                        count++;
                    }
                }
            }
            //数えた要素(count)を一件表示するごとに減らす(降順に表示するため)
            foreach (RepeaterItem item in rMessage.Items)
            {
                count--;
                var number = item.FindControl("pMessageNumber") as Literal;
                number.Text = HtmlSanitizer.HtmlEncode(count.ToString() + ":");
            }
        }*/

        /// <summary>
        /// ユーザIDと比較して各メッセージに削除ボタンと編集ボタンを表示する
        /// </summary>
        private void DisplayButton()
        {
            foreach (RepeaterItem item in rMessage.Items)
            {
                var deleteButton = item.FindControl("bDeleteButton") as Button;
                var editButton = item.FindControl("bToEditPageButton") as Button;
                if (deleteButton == null)
                {
                    continue;
                }
                else if (editButton == null)
                {
                    continue;
                }
                //commandNameを取得
                var deleteButtonCommandName = deleteButton.CommandName;
                var editButtonCommandName = editButton.CommandName;

                if (JudgeDisplayButton(deleteButtonCommandName))
                {
                    deleteButton.Visible = true;
                }
                if (JudgeDisplayButton(editButtonCommandName))
                {
                    editButton.Visible = true;
                }
            }
        }

        /// <summary>
        /// ユーザIDを基に編集・削除ボタンの表示切替判定メソッド
        /// ボタンに含まれるユーザIDの情報とセッションIDで保持しているユーザIDで比較する
        /// </summary>
        /// <param name="buttonCommandName">useIDで識別</param>
        /// <returns>ユーザIDが一致したらtrue、一致しなければfalse</returns>
        private bool JudgeDisplayButton(string buttonCommandName)
        {
            var message = new ResTable();
            var userID = message.GetByField(buttonCommandName,Constants.FIELD_IN_ARTICL_USER_ID);
            var nowUserID = session.Current.userID;
            if (userID.Equals(nowUserID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// メッセージの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bDeleteButton_Click(object sender, EventArgs e)
        {
            var message = new ResTable();
            var messageID = ((Button)sender).CommandName;
            message.Delete(messageID);
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// メッセージの編集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bToEditPageButton_Click(object sender, EventArgs e)
        {
            articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            var messageID = ((Button)sender).CommandName;
            var url = new UrlCreator(Constants.PAGE_MESSAGE_EDIT)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .AddParam(Constants.QUERY_MESSAGE, messageID)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbBeforeButton_Click(object sender, EventArgs e)
        {
            articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            var count = Request.QueryString[Constants.QUERY_VALUE];
            count = (int.Parse(count) - 1).ToString();
            var url = new UrlCreator(Constants.PATH_IN_ARTICL)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .AddParam(Constants.QUERY_VALUE, count)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// 次へボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbNextButton_Click(object sender, EventArgs e)
        {
            articlID = Request.QueryString[Constants.QUERY_ARTICLID];
            var count = Request.QueryString[Constants.QUERY_VALUE];
            if (string.IsNullOrEmpty(count))
            {
                count = "1";
            }
            else
            {
                //ToString()でなければerrorが発生してしまう
                count = (int.Parse(count) + 1).ToString();
            }
            var url = new UrlCreator(Constants.PATH_IN_ARTICL)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .AddParam(Constants.QUERY_VALUE, count)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// レスを返す処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbSendMessage_Click(object sender, EventArgs e)
        {
            var message = new ResTable();
            var messageID = common.CreateRandomId(10, Constants.TABLE_INARTICL);
            if (common.CheckCharacterIntegrity(tbMessage.Text.Trim(), 1, 200, false)
                    && !string.IsNullOrEmpty(messageID))
            {
                var articlID = Request.QueryString[Constants.QUERY_ARTICLID];
                var userID = session.Current.userID;
                var userName = new UserTable().GetByField(userID,Constants.FIELD_USER_USER_NAME);
                var userMessage = tbMessage.Text.Trim();
                //時間の取得
                DateTime date = DateTime.Now;
                message.Insert(messageID, articlID, userID, userName, userMessage);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                pAlertMessage.InnerText =new ErrorMessage().errorMessage;
            }
        }
    }
}