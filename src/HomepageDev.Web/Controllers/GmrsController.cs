using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using HomepageDev.Data.POCOs;
using HomepageDev.Data.Esri;
using System;

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
    }
}
