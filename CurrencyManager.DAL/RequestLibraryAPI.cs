using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyManager.DAL
{
    public class RequestLibraryAPI
    {
        private HttpWebRequest _request;
        public RequestLibraryAPI()
        {
            _request = null;
        }
        public XmlDocument getDataAPI()
        {
            XmlDocument xdoc = new XmlDocument();
            _request = WebRequest.Create("http://www.cbr.ru/scripts/XML_valFull.asp") as HttpWebRequest;

            if (_request != null)
            {
                var response = _request.GetResponse();

                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding("windows-1251"));

                var result = readStream.ReadToEnd();
                xdoc.LoadXml(result);
            }
            return xdoc;
        }
    }
}
