using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            this.tlx = tlx.ToString("0.0000000000", new CultureInfo("en-US"));
            this.tly = tly.ToString("0.0000000000", new CultureInfo("en-US"));
            this.btx = btx.ToString("0.0000000000", new CultureInfo("en-US"));
            this.bty = bty.ToString("0.0000000000", new CultureInfo("en-US"));
            this.x = x.ToString("0.0000000000", new CultureInfo("en-US"));
            this.y = y.ToString("0.0000000000", new CultureInfo("en-US"));
            this.height = height.ToString();
            this.width = width.ToString();

        }
    }

    [Serializable]
    public class Crs
    {
        public string type;
        public Properties properties;
    }

    [Serializable]
    public class Feature
    {
        public string type;
        // public string id ;
        //  public Geometry geometry ;
        //  public string geometry_name ;
        public Properties properties;
        //  public List<double> bbox ;
    }

    [Serializable]
    public class Geometry
    {
        public string type;
        public List<List<List<List<double>>>> coordinates;
    }


    [Serializable]
    public class Properties
    {
        public string kadastr;
        public string manzil;
        public string tur;
        public string maydoni_ga;
        public string saylov_uchastka;
        public string saylov_manzil;
        public string saylov_nom;
        public string narx;
        public string yer_turi;
        public string uzgarish;
        public string xujjat;
        public string tuman;
        public string mahalla;
        public string ax;
        public string kucha;
        public string uy_raqam;
        public string subyekt4;
        public string name;
    }

    [Serializable]
    public class GeoCadasterResponseModel
    {
        public string type;
        public List<Feature> features;
        public string totalFeatures;
        public string numberReturned;
        public string timeStamp;
        public Crs crs;
        public List<double> bbox;
    }
}

