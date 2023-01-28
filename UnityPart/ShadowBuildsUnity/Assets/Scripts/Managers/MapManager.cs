using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using interactor;
using System.Globalization;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private OnlineMaps map;

        private void Start()
        {
            MapInteractor.instance.getCornersAndCentre += OnGetCornersAndCentre;
        }

        public void GetCenter()
        {
            double lat, lon;
            map.GetPosition(out lon,out lat);
            MapInteractor.instance.SendGeoPos(lat, lon);
        }

        public void OnGetCornersAndCentre()
        {
            var mapData = GetCornersAndCentre();
            MapInteractor.instance.onGetCornersAndCentre?.Invoke(mapData);
        }

        private MapCaptureData GetCornersAndCentre()
        {
            double tlx, tly, brx, bry;
            double x, y;
            map.GetCorners(out tlx, out tly, out brx, out bry);
            map.GetPosition(out x, out y);
            double blX, blY, trX, trY;
            blX = tlx;
            blY = bry;
            trX = brx;
            trY = tly;
            Debug.Log(blX.ToString("0.00000000",new CultureInfo("en-US")) + "," +  blY.ToString("0.00000000", new CultureInfo("en-US")) +
                "~" + trX.ToString("0.00000000", new CultureInfo("en-US")) + "," + trY.ToString("0.00000000", new CultureInfo("en-US")));
            MapCaptureData newMapData = new MapCaptureData(blX, blY, trX, trY, x, y, height: 512, width: 512);
            return newMapData;
        }
    }
}

