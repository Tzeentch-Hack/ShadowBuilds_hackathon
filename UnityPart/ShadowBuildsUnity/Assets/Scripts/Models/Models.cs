using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public class Models 
    {
        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public string id { get; set; }
            public Geometry geometry { get; set; }
            public string geometry_name { get; set; }
            public Properties properties { get; set; }
            public List<double> bbox { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<List<List<List<double>>>> coordinates { get; set; }
        }

        public class Properties
        {
            public string kadastr { get; set; }
            public string manzil { get; set; }
            public string tur { get; set; }
            public object maydoni_ga { get; set; }
            public object saylov_uchastka { get; set; }
            public object saylov_manzil { get; set; }
            public object saylov_nom { get; set; }
            public object narx { get; set; }
            public object yer_turi { get; set; }
            public object uzgarish { get; set; }
            public object xujjat { get; set; }
            public string tuman { get; set; }
            public object mahalla { get; set; }
            public object ax { get; set; }
            public object kucha { get; set; }
            public string uy_raqam { get; set; }
            public object subyekt4 { get; set; }
            public string name { get; set; }
        }

        public class GeoCadasterResponseModel
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
            public string totalFeatures { get; set; }
            public int numberReturned { get; set; }
            public DateTime timeStamp { get; set; }
            public Crs crs { get; set; }
            public List<double> bbox { get; set; }
        }
    }
}

