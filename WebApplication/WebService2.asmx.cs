using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{

	// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
	// [System.Web.Script.Services.ScriptService]
	public partial class WebService : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld2()
		{
			return "Hello World";
		}
		[WebMethod]
		public string Cal2(int no1, int no2)
		{
			return (no1 + no2).ToString();
		}
	}
}
