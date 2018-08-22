using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Common
{
    public static class XmlHelper
    {
        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (null == encoding)
                throw new ArgumentNullException("encoding");

            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    try
                    {
                        return (T)ser.Deserialize(sr);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 对象转化为XML
        /// </summary>
        /// <param name="sb">stringForXml</param>
        /// <param name="o">object</param>
        public static string GetXmlByObj<T>( T o)
        {
            StringBuilder sb = new StringBuilder();
            Type oType = o.GetType();
            PropertyInfo[] proInfos = oType.GetProperties();
            sb.Append("<Row>");
            foreach (var proInfo in proInfos)
            {
                object obj = proInfo.GetValue(o, null);
                sb.AppendFormat("<{0}>{1}</{0}>", proInfo.Name, obj != null ? obj.ToString() : string.Empty);
            }
            sb.Append("</Row>");
            return sb.ToString();
        }

        /// <summary>
        /// 对象集合转化为XML
        /// </summary>
        /// <param name="sb">stringForXml</param>
        /// <param name="o">object list</param>
        public static string GetXmlByObjList<T>( List<T> oList)
        {
            StringBuilder sb = new StringBuilder();
             oList.ForEach(o=> {
                sb.Append("<Row>");
                Type oType = o.GetType();
                PropertyInfo[] proInfos = oType.GetProperties();
                
                foreach (var proInfo in proInfos)
                {
                    object obj = proInfo.GetValue(o, null);
                    sb.AppendFormat("<{0}>{1}</{0}>", proInfo.Name, obj != null ? obj.ToString() : string.Empty);
                }
                sb.Append("</Row>");
            });
            return sb.ToString();
        }
    }
}
