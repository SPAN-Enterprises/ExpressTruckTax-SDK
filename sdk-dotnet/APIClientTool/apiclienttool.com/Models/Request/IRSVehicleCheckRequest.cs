using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace apiclienttool.com.Models.Request
{
    [DataContract]
    public class IRSVehicleCheckRequest
    {
        /// <summary>
        /// Tax Year the vehicle was filed for. Ex - Enter 2018 for the 2018-19 tax year (July 1, 2018, through June 30, 2019)
        /// </summary>
        [DataMember]
        public string TaxYear { get; set; }

        /// <summary>
        /// Employer Identification Number of the business.
        /// </summary>
        [DataMember]
        public string TaxpayerEIN { get; set; }

        /// <summary>
        /// The combined data of VIN and Weight Class of the vehicles that needs to be verified.
        /// </summary>
        [DataMember]
        public List<string> VINs { get; set; }

    }
}