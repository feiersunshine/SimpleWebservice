using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebApplication
{
    /// <summary>
    /// WebServiceForXmlSerialization 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceForXmlSerialization : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string XmlSerail(string headXml, string bodyXml)
        {
            headXml = @"<Root>
                        <MethodCode>GetBloodBagInfo</MethodCode>
                        <ProductCode>PDA</ProductCode>
                        <HospitalCode>01</HospitalCode>
                        <DataFormat>JSON</DataFormat>
                        </Root>";
            bodyXml = @"
                        <Params><Param>
                        <In_Credit_ID></In_Credit_ID>
                        ";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(headXml);
            return "";
        }
    }
}
