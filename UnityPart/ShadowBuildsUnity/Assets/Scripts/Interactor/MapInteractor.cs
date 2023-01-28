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
        public UnityEvent<GeoCadasterResponseModel> GetGeoInfoResponse;
        public UnityEvent<MarkerPoints> SetUpMarkers;
        public static MapInteractor instance;

        public MapInteractor()
        {
            GetGeoInfoResponse = new UnityEvent<GeoCadasterResponseModel>();
            SetUpMarkers = new UnityEvent<MarkerPoints>();
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

