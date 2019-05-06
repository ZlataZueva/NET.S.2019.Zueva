using System;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NET.S_2019.Zueva_18
{
    /// <summary>
    /// Provides methods to get XML-Document from sequence of URL-addresses
    /// </summary>
    public static class URLAddresstoXML
    {
        /// <summary>
        /// Converts sequence of URLAddresses to XDocument
        /// </summary>
        /// <param name="urlAddresses">Sequence of url-addresses to add to xml-document</param>
        /// <returns>Xml-document with parsed sequence of url-addresses</returns>
        public static XDocument GetXmlUrlAddresses(IEnumerable<URLAddress> urlAddresses)
        {
            XDocument document = new XDocument();
            document.Add(new XDeclaration("1.0", "utf-8", "yes"));
            document.Add(CreateUrlAddressesElement(urlAddresses));
            return document;
        }

        /// <summary>
        /// Creates root xml-element for sequence of url-addresses
        /// </summary>
        /// <param name="urlAddresses">Sequence of url-addresses to include in created element</param>
        /// <returns>Xml-element urlAddresses with specified sequence of url-addresses as child elements</returns>
        static private XElement CreateUrlAddressesElement (IEnumerable<URLAddress> urlAddresses)
        {
            if(urlAddresses == null)
            {
                throw new ArgumentNullException();
            }

            //string[] urls = urlAddresses.Split(new string[] {"/r/n"}, StringSplitOptions.RemoveEmptyEntries);
            XElement urlAddressesElement = new XElement("urlAddresses");
            foreach(var url in urlAddresses)
            {
                urlAddressesElement.Add(CreateUrlAddressElement(url));
            }
            return urlAddressesElement;
        }

        /// <summary>
        /// Creates xml-element for url-address
        /// </summary>
        /// <param name="url">Url-address to be converted to xml-element</param>
        /// <returns>Xml-element urlAddress with specified structure</returns>
        static private XElement CreateUrlAddressElement(URLAddress url)
        {
            XElement urlAddress = new XElement("urlAddress");
            urlAddress.Add(CreateHostElement(url.Host));
            if (url.Segments != null)
            {
                urlAddress.Add(CreateUriElement(url.Segments));
            }
            if (url.Parameters != null)
            {
                urlAddress.Add(CreateParametresElement(url.Parameters));
            }

            return urlAddress;
        }

        /// <summary>
        /// Creates xml-element of host
        /// </summary>
        /// <param name="hostName">Host name</param>
        /// <returns>Xml-element host with attribute name with specified value hostName</returns>
        static private XElement CreateHostElement(string hostName)
        {
            XElement host = new XElement("host");
            host.Add(new XAttribute("name", hostName));
            return host;
        }

        /// <summary>
        /// Creates xml-element of uri with specified sequence of segments elements
        /// </summary>
        /// <param name="segments">Sequence of segments to be included in uri</param>
        /// <returns>Xml-element uri with included sequence of segment xml-elements</returns>
        static private XElement CreateUriElement(IEnumerable<string> segments)
        {
            XElement uri = new XElement("uri");
            foreach (var segment in segments)
            {
                if (segment != string.Empty)
                {
                    uri.Add(CreateSegmentElement(segment));
                }        
            }
            return uri;
        }

        /// <summary>
        /// Creates xml-element of urls segment
        /// </summary>
        /// <param name="segmentContent">Name of segment</param>
        /// <returns>Xml-element segment with specified content</returns>
        static private XElement CreateSegmentElement(string segmentContent)
        {
            XElement segment = new XElement("segment");
            segment.Add(new XText(segmentContent));
            return segment;
        }

        /// <summary>
        /// Creates xml-element for parameters
        /// </summary>
        /// <param name="parameters">Sequence of Parameters to be included into element</param>
        /// <returns>Xml-element parameters with sequence of specified paramter xml-elements</returns>
        static private XElement CreateParametresElement(IEnumerable<URLAddress.Parameter> parameters)
        {
            XElement parametresElement = new XElement("parametres");
            foreach (var parameter in parameters)
            {
                parametresElement.Add(CreateParametrElement(parameter));
            }
            return parametresElement;
        }

        /// <summary>
        /// Creates xml-element of parameter
        /// </summary>
        /// <param name="parameter">Parameter with specified key and value</param>
        /// <returns>Xml-element parameter with attributes key and value of specified values</returns>
        static private XElement CreateParametrElement(URLAddress.Parameter parameter)
        {
            XElement parameterElement = new XElement("parametr");
            parameterElement.Add(new XAttribute("key", parameter.key));
            parameterElement.Add(new XAttribute("value", parameter.value));
            return parameterElement;
        }
    }
}
