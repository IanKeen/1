using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [System.Web.Services.WebMethod]
        public async static Task<string> BuscaCliente(string cc)
        {
            string[] line;
            line = cc.Split('|');
            string ano = line[2];
            if (ano.Count().ToString() == "4")
            {
                ano = ano.Substring(2, 2);
            }
            var result = Task.Run(() => api.check(line[0], line[1], ano)).Result;
            if (result.Contains("problems"))
            {
                return "<span class=\"label label-danger\">#Reprovada ❌</span> " + cc +  " #GiovaneVoltouEMereceUmaChupada <br/>";
            }
            else if (result.Contains("transactionId"))
            {
                return "<span class=\"label label-success\">#Aprovada ✅</span> " + cc + " #GiovaneVoltouEMereceUmaChupada <br/>";
            }
            return "";

        }
       
      

    }
}
