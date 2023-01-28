using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public struct MapCaptureData
    {
        public string tlx;
        public string tly;
        public string btx;
        public string bty;
        public string x;
        public string y;
        public string height;
        public string width;

        public MapCaptureData(double tlx, double tly, double btx, double bty, double x, double y, int height, int width)
        {
            this.tlx = tlx.ToString("0.0000000");
            this.tly = tly.ToString("0.0000000");
            this.btx = btx.ToString("0.0000000");
            this.bty = bty.ToString("0.0000000");
            this.x = x.ToString("0.0000000");
            this.y = y.ToString("0.0000000");
            this.height = height.ToString();
            this.width = width.ToString();

        }
    }

    [Serializable]
    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    [Serializable]
    public class Feature
    {
        public string type { get; set; }
        // public string id { get; set; }
        //  public Geometry geometry { get; set; }
        //  public string geometry_name { get; set; }
        public Properties properties { get; set; }
        //  public List<double> bbox { get; set; }
    }

    [Serializable]
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }


    [Serializable]
    public class Properties
    {
        public string kadastr { get; set; }
        public string manzil { get; set; }
        public string tur { get; set; }
        public string maydoni_ga { get; set; }
        public string saylov_uchastka { get; set; }
        public string saylov_manzil { get; set; }
        public string saylov_nom { get; set; }
        public string narx { get; set; }
        public string yer_turi { get; set; }
        public string uzgarish { get; set; }
        public string xujjat { get; set; }
        public string tuman { get; set; }
        public string mahalla { get; set; }
        public string ax { get; set; }
        public string kucha { get; set; }
        public string uy_raqam { get; set; }
        public string subyekt4 { get; set; }
        public string name { get; set; }
    }

    [Serializable]
    public class GeoCadasterResponseModel
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public string totalFeatures { get; set; }
        public string numberReturned { get; set; }
        public string timeStamp { get; set; }
        public Crs crs { get; set; }
        //    public List<double> bbox { get; set; }
    }
}

