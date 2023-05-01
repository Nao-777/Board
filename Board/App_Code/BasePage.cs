using application;
using System;

/// <summary>
/// BasePage の概要の説明です
/// </summary>
public abstract class BasePage : System.Web.UI.Page
{
    /// <summary>
    /// ページ初期化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        if (this.JudgeLogin) LoginUser();
    }

    /// <summary>
    /// ログイン処理
    /// </summary>
    protected void LoginUser()
    {
        //ログアウトページに飛ぶ
        if (string.IsNullOrEmpty(new SessionManager().Current.userID)) Response.Redirect(Constants.PATH_LOGOUT);
    }
    /// <summary>セッション変数の中身の有無(ログインのセッションの確認がない場合はfalse)</summary>
    protected virtual bool JudgeLogin { get { return true; } }
}