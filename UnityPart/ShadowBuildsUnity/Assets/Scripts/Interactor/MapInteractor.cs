using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Managers;
using System;
using models;

namespace interactor
{
    public class MapInteractor
    {
        public UnityEvent<GeoCadasterResponseModel> GetResponse;
        public static MapInteractor instance;

        public MapInteractor()
        {
            if (instance == null)
                instance = this;
        }

        public void SendGeoPos(double lat, double lon)
        {
            GeoPosGateWay.Instance.GetDataAboutPos(lat, lon);
        }

        public Action getCornersAndCentre;
        public Action<MapCaptureData> onGetCornersAndCentre;
    }
}

