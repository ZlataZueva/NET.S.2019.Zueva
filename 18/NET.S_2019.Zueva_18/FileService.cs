using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NET.S_2019.Zueva_18
{
    /// <summary>
    /// Provides methods for reading url-addresses strings from file and writing xml-document
    /// </summary>
    class FileService
    {
        /// <summary>
        /// Saves string mismatch to expected type.
        /// </summary>
        private static Logger logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static XDocument ReadURLAddressesFromFile(string path)
        {
            logger = LogManager.GetCurrentClassLogger();
            if (path == null)
            {
                logger.Error("Specified file path is null.");
                throw new ArgumentNullException();
            }

            IEnumerable<string> lines = File.ReadLines(path);

            if(lines.Count() == 0)
            {
                logger.Info("File is empty.");
                return null;
            }

            List<URLAddress> urlAddresses = new List<URLAddress>();
            foreach (var line in lines)
            {
                try
                {
                    URLAddress urlAddress = line.ToURLAddress();
                    urlAddresses.Add(urlAddress);
                }
                catch
                {
                    logger.Error("Line: " + line + " doesn't match url-address pattern");
                }
            }
            
            if(urlAddresses.Count == 0)
            {
                logger.Info("No matches of url-address pattern found in the file.");
                return null;
            }

            return URLAddresstoXML.GetXmlUrlAddresses(urlAddresses);
        }

        /// <summary>
        /// Writes xml-document with sequence of url-addresses to file
        /// </summary>
        /// <param name="urlAddressesStrings">Sequence of url-addresses to be added to xml-document</param>
        /// <param name="writePath">Path of file to save xml-document</param>
        public static void WriteXDocumentWithUrlAddresses(IEnumerable<string> urlAddressesStrings, string writePath)
        {
            logger = LogManager.GetCurrentClassLogger();

            if (urlAddressesStrings.Count() == 0)
            {
                logger.Info("No url-addresses to create xml-document.");
                return;
            }

            List<URLAddress> urlAddresses = new List<URLAddress>();
            foreach(var url in urlAddressesStrings)
            {
                try
                {
                    URLAddress urlAddress = url.ToURLAddress();
                    urlAddresses.Add(urlAddress);
                }
                catch
                {
                    logger.Error("String: " + url + " doesn't match url-address pattern");
                }
            }

            if (urlAddresses.Count == 0)
            {
                logger.Info("No matches of url-address pattern found in strings sequence.");
                return;
            }

            XDocument document = URLAddresstoXML.GetXmlUrlAddresses(urlAddresses);
            if (writePath == null)
            {
                logger.Error("Specified file path is null.");
                throw new ArgumentNullException();
            }
            document.Save(writePath);
        }
    }
}
