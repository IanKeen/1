using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1
{
    public class api
    {
        public async static Task<string> check(string cc, string ccmes, string ccano)
        {
            HttpClient HttpClient = new HttpClient();
            /// CASO PRECISE PEGAR TOKEN DA PAGINA <> 
            /// 
            //string URL = "site";
            //CookieContainer MyCookies = new CookieContainer();
            //HttpWebRequest request = WebRequest.CreateHttp(URL);
            //request.Method = "Get";
            //request.CookieContainer = MyCookies;
            //request.UserAgent = "";
            //WebResponse response = request.GetResponse();
            //Stream Stream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(Stream);
            //string Pagina = reader.ReadToEnd();

            /// FUNÇÃO IMPORTAR COOKIES DO WEBREQUEST PARA HTTPCLIENT
            /// 
            ///HttpClientHandler HttpCLientHandler = new HttpClientHandler();
            // HttpCLientHandler.CookieContainer = MyCookies;
            /// HttpClient HttpClient = new HttpClient(HttpCLientHandler);
            /// 
            /// PEGAR TOKEN 
            /// 
            /// string token = OpaGet(Pagina,"","","");


            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0");
            HttpClient.DefaultRequestHeaders.Add("WWW-Authenticate", "CardAndExpiryDate");
            string UrlPost = "https://www.cibconline.cibc.com/ebm-anp/api/v1/json/sessions";
            string PostData = "{\"card\":{\"value\":\"Setcard\",\"description\":\"\",\"encrypted\":\"false\",\"encrypt\":\"true\"},\"expiryDate\":{\"year\":\"SetYeah\",\"month\":\"SetMont\"},\"txType\":\"REGIST\"}";

            PostData = PostData.Replace("Setcard", cc);
            PostData = PostData.Replace("SetMont", ccmes);
            PostData = PostData.Replace("SetYeah", ccano);
            StringContent Content = new StringContent(PostData, System.Text.Encoding.UTF8, "application/vnd.api+json");
            HttpResponseMessage response = await HttpClient.PostAsync(UrlPost, Content);
            string result = await response.Content.ReadAsStringAsync();


            ///CASO TENHA MAIS POST
            ///UrlPost = "";
            ///PostData = "";
            ///Content = new StringContent(PostData, System.Text.Encoding.UTF8);
            ///response = await HttpClient.PostAsync(UrlPost, Content);
            ///result = await response.Content.ReadAsStringAsync();
            ///

            ///CASO TENHA MAIS POST
            ///UrlPost = "";
            ///PostData = "";
            ///Content = new StringContent(PostData, System.Text.Encoding.UTF8);
            ///response = await HttpClient.PostAsync(UrlPost, Content);
            ///result = await response.Content.ReadAsStringAsync();
            ///

            ///CASO TENHA MAIS POST
            ///UrlPost = "";
            ///PostData = "";
            ///Content = new StringContent(PostData, System.Text.Encoding.UTF8);
            ///response = await HttpClient.PostAsync(UrlPost, Content);
            ///result = await response.Content.ReadAsStringAsync();


            return result;
        }
        public static string OpaGet(string PaginaToken, string _a, string _b, string _c)
        {
            string a = _a;
            string b = _b;
            int c = PaginaToken.IndexOf(a);
            int d = PaginaToken.IndexOf(b, c);
            int es = (d + b.Length);
            int f = PaginaToken.IndexOf(_c, es);
            return PaginaToken.Substring(es, (f - es));
        }
    }
}