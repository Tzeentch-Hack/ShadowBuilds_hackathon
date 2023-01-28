using models;
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using interactor;

public class GeoPosGateWay 
{

    private readonly string basePath = "http://100.65.2.151:5000";

    public static GeoPosGateWay Instance;


    public GeoPosGateWay()
    {
        Instance = this;
        MapInteractor.instance.onGetCornersAndCentre += SendScanedImageAndCoords;
    }

    public void GetDataAboutPos(double lat, double lon)
    {   

        var url = (basePath + "/GetGeoInfo" + "?" + $"x={lat.ToString("0.0000000", new CultureInfo("en-US"))}" + "&" + $"y={lon.ToString("0.0000000", new CultureInfo("en-US"))}");

        RestClient.Get(url).Then(res =>
        {
          
            var finishModel = JsonUtility.FromJson<GeoCadasterResponseModel>(res.Text.Replace("\'","\""));
            MapInteractor.instance.GetGeoInfoResponse.Invoke(finishModel);
        }
        ).Catch(error =>
        {
            this.LogMessage("Error", JsonUtility.ToJson(error.Message, true));
        });

    }

    public void SendScanedImageAndCoords(MapCaptureData mapData)
    {
        var url = (basePath + "/PostCurrentMapInfo");

        RestClient.Post(url, mapData).Then((response) =>
        {
            Debug.Log(response.Text);
            var finishModel = JsonUtility.FromJson<MarkerPoints>(response.Text);
            MapInteractor.instance.SetUpMarkers.Invoke(finishModel);
        }).Catch((error) =>
        {
            this.LogMessage("Error", JsonUtility.ToJson(error.Message, true));
        });
    }

    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
    }
}
