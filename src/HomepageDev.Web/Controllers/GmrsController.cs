using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using HomepageDev.Data.POCOs;
using HomepageDev.Data.Esri;
using System;
using HomepageDev.Data.MyGmrs;

namespace HomepageDev.Controllers
{
    public class GmrsController : Controller
    {
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult GetGmrsRepeaters()
        {
            FeatureLayer gmrsLayer = Features.GetFeatures(ConfigurationManager.AppSettings["gmrsLayerUrl"], "GmrsRepeaters");
            var gmrsRepeaters = gmrsLayer.layers[0].featureSet.features;
            List<GmrsRepeater> mapPts = new List<GmrsRepeater>();

            foreach (var repeater in gmrsRepeaters)
            {
                mapPts.Add(new GmrsRepeater(
                    repeater.attributes.Name,
                    repeater.attributes.UrlMyGRMS,
                    repeater.attributes.RX_Frequency,
                    repeater.attributes.Lat,
                    repeater.attributes.Lon)
                );
            }

            return Json(mapPts);
        }

        [HttpGet]
        [AllowJsonGet]
        public JsonResult GetMyGmrsRepeaters()
        {
            var myGmrs = new MyGmrsRepeaters();
            return Json(myGmrs.Repeaters);       
        }

        [HttpGet]
        [AllowJsonGet]
        public JsonResult GetMyGmrsRepeaterInfo(string id)
        {
            var myGmrs = new MyGmrsRepeaters();
            return Json(myGmrs.GetRepeaterInfoFromFile(id));
        }
    }

    public class AllowJsonGetAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;

            if (jsonResult == null)
                throw new ArgumentException("Action does not return a JsonResult, attribute AllowJsonGet is not allowed");    

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            base.OnResultExecuting(filterContext);
        }
    }
}
