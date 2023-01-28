using Newtonsoft;
using Newtonsoft.Json;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace YandexGeocodingAPI
{
    public class YandexGeocodingGateway
    {
        private string apiKey = "44f7e140-d6d7-4d54-97da-c5043e4821b9"; // SherAlex API Key

        public void GetGeoObjectsByCoords(Vector2 coords, Action<GeoObjectCollection> onSuccess, Action<string> onError)
        {
            string coordsString = coords.ToString("F8");
            string url = $"https://geocode-maps.yandex.ru/1.x?geocode={coordsString}&apikey={apiKey}&format=json";
            RestClient.Get(url).Then((response) =>
            {
                if (response == null)
                {
                    Debug.LogError("Connection error");
                    return;
                }
                YandexAPIResponseRoot responseRoot = JsonConvert.DeserializeObject<YandexAPIResponseRoot>(response.Text);
                GeoObjectCollection geoObjects = responseRoot.response.GeoObjectCollection;
                onSuccess(geoObjects);
            });
        }

        public void GetGeoObjectsByText(string searchText, Action<GeoObjectCollection> onSuccess, Action<string> onError)
        {
            var u = new Uri($"https://geocode-maps.yandex.ru/1.x?geocode={searchText}&apikey={apiKey}&format=json");
            string url = $"https://geocode-maps.yandex.ru/1.x?geocode={searchText}&apikey={apiKey}&format=json";
            RestClient.Get(url).Then((response) =>
            {
                if (response == null)
                {
                    Debug.LogError("Connection error");
                    return;
                }
                YandexAPIResponseRoot responseRoot = JsonConvert.DeserializeObject<YandexAPIResponseRoot>(response.Text);
                GeoObjectCollection geoObjects = responseRoot.response.GeoObjectCollection;
                onSuccess(geoObjects);
            });
        }
    }
}




