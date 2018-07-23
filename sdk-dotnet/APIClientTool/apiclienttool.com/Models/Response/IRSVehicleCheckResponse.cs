using apiclienttool.com.Models.BaseModels;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace apiclienttool.com.Models.Response
{
    [DataContract]
    public class IRSVehicleCheckResponse
    {
        /// <summary>
        /// Employer Identification Number of the business.
        /// </summary>
        [DataMember]
        public string TaxpayerEIN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TaxYear { get; set; }

        /// <summary>
        ///  Collection of the VINs with there status “Confirmed” or “Unconfirmed”
        /// </summary>
        [DataMember]
        public List<VIN> VINs { get; set; }

        /// <summary>
        /// It will show the detailed information about the error.
        /// </summary>
        [DataMember]
        public List<Error> Errors { get; set; }
    }
}