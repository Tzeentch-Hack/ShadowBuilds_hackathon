using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using interactor;

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
            double tlx, tly, btx, bty;
            double x, y;
            map.GetCorners(out tlx, out tly, out btx, out bty);
            map.GetPosition(out x, out y);
            Debug.Log(tlx.ToString() + ", " +  tly.ToString() + ", " + btx.ToString() + ", " + bty.ToString());
            MapCaptureData newMapData = new MapCaptureData(tlx, tly, btx, bty, x, y, height: 512, width: 1024);
            return newMapData;
        }
    }
}

