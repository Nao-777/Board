using System.Web;

namespace application
{
    
    /// <summary>
    /// 今取得しているセッションIDを保持する
    /// セッション変数はuserIDしかありません
    /// </summary>
    public class SessionManager
    {
        public SessionManager Current
        {
            get
            {
                var session = (SessionManager)HttpContext.Current.Session["__SessionManager__"];
                if (session == null)
                {
                    session = new SessionManager();
                    HttpContext.Current.Session["__SessionManager__"] = session;
                }
                //セッションID保有時間
                HttpContext.Current.Session.Timeout = 10;
                return session;
            }
        }

        /// <summary>ユーザIDをログインセッションとして、ここで保持</summary>
        public string userID { get; set; }
    }
}