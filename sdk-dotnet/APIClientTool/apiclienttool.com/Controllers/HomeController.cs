using apiclienttool.com.Models.Request;
using apiclienttool.com.Models.Response;
using apiclienttool.com.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace apiclienttool.com.Controllers
{
    public class HomeController : Controller
    {
        #region Verify the e-filing of Federal HVUT Index
        [HttpGet]
        public ActionResult Index(bool? id)
        {
            var request = new IRSVehicleCheckRequest();
            request.VINs = new List<string>();
            bool prePopulate = id ?? false;
            if (prePopulate)
            {
                request.TaxpayerEIN = "009658259";
                request.TaxYear = "2018";
                request.VINs.Add("AVMFTYYT");
                request.VINs.Add("JHGSDJG");
            }
            return View(request);
        }
        #endregion


        #region Get VIN Status
        [HttpPost]
        public ActionResult GetVINStatus(IRSVehicleCheckRequest vinCheckRequest)
        {
            var responseJson = string.Empty;
            IRSVehicleCheckResponse vehicleCheckResponse = new IRSVehicleCheckResponse();

            using (var client = new PublicAPIClient())
            {
                //API URL to Get VIN Status
                string requestUri = "hvutvalidation/irsvehiclecheck";

                //POST
                APIGenerateAuthHeader.GenerateAuthHeader(client, requestUri, "POST");

                //Get Response
                var response = client.PostAsJsonAsync(requestUri, vinCheckRequest).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    //Read Response
                    var createResponse = response.Content.ReadAsAsync<IRSVehicleCheckResponse>().Result;
                    if (createResponse != null)
                    {
                        responseJson = JsonConvert.SerializeObject(createResponse, Formatting.Indented);
                        //Deserializing JSON (Success Response) to IRSVehicleCheckResponse object
                        vehicleCheckResponse = new JavaScriptSerializer().Deserialize<IRSVehicleCheckResponse>(responseJson);
                    }
                }
                else
                {
                    var createResponse = response.Content.ReadAsAsync<Object>().Result;
                    responseJson = JsonConvert.SerializeObject(createResponse, Formatting.Indented);

                    //Deserializing JSON (Error Response) to IRSVehicleCheckResponse object
                    vehicleCheckResponse = new JavaScriptSerializer().Deserialize<IRSVehicleCheckResponse>(responseJson);
                }
            }
            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}