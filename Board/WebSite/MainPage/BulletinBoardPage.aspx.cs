using application;
using Board.App_Code;
using System;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace Board.WebSite.MainPage
{
    /// <summary>
    /// 掲示板トップクラス
    /// </summary>
    public partial class BulletinBoardPage : BasePage
    {
        /// <summary>文字認識など共通のメソッドを含むクラス</summary>
        CommonMethod common = new CommonMethod();
        /// <summary>セッションクラス</summary>
        SessionManager session = new SessionManager();
        /// <summary>
        /// ページロード
        /// 掲示板を表示する
        /// userIDを取得・判別してボタンの表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ユーザIDを外部クラス経由で取得する
                var userID = session.Current.userID;
                Debug.WriteLine("現在のログインユーザ::" + userID);
                //画面表示
                display();
                //削除・変数ボタンの表示切替
                foreach (RepeaterItem item in rArticle.Items)
                {
                    var deleteButton = item.FindControl("bDeleteArticlButton") as Button;
                    var editButton = item.FindControl("bToEditArticlPageButton") as Button;
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
        }

        /// <summary>
        /// 画面表示メソッド
        /// ページングのボタン「前へ」「次へ」の表示
        /// </summary>
        private void display()
        {

            var board = new BoardTable();
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
            //スレの表示
            
            //スレの表示
            var articls = board.Display(skipRecodeCount, getRecodeCount);
            Debug.WriteLine("articls+"+articls);
            rArticle.DataSource = articls;
            rArticle.DataBind();
            //「次へ」ボタンの表示処理
            var nextRecodeCount = skipRecodeCount + 10;
            if (board.Display(nextRecodeCount, getRecodeCount).Rows.Count == 0)
            {
                lbNextbutton.Visible = false;
            }
        }

        /// <summary>
        /// ページング処理の次へボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbNextButton_Click(object sender, EventArgs e)
        {

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
            var url = new UrlCreator(Constants.PATH_BOARD)
                .AddParam(Constants.QUERY_VALUE, count)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// ページング処理の戻るボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbBeforeButton_Click(object sender, EventArgs e)
        {
            var count = Request.QueryString[Constants.QUERY_VALUE];
            count = (int.Parse(count) - 1).ToString();
            var url = new UrlCreator(Constants.PATH_BOARD)
                .AddParam(Constants.QUERY_VALUE, count)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// ユーザIDを基に編集・削除ボタンの表示切替判定メソッド
        /// ボタンに含まれるユーザIDの情報とセッションIDで保持しているユーザIDで比較する
        /// </summary>
        /// <param name="buttonCommandName">ボタンに設定したuserID</param>
        /// <returns>ユーザIDが一致したらtrue、一致しなければfalse</returns>
        private bool JudgeDisplayButton(string buttonCommandName)
        {
            /// <summary>掲示板サービスクラス</summary>
            var board = new BoardTable();
            var userID = board.GetByField( buttonCommandName, Constants.FIELD_BOARD_USER_ID);
            var nowUserID = session.Current.userID;
            if (userID.Equals(nowUserID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ログアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbLogoutButton_Click(object sender, EventArgs e)
        {
            session.Current.userID = "";
            Response.Redirect(Constants.PATH_LOGIN);
        }

        /// <summary>
        /// スレの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bDeleteArticlButton_Click(object sender, EventArgs e)
        {
            /// <summary>掲示板サービスクラス</summary>
            var board = new BoardTable();
            var articlID = ((Button)sender).CommandName;
            board.Delete(articlID);
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// スレの編集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bToEditArticlPageButton_Click(object sender, EventArgs e)
        {
            var articlID = ((Button)sender).CommandName;
            var url = new UrlCreator(Constants.PATH_EDIT_ARTICL)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .CreateUrl();
            Response.Redirect(url);
        }

        /// <summary>
        /// スレの投稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbArticlInsertButton_Click(object sender, EventArgs e)
        {
            /// <summary>掲示板サービスクラス</summary>
            var board = new BoardTable();
            var title = tbTitel.Text.Trim();
            var contents = tbContents.Text.Trim();
            var articlID = common.CreateRandomId(10, Constants.TABLE_BOARD);
            if (!string.IsNullOrEmpty(articlID)
                    && common.CheckCharacterIntegrity(title, 1, 100, false)
                        && common.CheckCharacterIntegrity(contents, 1, 500, false))
            {
                var userID = session.Current.userID;
                var userName = new UserTable().GetByField(userID,Constants.FIELD_USER_USER_NAME);
                //時間の取得
                DateTime dt = DateTime.Now;
                board.Insert(articlID, userID, userName, title, contents);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                pAlertMessage.InnerText = new ErrorMessage().errorMessage;
            }
        }

        /// <summary>
        /// レスをつけるためにそのスレにアクセスできるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbInArticlButton_Click(object sender, EventArgs e)
        {
            var articlID = ((LinkButton)sender).CommandName;
            var url = new UrlCreator(Constants.PATH_IN_ARTICL)
                .AddParam(Constants.QUERY_ARTICLID, articlID)
                .CreateUrl();
            Response.Redirect(url);
        }
    }
}