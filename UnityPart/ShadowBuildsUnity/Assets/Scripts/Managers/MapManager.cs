using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
using interactor;
using System.Globalization;
using System;
using YandexGeocodingAPI;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Text;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private OnlineMaps map;
        [SerializeField] 
        OnlineMapsUIImageControl onlineMapsUIImageControl;

        [SerializeField]
        private OnlineMapsMarkerManager mapMarker;

        [SerializeField] TMP_InputField addressText;

        private YandexGeocodingInteractor yandexGeocoding;

        private void Start()
        {
            MapInteractor.instance.getCornersAndCentre += OnGetCornersAndCentre;

            onlineMapsUIImageControl.OnMapRelease += OnChangePosition;
            onlineMapsUIImageControl.OnMapPress += OnPositionChangingBegin;
            MapInteractor.instance.SetUpMarkers.AddListener(CreateMarkersOnMap);
            addressText.onEndEdit.AddListener(OnInputValueChange);
            yandexGeocoding = new YandexGeocodingInteractor();
        }

        public void CreateMarkersOnMap(MarkerPoints markers)
        {
            foreach(var point in markers.points)
            {
               OnlineMapsMarkerManager.CreateItem(point.x, point.y);
            }
        }
        private void OnInputValueChange(string temp)
        {
            if (temp != string.Empty) GetAndDisplayLocationByName(temp);
        }

        private void GetAndDisplayLocationByName(string temp)
        {
            StringBuilder searchString = new StringBuilder();
            if (addressText.text.Length > 0)
                searchString.Append(", " + addressText.text);
            searchString.Remove(0, 2);
            string searchLocationText = searchString.ToString();
            yandexGeocoding.GetMapPointByText(searchLocationText, (point, fullAddress) =>
            {
                map.position = point;
            },
            (err) =>
            {
                Debug.Log(err);
            });
        }

        private void OnPositionChangingBegin()
        {
            addressText.text = string.Empty;
        }

        private void GetAndDisplayLocationByCoords(Vector2 coords)
        {
            yandexGeocoding.GetAdressByCoords(coords,
            (location) =>
            {
                addressText.text = location.fullAddressSttring;
            },
            (err) =>
            {
                Debug.Log(err);
            });
        }

        private void OnChangePosition()
        {
            GetAndDisplayLocationByCoords(map.position);
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
            Debug.Log(blX.ToString("0.0000000000",new CultureInfo("en-US")) + "," +  blY.ToString("0.0000000000", new CultureInfo("en-US")) +
                "~" + trX.ToString("0.0000000000", new CultureInfo("en-US")) + "," + trY.ToString("0.0000000000", new CultureInfo("en-US")));
            MapCaptureData newMapData = new MapCaptureData(blX, blY, trX, trY, x, y, height: 512, width: 512);
            return newMapData;
        }
    }
}

