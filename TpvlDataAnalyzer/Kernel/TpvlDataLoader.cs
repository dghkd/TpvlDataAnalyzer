using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TpvlDataAnalyzer.Kernel
{
    public class TpvlDataLoader
    {
        #region Private Member

        private const string DefaultUserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0";

        #endregion Private Member

        #region Constructor

        public TpvlDataLoader()
        {
        }

        #endregion Constructor

        #region Public Method

        /// <summary>
        /// 訪問指定的網址，並返回得到的 HTML 文本字串。
        /// </summary>
        /// <param name="url">要訪問的網址。EX: https://www.tpvl.tw/player/player-ranking</param>
        /// <returns>網頁的 HTML 內容字串；如果發生錯誤則返回String.Empty。</returns>
        public string LoadHtmlString(string? url)
        {
            string ret = string.Empty;
            if (string.IsNullOrEmpty(url))
            {
                ret = "輸入的url為空";
                DebugWriteLine(ret, nameof(LoadHtmlString));
                return ret;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", DefaultUserAgent);

                    string htmlContent = client.GetStringAsync(url).Result;

                    ret = htmlContent;
                }
                catch (Exception e)
                {
                    ret = $"訪問網址 {url} 時發生錯誤: {e.Message}";
                    DebugWriteLine(ret, nameof(LoadHtmlString));
                    return ret;
                }
            }

            return ret;
        }

        /// <summary>
        /// 解析 HTML 文本字串，標籤中取出 JSON 資料。
        /// </summary>
        /// <param name="htmlContent">包含目標 JSON 的 HTML 文本字串。</param>
        /// <returns>提取到的 JSON 字串；如果找不到則返回 null。</returns>
        public string ParsePlayersInfoJsonString(string htmlString)
        {
            string ret = string.Empty;
            string methodName = nameof(ParsePlayersInfoJsonString);
            if (string.IsNullOrEmpty(htmlString))
            {
                DebugWriteLine("輸入的html為空", methodName);
                return ret;
            }

            // 定義 JSON 資料的起始標籤和結束標籤
            const string StartTag = "<script id=\"__NEXT_DATA__\" type=\"application/json\">";
            const string EndTag = "</script>";

            // 尋找起始標籤的位置
            int startIndex = htmlString.IndexOf(StartTag);
            if (startIndex == -1)
            {
                DebugWriteLine("錯誤：找不到 <script id=\"__NEXT_DATA__\"...> 的起始標籤。", methodName);
                return ret;
            }

            // 從起始標籤之後的位置開始尋找結束標籤
            startIndex += StartTag.Length;
            int endIndex = htmlString.IndexOf(EndTag, startIndex);

            if (endIndex == -1)
            {
                DebugWriteLine("錯誤：找不到 </script> 的結束標籤。", methodName);
                return ret;
            }

            // 使用 Substring 提取介於起始和結束標籤之間的內容 (即 JSON 字串)
            string jsonString = htmlString.Substring(startIndex, endIndex - startIndex);

            // 返回修剪過空白字元的 JSON 字串
            ret = jsonString.Trim();

            return ret;
        }

        #endregion Public Method

        #region Private Method

        private void DebugWriteLine(string msg, string methodName)
        {
            string log = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}] [TpvlDataLoader] [{methodName}] {msg}";

            Debug.WriteLine(log);
        }

        #endregion Private Method
    }
}