using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace YandexGeocodingAPI
{
    public class YandexGeocodingInteractor
    {
        private YandexGeocodingGateway gateway;

        public YandexGeocodingInteractor()
        {
            gateway = new YandexGeocodingGateway();
        }

        public void GetAdressByCoords(Vector2 coords, Action<MapViewAdressEntity> onSucces, Action<string> onError)
        {
            gateway.GetGeoObjectsByCoords(coords, (geoObjects) =>
            {
                MapViewAdressEntity result = GetStreetAndHouse(geoObjects.FeatureMembers[0].GeoObject); // first object might be containe most correct address 
                onSucces(result);
            },
            (error) =>
            {
                //Debug.Log(error);
                onError(error);
            });
        }

        public void GetMapPointByText(string searchText, Action<Vector2, string> onSuccess, Action<string> onError)
        {
            gateway.GetGeoObjectsByText(searchText, (geoObjects) =>
            {
                Vector2 result = GetMapPoint(geoObjects.FeatureMembers[0].GeoObject);
                string fullAddress = geoObjects.FeatureMembers[0].GeoObject.metaDataProperty.GeocoderMetaData.Address.formatted;
                onSuccess(result, fullAddress);
            },
            (error) =>
            {
                onError(error);
            });
        }

        private Vector2 GetMapPoint(GeoObject geoObject)
        {
            string x = geoObject.Point.pos.Split(' ')[0].Replace('.', ',');
            string y = geoObject.Point.pos.Split(' ')[1].Replace('.', ',');
            return new Vector2(float.Parse(x), float.Parse(y));
        }

        private MapViewAdressEntity GetStreetAndHouse(GeoObject geoObject)
        {
            var geoCoderMetaData = geoObject.metaDataProperty.GeocoderMetaData;
            List<Component> addressComponents = geoCoderMetaData.Address.Components;
            StringBuilder streetString = new StringBuilder();
            StringBuilder houseString = new StringBuilder();
            foreach (Component addressComponent in addressComponents)
            {
                if (addressComponent.kind == KindType.STREET || addressComponent.kind == KindType.DISTRICT)
                {
                    streetString.Append(", " + addressComponent.name);
                }
                if (addressComponent.kind == KindType.HOUSE)
                {
                    houseString.Append(", " + addressComponent.name);
                }
            }
            if (streetString.Length > 0)
                streetString.Remove(0, 2); // remoove first ", "
            if (houseString.Length > 0)
                houseString.Remove(0, 2); // remoove first ", "

            var resultEntityForMapView = new MapViewAdressEntity();
            resultEntityForMapView.fullAddressSttring = geoCoderMetaData.Address.formatted;
            if (streetString.Length > 0)
                resultEntityForMapView.street = streetString.ToString();
            else
                resultEntityForMapView.street = geoCoderMetaData.Address.formatted;
            resultEntityForMapView.house = houseString.ToString();
            return resultEntityForMapView;
        }
    }

    public struct MapViewAdressEntity
    {
        public string street;
        public string house;
        public string fullAddressSttring;

        public override string ToString()
        {
            return "Улица: " + street + ", дом: " + house + "; " + fullAddressSttring;
        }
    }
}

