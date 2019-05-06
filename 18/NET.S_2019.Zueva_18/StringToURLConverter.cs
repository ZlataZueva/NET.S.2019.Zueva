using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S_2019.Zueva_18
{
    /// <summary>
    /// Provides methods to get URLAddress from string
    /// </summary>
    public static class StringToURLConverter
    {
        /// <summary>
        /// Converts string to url-address
        /// </summary>
        /// <param name="urlAddressString">Url-address string</param>
        /// <returns>URLAddress made from specified string</returns>
        public static URLAddress ToURLAddress(this string urlAddressString)
        {
            Uri uri = new Uri(urlAddressString);
            URLAddress urlAddress = new URLAddress(uri.Host, GetSegments(uri.Segments), GetParameters(uri.Query));
            return urlAddress;
        }

        /// <summary>
        /// Makes list of correct segments strings from sequence of strings
        /// </summary>
        /// <param name="segmentsStrings">Sequence of segments strings</param>
        /// <returns>List of segments. Null when there are no segments</returns>
        private static List<string> GetSegments(IEnumerable<string> segmentsStrings)
        {
            List<string> segments = new List<string>();
            if(segmentsStrings == null)
            {
                throw new ArgumentNullException();
            }

            if(segmentsStrings.Count() == 0)
            {
                return null;
            }

            foreach(var segment in segmentsStrings)
            {
                if(segment != "/" && segment != string.Empty)
                {
                    segments.Add(segment.Replace("/", string.Empty));
                }
            }

            return segments;
        }

        /// <summary>
        /// Converts string with parameters to list of Parameters
        /// </summary>
        /// <param name="parametersStrings">String with parameters in format "key=value" divide by '&'</param>
        /// <returns>List of Parameters</returns>
        private static List<URLAddress.Parameter> GetParameters(string parametersString)
        {
            List<URLAddress.Parameter> parameters = new List<URLAddress.Parameter>();
            if(parametersString == null)
            {
                throw new ArgumentNullException();
            }

            if(parametersString == string.Empty)
            {
                return null;
            }

            string[] parametersStrings = parametersString.Split('&');

            foreach(var parameter in parametersStrings)
            {
                if(parameter != string.Empty && parameter.Contains("="))
                {
                    string[] keyvalue = parameter.Split('=');
                    parameters.Add(new URLAddress.Parameter(keyvalue[0], keyvalue[1]));
                }
            }

            return parameters;
        }
    }
}
