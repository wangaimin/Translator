using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Translator
{
    public static class TranstalorHelper
    {
        public static readonly string BingUrl = "https://www.bing.com/translator/api/Translate/TranslateArray?from=zh-CHS&to=en";
        public static readonly string YouDaoUrl = "http://fanyi.youdao.com/translate_o?smartresult=dict&smartresult=rule&sessionFrom=dict2.index";
        //  public static AdmAuthentication admAuth = new AdmAuthentication("gene_translator", "0BasbK6G/g7uI+2mnLHmDu99Ssvm9at+CRAX0iRdC84=");


        #region Bing

        public static string TranstaleByBing(string content,string cookie,bool isList=false)
        {
            if (string.IsNullOrEmpty(content))
            {
                return "";
            }
            string str = isList?content : "[{'id':-17855184818,'text':'" + content + "'}]";

            var data = Encoding.UTF8.GetBytes(str);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BingUrl);
            request.Method = "post";
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Host = "www.bing.com";
            request.Referer = "https://www.bing.com/translator/";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            request.ContentLength = data.Length;
         //   request.Headers.Set(HttpRequestHeader.Cookie, "mtstkn=qrTq18UUfmnO4GVVJlBKAx8d%2Fmp5rW999xEPJvsxWCqDR4jjQMzXiGPgOBmg%2FrJB; MicrosoftApplicationsTelemetryDeviceId=0081d937-6cf7-f3bb-8398-b2c23030c717; MicrosoftApplicationsTelemetryFirstLaunchTime=1495614721546; srcLang=zh-CHS; destLang=en; smru_list=zh-CHS; dmru_list=en; sourceDia=zh-CN; destDia=en-US; MUID=2AE378DFAA9169B60968712EAE916ADB; MUIDB=2AE378DFAA9169B60968712EAE916ADB; SRCHD=AF=NOFORM; SRCHUID=V=2&GUID=9AC1DE3A8B9642FD8DE23467513312F3; SRCHUSR=DOB=20170524; _EDGE_S=SID=215B5AE5D0826A2C2AB55069D1236BF9; WLS=TS=63631213101; _SS=SID=215B5AE5D0826A2C2AB55069D1236BF9");
            request.Headers.Set(HttpRequestHeader.Cookie, cookie);


            //Accept:application/json, text/javascript, */*; q=0.01
            //Accept - Encoding:gzip, deflate, br
            //Accept - Language:en - US,en; q = 0.8,zh - CN; q = 0.6,zh; q = 0.4
            //Authorization:Basic cG9zdG1hbjpwYXNzd29yZA==
            //Host:www.bing.com
            //Origin:https://www.bing.com
            //Referer:https://www.bing.com/translator/Content - Type:application / json; charset = UTF - 8
            //User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36
            //Cookie:mtstkn=qrTq18UUfmnO4GVVJlBKAx8d%2Fmp5rW999xEPJvsxWCqDR4jjQMzXiGPgOBmg%2FrJB; MicrosoftApplicationsTelemetryDeviceId=0081d937-6cf7-f3bb-8398-b2c23030c717; MicrosoftApplicationsTelemetryFirstLaunchTime=1495614721546; srcLang=zh-CHS; destLang=en; smru_list=zh-CHS; dmru_list=en; sourceDia=zh-CN; destDia=en-US; MUID=2AE378DFAA9169B60968712EAE916ADB; MUIDB=2AE378DFAA9169B60968712EAE916ADB; SRCHD=AF=NOFORM; SRCHUID=V=2&GUID=9AC1DE3A8B9642FD8DE23467513312F3; SRCHUSR=DOB=20170524; _EDGE_S=SID=215B5AE5D0826A2C2AB55069D1236BF9; WLS=TS=63631213101; _SS=SID=215B5AE5D0826A2C2AB55069D1236BF9
            //X-Requested-With:XMLHttpRequest


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }

        //public static string TranstalorByBing(string content)
        //{

        //    AdmAuthentication admAuth = new AdmAuthentication("gene_translator", "0BasbK6G/g7uI+2mnLHmDu99Ssvm9at+CRAX0iRdC84=");

        //    AdmAccessToken admToken=admAuth.GetAccessToken();

        //    string text = content;
        //    string from = "zh-CHS";
        //    string to = "en";
        //    string authToken = "Bearer" + " " + admToken.access_token;

        //    string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;


        //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        //    httpWebRequest.Headers.Add("Authorization", authToken);

        //    var response = (HttpWebResponse)httpWebRequest.GetResponse();
        //    var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    return result;

        //    //WebResponse response = null;
        //    //try
        //    //{
        //    //    response = httpWebRequest.GetResponse();
        //    //    using (Stream stream = response.GetResponseStream())
        //    //    {
        //    //        System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
        //    //        string translation = (string)dcs.ReadObject(stream);
        //    //        Console.WriteLine("Translation for source text '{0}' from {1} to {2} is", text, "en", "de");
        //    //        Console.WriteLine(translation);
        //    //    }
        //    //}


        //    //var data = Encoding.UTF8.GetBytes("[{'id':-17855184818,'text':'我是中学生'}]");

        //    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BingUrl);
        //    //request.Method = "post";
        //    //request.ContentType = "application/json; charset=UTF-8";
        //    //request.Accept = "application/json, text/javascript, */*; q=0.01";
        //    //request.Host = "www.bing.com";
        //    //request.Referer = "https://www.bing.com/translator/";
        //    //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
        //    //request.ContentLength = data.Length;

        //    //Accept:application/json, text/javascript, */*; q=0.01
        //    //Accept - Encoding:gzip, deflate, br
        //    //Accept - Language:en - US,en; q = 0.8,zh - CN; q = 0.6,zh; q = 0.4
        //    //Authorization:Basic cG9zdG1hbjpwYXNzd29yZA==
        //    //Host:www.bing.com
        //    //Origin:https://www.bing.com
        //    //Referer:https://www.bing.com/translator/Content - Type:application / json; charset = UTF - 8
        //    //User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36
        //    //Cookie:mtstkn=qrTq18UUfmnO4GVVJlBKAx8d%2Fmp5rW999xEPJvsxWCqDR4jjQMzXiGPgOBmg%2FrJB; MicrosoftApplicationsTelemetryDeviceId=0081d937-6cf7-f3bb-8398-b2c23030c717; MicrosoftApplicationsTelemetryFirstLaunchTime=1495614721546; srcLang=zh-CHS; destLang=en; smru_list=zh-CHS; dmru_list=en; sourceDia=zh-CN; destDia=en-US; MUID=2AE378DFAA9169B60968712EAE916ADB; MUIDB=2AE378DFAA9169B60968712EAE916ADB; SRCHD=AF=NOFORM; SRCHUID=V=2&GUID=9AC1DE3A8B9642FD8DE23467513312F3; SRCHUSR=DOB=20170524; _EDGE_S=SID=215B5AE5D0826A2C2AB55069D1236BF9; WLS=TS=63631213101; _SS=SID=215B5AE5D0826A2C2AB55069D1236BF9
        //    //X-Requested-With:XMLHttpRequest


        //    ////using (var stream = request.GetRequestStream())
        //    ////{
        //    ////    stream.Write(data, 0, data.Length);
        //    ////}

        //}

        public static string MD5(string Password, int Length)
        {

            if (Length != 16 && Length != 32) throw new System.ArgumentException("Length参数无效,只能为16位或32位");
            System.Security.Cryptography.MD5CryptoServiceProvider MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] b = MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            System.Text.StringBuilder StrB = new System.Text.StringBuilder();
            for (int i = 0; i < b.Length; i++)
                StrB.Append(b[i].ToString("x").PadLeft(2, '0'));

            if (Length == 16)
                return StrB.ToString(8, 16);
            else
                return StrB.ToString();

        }

        #endregion

        #region YouDao
        //public static string TranstalorByYouDao(string content)
        //{

        //    string str = string.Format("i={0}&from=zh-CHS&to=en&smartresult=dict&client=fanyideskweb&salt=1495682363661&sign= e28c72fce0152d1586f33dd7923a9581&doctype=json&version=2.1&keyfrom= fanyi.web&action=FY_BY_CLICKBUTTON&typoResult=true"
        //        , content);

        //    var data = Encoding.UTF8.GetBytes(str);

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(YouDaoUrl);
        //    request.Method = "post";
        //    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    var response = (HttpWebResponse)request.GetResponse();
        //    var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    return result;


        //    //{"translateResult":[[{"tgt":"I love you, China","src":"我爱你，中国"}]],"errorCode":0,"type":"zh-CHS2en","smartResult":{"entries":["","I Love You, China\n","","  \r\n"],"type":1}}
        //}


        public static string TranstaleByYouDaoAPI(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return "";
            }
            string url = "http://openapi.youdao.com/api?q={0}&from={1}&to={2}&appKey={3}&salt={4}&sign={5}";

            string appKey = "5c11890b3dee46be";
            string query = content;
            string salt = DateTime.Now.ToString("yyMMddhhmmss");
            string from = "en";
            string to = "zh_CHS";
            string sign = MD5(appKey + query + salt + "eQXO5SVoMBqUKpjW2K2M2UZU4GPBk1H6", 32);

            url = string.Format(url,
                //  HttpUtility.UrlEncode(query,Encoding.UTF8), 
                query,

                HttpUtility.UrlEncode(from, Encoding.UTF8),
                HttpUtility.UrlEncode(to, Encoding.UTF8),
                HttpUtility.UrlEncode(appKey, Encoding.UTF8),
                salt,
                HttpUtility.UrlEncode(sign, Encoding.UTF8));

            // var data = Encoding.UTF8.GetBytes(str);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            // using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}
            var response = (HttpWebResponse)request.GetResponse();
            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;


           // { "tSpeakUrl":"https://dict.youdao.com/dictvoice?audio=You+are+my+little+apple&le=auto&channel=5c11890b3dee46be&rate=4","query":"你是我的小苹果","translation":["You are my little apple"],"errorCode":"0","basic":{"explains":["You are my little apple."]},"speakUrl":"https://dict.youdao.com/dictvoice?audio=%E4%BD%A0%E6%98%AF%E6%88%91%E7%9A%84%E5%B0%8F%E8%8B%B9%E6%9E%9C&le=auto&channel=5c11890b3dee46be&rate=4"}

        }
        #endregion

        #region Google

        public static string TranstaleByGoogle(string content) {

            string url = "https://translate.google.cn/translate_a/single?client=t&sl=zh-CN&tl=en&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&ssel=5&tsel=5&kc=1&tk=527766.940647&q={0}";
            url = string.Format(url,HttpUtility.UrlEncode(content,Encoding.UTF8));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
            request.Headers.Set(HttpRequestHeader.Cookie, "NID=93=KPxug3wVLGwlnJ1gWVZhjMwNNbpjU2xrPs8TsMQuPHJdts5urrtWIZaJu9CYI_bcApsJqLvOJwN45QZ9h38waxHkp8zHS9EHc4eNHxWqwp4ERGTtbsrSQmQ714-ec57-; _ga=GA1.3.646239565.1482287309; _gid=GA1.3.2036920130.1496627750");
            var response = (HttpWebResponse)request.GetResponse();
            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }

        #endregion
    }


    //public class AdmAuthentication
    //{
    //    public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
    //    private string clientId;
    //    private string clientSecret;
    //    private string request;
    //    private AdmAccessToken token;
    //    private Timer accessTokenRenewer;
    //    //Access token expires every 10 minutes. Renew it every 9 minutes only.
    //    private const int RefreshTokenDuration = 9;
    //    public AdmAuthentication(string clientId, string clientSecret)
    //    {
    //        this.clientId = clientId;
    //        this.clientSecret = clientSecret;
    //        //If clientid or client secret has special characters, encode before sending request
    //        this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
    //        this.token = HttpPost(DatamarketAccessUri, this.request);
    //        //renew the token every specfied minutes
    //        accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback), this, TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
    //    }
    //    public AdmAccessToken GetAccessToken()
    //    {
    //        return this.token;
    //    }
    //    private void RenewAccessToken()
    //    {
    //        AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
    //        //swap the new token with old one
    //        //Note: the swap is thread unsafe
    //        this.token = newAccessToken;
    //        Console.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
    //    }
    //    private void OnTokenExpiredCallback(object stateInfo)
    //    {
    //        try
    //        {
    //            RenewAccessToken();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
    //        }
    //        finally
    //        {
    //            try
    //            {
    //                accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
    //            }
    //        }
    //    }



    //    private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
    //    {
    //        //Prepare OAuth request 
    //        WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
    //        webRequest.ContentType = "application/x-www-form-urlencoded";
    //        webRequest.Method = "POST";
    //        byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
    //        webRequest.ContentLength = bytes.Length;
    //        using (Stream outputStream = webRequest.GetRequestStream())
    //        {
    //            outputStream.Write(bytes, 0, bytes.Length);
    //        }
    //        using (WebResponse webResponse = webRequest.GetResponse())
    //        {
    //            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
    //            //Get deserialized object from JSON stream
    //            AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
    //            return token;
    //        }
    //    }

    //}



    //[DataContract]
    //public class AdmAccessToken
    //{
    //    [DataMember]
    //    public string access_token { get; set; }
    //    [DataMember]
    //    public string token_type { get; set; }
    //    [DataMember]
    //    public string expires_in { get; set; }
    //    [DataMember]
    //    public string scope { get; set; }
    //}
}
