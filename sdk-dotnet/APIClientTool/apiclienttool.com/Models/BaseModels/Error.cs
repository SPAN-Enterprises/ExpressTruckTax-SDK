using System.Runtime.Serialization;

namespace apiclienttool.com.Models.BaseModels
{
    [DataContract]
    public class Error
    {
        /// <summary>
        /// It will return the status codes like 200, 300, etc
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// It will return the name of the status code
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// It will return the detailed message of the status code
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// It will show whether it is an error or a warning
        /// </summary>
        [DataMember]
        public string Type { get; set; }
    }
}