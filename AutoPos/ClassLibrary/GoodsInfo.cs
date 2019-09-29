using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace AutoPos.ClassLibrary
{
    public class GoodsInfo
    {
        /// <summary>
        /// 取得商品的資訊
        /// </summary>
        /// <returns></returns>
        public Models.GoodsModel.GoodsInfo GetGoodsInfo(string strTag)
        {
            string strUrl = ConfigurationManager.AppSettings["GoodsInfo"].ToString() + "/api/Goods/GetGoods?GoodsName=" + strTag;
            string strResponse = CallAPI(strUrl, "GET", "");
            return JsonConvert.DeserializeObject<Models.GoodsModel.GoodsInfo>(strResponse);
        }

        /// <summary>
        /// 呼叫WebAPI的動作
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strHttpMethod"></param>
        /// <param name="strPostContent"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CallAPI(string strUrl, string strHttpMethod, string strPostContent)
        {
            System.GC.Collect();
            HttpWebRequest request = HttpWebRequest.Create(strUrl) as HttpWebRequest;
            request.Method = strHttpMethod;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (strPostContent != "" && strPostContent != string.Empty)
            {
                request.KeepAlive = false;
                request.ContentType = "application/json; charset=utf-8";

                if (strHttpMethod != "GET")
                {
                    byte[] bs = Encoding.UTF8.GetBytes(strPostContent);
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(bs, 0, bs.Length);
                }
            }

            string strReturn = "";
            try
            {
                if (strUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (var respStream = response.GetResponseStream())
                    {
                        strReturn = new StreamReader(respStream, Encoding.UTF8).ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                strReturn = e.Message;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }

            return strReturn;
        }
    }
}
