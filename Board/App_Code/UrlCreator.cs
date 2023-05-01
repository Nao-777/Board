using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace application
{
    
    /// <summary>
    /// 指定したURLとクエリ文字列連結させ、新たにページを作成する
    /// </summary>
    public class UrlCreator
    {
        NameValueCollection urlQuery = HttpUtility.ParseQueryString("");
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pathName">遷移したいファイルのパスを指定</param>
        public UrlCreator(string pathName)
        {
            this.pathName = pathName;
            this.Parameters = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// URLパラメーターを追加するメソッド
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="queryValue"></param>
        /// <returns>インスタンスを返す（メソッドチェーンを使用するため）</returns>
        public UrlCreator AddParam(string queryName, string queryValue)
        {
            this.Parameters.Add(new KeyValuePair<string, string>(queryName, queryValue));
            return this;
        }

        /// <summary>
        /// URLを作成する
        /// </summary>
        /// <returns>クエリ文字列が連結されたURL</returns>
        public string CreateUrl()
        {
            foreach (var v in Parameters)
            {
                SetParams(v.Key, v.Value);
            }
            var url = string.Format("{0}?{1}", pathName, urlQuery);
            return url;
        }

        /// <summary>
        /// クエリ文字列を作成
        /// </summary>
        /// <param name="queryName">クエリ文字列の名前</param>
        /// <param name="valueName">クエリ文字列の値</param>
        private void SetParams(string queryName, string valueName)
        {
            this.urlQuery.Add(queryName, valueName);
        }

        /// <summary>クエリ文字列を作成したいURL</summary>
        private string pathName { get; set; }
        /// <summary>パラメータリスト</summary>
        private List<KeyValuePair<string, string>> Parameters { get; set; }
    }
}