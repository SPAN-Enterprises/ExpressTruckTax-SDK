using System.Runtime.Serialization;

namespace apiclienttool.com.Models.BaseModels
{
    [DataContract]
    public class VIN
    {
        /// <summary>
        /// Vehicle Identification Number - A VIN is composed of 17 characters (digits and capital letters) that act as a unique identifier for the vehicle. 
        /// </summary>
        [DataMember]
        public string Vin { get; set; }

        /// <summary>
        /// Taxable gross weight (in pounds).  A (55,000 lbs) to V (Over 75,000 lbs) and W (Suspended) 
        /// </summary>
        [DataMember]
        public string WeightClass { get; set; }

        /// <summary>
        ///  “Confirmed” or “Unconfirmed“
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        ///  If the status is Unconfirmed, the reason will be displayed.	
        /// </summary>
        [DataMember]
        public string UnconfirmedReason { get; set; }
    }
}