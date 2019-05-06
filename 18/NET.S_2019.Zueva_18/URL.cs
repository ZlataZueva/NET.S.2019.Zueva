using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S_2019.Zueva_18
{
    /// <summary>
    /// Describes url-address parts
    /// </summary>
    public class URLAddress
    {
        /// <summary>
        /// Describes parameter of url-address with specified key and value
        /// </summary>
        public struct Parameter
        {
            public string key;
            public string value;

            /// <summary>
            /// Initializes instance of Parameter with specified key and value
            /// </summary>
            /// <param name="key">Key of parameter</param>
            /// <param name="value">Value of parameter</param>
            public Parameter(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private string host;
        private IEnumerable<string> segments;
        private IEnumerable<Parameter> parameters;

        /// <summary>
        /// Gets or sets host name 
        /// </summary>
        public string Host { get => host; private set => host = value; }

        /// <summary>
        /// Gets or sets sequence of segments, returns null when url-address doesn't contain segments 
        /// </summary>
        public IEnumerable<string> Segments { get => segments; private set => segments = value;
        }

        /// <summary>
        /// Gets or sets sequence of Parameters, returns null when url-address doesn't contain parameters
        /// </summary>
        public IEnumerable<Parameter> Parameters { get => parameters; private set => parameters = value; }

        /// <summary>
        /// Initializes instance of URLAddress with specified host name, segments sequence and parameters
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="segments">Sequence of segments strings</param>
        /// <param name="parameters">Sequence of parameters</param>
        public URLAddress(string host, IEnumerable<string> segments=null, IEnumerable<Parameter> parameters=null)
        {
            this.Host = host;
            this.Segments = segments;
            this.Parameters = parameters;
        }
    }
}
