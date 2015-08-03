using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace MonoWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("SkypeBox : " + DateTime.Now.ToString("dddd dd MMM yyyy hh:mm:ss.fff") + "<br/>");
            Response.Write("MachineName : " + Environment.MachineName );


            //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var item in host.AddressList )
            //{
            //    Response.Write ( item.ToString() + "<br/>");
            //}
            //Debugger.Break();



        }
    }
}