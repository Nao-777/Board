using System.Configuration;

namespace application
{
    /// <summary>
    /// アプリケーション側の定数定義クラス
    /// </summary>
    public class Constants
    {
        //CommonMethod.csでIDを作成する際に使う英数字の文字列
        public const string ALPHA_NUMERAL = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        /// <summary>接続文字列</summary>
        public string CONNECTION_STR = ConfigurationManager.AppSettings["ConnectionString"];

        //クエリ文字列名
        /// <summary>articlID(クエリ文字列)</summary>
        public const string QUERY_ARTICLID = "articlID";
        /// <summary>value(クエリ文字列)</summary>
        public const string QUERY_VALUE = "value";
        /// <summary>messageID(クエリ文字列)</summary>
        public const string QUERY_MESSAGE = "messageID";
        /// <summary>userName(クエリ文字列)</summary>
        public const string QUERY_USER_NAME = "userName";
        /// <summary>loginID(クエリ文字列)</summary>
        public const string QUERY_USER_LOGINID = "loginID";
        /// <summary>userPassword(クエリ文字列)</summary>
        public const string QUERY_USER_PASSWORD = "userPassword";

        //テーブル名
        /// <summary>dbo.UserInfomationテーブル</summary>
        public const string TABLE_USER = "[dbo].[UserInfomation]";
        /// <summary>dbo.TABLE_BULLETINBOARDテーブル</summary>
        public const string TABLE_BOARD = "[dbo].[TABLE_BULLETINBOARD]";
        /// <summary>dbo.TABL_IN_ARTICLテーブル</summary>
        public const string TABLE_INARTICL = "[dbo].[TABL_IN_ARTICL]";

        //テーブル[dbo].[Userinfomation]
        /// <summary>ユーザID</summary>
        public static string FIELD_USER_USER_ID = "userID";
        /// <summary>ログインID</summary>
        public const string FIELD_USER_LOGIN_ID = "loginID";
        /// <summary>ユーザ名</summary>
        public const string FIELD_USER_USER_NAME = "userName";
        /// <summary>パスワード</summary>
        public const string FIELD_USER_USER_PASSWORD = "userPassword";

        //テーブル[dbo].[TABLE_BULLETINBOARD]
        /// <summary>スレのID</summary>
        public static string FIELD_BOARD_ARTICL_ID = "articlID";
        /// <summary>ユーザID</summary>
        public static string FIELD_BOARD_USER_ID = "userId";
        /// <summary>ユーザ名</summary>
        public static string FIELD_BOARD_USER_NAME = "userName";
        /// <summary>スレのタイトル</summary>
        public static string FIELD_BOARD_ARTICL_TITLE = "articlTitle";
        /// <summary>スレの内容</summary>
        public static string FIELD_BOARD_ARTICL_CONTENTS = "articlContents";
        /// <summary>投稿日時</summary>
        public static string FIELD_BOARD_DAYS = "days";

        //テーブル[dbo].[TABL_IN_ARTICL]
        /// <summary>レスのID</summary>
        public static string FIELD_IN_ARTICL_MESSAGE_ID = "messageID";
        /// <summary>スレのID</summary>
        public static string FIELD_IN_ARTICL_ARTICL_ID = "articlID";
        /// <summary>ユーザID</summary>
        public static string FIELD_IN_ARTICL_USER_ID = "userID";
        /// <summary>ユーザ名</summary>
        public static string FIELD_IN_ARTICL_USER_NAME = "userName";
        /// <summary>レスの内容</summary>
        public static string FIELD_IN_ARTICL_USER_MESSAGE = "userMessage";
        /// <summary>レスした日付</summary>
        public static string FIELD_IN_ARTICL_DAYS = "days";
        /// <summary>ページング処理の際、データを表示する件数</summary>
        public static string FIELD_BOARD_GET_RECODE_COUNT = "getRecodeCount";
        /// <summary>ページング処理の際、データをスキップする件数</summary>
        public static string FIELD_BOARD_SKIP_RECODE_COUNT = "skipRecodeCount";

        //各ページ
        /// <summary>Login.aspx(ログインページ)</summary>
        public const string PAGE_LOGIN = "Login.aspx";
        /// <summary>Logout.aspx(ログアウトページ)</summary>
        public const string PAGE_LOGOUT = "Logout.aspx";
        /// <summary>NewRegistration.aspx(新規登録ページ)</summary>
        public const string PAGE_INPUT_FORM = "NewRegistration.aspx";
        /// <summary>NewRegistrationConfirmation.aspx(新規登録確認画面)</summary>
        public const string PAGE_INPUT_FORM_CONFIRMATION = "NewRegistrationConfirmation.aspx";
        /// <summary>InArticlPage.aspx(スレの中)</summary>
        public const string PAGE_ARTICL = "InArticlPage.aspx";
        /// <summary>BulletinBoardPage.aspx(掲示板トップ)</summary>
        public const string PAGE_BOARD = "BulletinBoardPage.aspx";
        /// <summary>ArticlEdition.aspx(スレの編集画面)</summary>
        public const string PAGE_ARTICL_EDIT = "ArticlEdition.aspx";
        /// <summary>MyPage.aspx(マイページ画面)</summary>
        public const string PAGE_MYPAGE = "MyPage.aspx";
        /// <summary>DeleteUserInformationPage.aspx(ユーザ情報削除ページ)</summary>
        public const string PAGE_USER_INFORMATION_DELETE = "DeleteUserInformationPage.aspx";
        /// <summary>RevisedUserInfomation.aspx(ユーザ情報編集ページ)</summary>
        public const string PAGE_USER_INFORMATION_EDIT = "RevisedUserInfomation.aspx";
        /// <summary>RevisedConfirmationPage.aspx(ユーザ情報編集確認ページ)</summary>
        public const string PAGE_USER_INFORMATION_EDIT_CONFIRMATION = "RevisedConfirmationPage.aspx";
        /// <summary>ResEdit.aspx(メッセージの編集画面)</summary>
        public const string PAGE_MESSAGE_EDIT = "ResEdit.aspx";

        //ファイル
        /// <summary>BulletinBoard(ファイル名)</summary>
        public const string FILE_BOARD = "WebSite";
        /// <summary>Form(ファイル名)</summary>
        public const string FILE_FORM = "Form";
        /// <summary>MainPage(ファイル名)</summary>
        public const string FILE_MAIN_PAGE = "MainPage";
        /// <summary>User(ファイル名)</summary>
        public const string FILE_USER = "User";
        /// <summary>ArticlPage(ファイル名)</summary>
        public const string FILE_ARTICL = "ArticlPage";
        /// <summary>DeleteUserInformation(ファイル名)</summary>
        public const string FILE_USER_INFORMATION_DELETE = "DeleteUserInformation";
        /// <summary>RevisedUserInfomationPage(ファイル名)</summary>
        public const string FILE_USER_INFORMATION_EDIT = "RevisedUserInfomationPage";

        //各ページの遷移パス
        /// <summary>BulletinBoard/MainPage/BulletinBoardPage.aspx(パス)</summary>
        public static string PATH_BOARD = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_MAIN_PAGE, PAGE_BOARD);
        /// <summary>BulletinBoard/Form/Logout.aspx(パス)</summary>
        public static string PATH_LOGOUT = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_FORM, PAGE_LOGOUT);
        /// <summary>BulletinBoard/Form/Login.aspx(パス)</summary>
        public static string PATH_LOGIN = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_FORM, PAGE_LOGIN);
        /// <summary>BulletinBoard/Form/NewRegistration.aspx(パス)</summary>
        public static string PATH_NEWREGISTRATION = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_FORM, PAGE_INPUT_FORM);
        /// <summary>BulletinBoard/Form/NewRegistrationConfirmation.aspx(パス)</summary>
        public static string PATH_NEWREGISTRATION_CONFIRMATION = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_FORM, PAGE_INPUT_FORM_CONFIRMATION);
        /// <summary>BulletinBoard/MainPage/ArticlPage/InArticlPage.aspx(パス)</summary>
        public static string PATH_IN_ARTICL = string.Format("~/{0}/{1}/{2}/{3}", FILE_BOARD, FILE_MAIN_PAGE, FILE_ARTICL, PAGE_ARTICL);
        /// <summary>BulletinBoard/MainPage/RevisedUserInfomation.aspx(パス)</summary>
        public static string PATH_EDIT_ARTICL = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_MAIN_PAGE, PAGE_ARTICL_EDIT);
        /// <summary>BulletinBoard/User/MyPage.aspx(パス)</summary>
        public static string PATH_MYPAGE = string.Format("~/{0}/{1}/{2}", FILE_BOARD, FILE_USER, PAGE_MYPAGE);
        /// <summary>BulletinBoard/User/RevisedUserInfomationPage/RevisedConfirmationPage.aspx(パス)</summary>
        public static string PATH_EDIT_USER_INFORMATION_CONFIRMATION = string.Format("~/{0}/{1}/{2}/{3}", FILE_BOARD, FILE_USER, FILE_USER_INFORMATION_EDIT, PAGE_USER_INFORMATION_EDIT_CONFIRMATION);
    }
}