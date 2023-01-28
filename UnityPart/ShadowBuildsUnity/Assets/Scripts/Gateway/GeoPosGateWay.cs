using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using static models.Models;

public class GeoPosGateWay 
{

    private readonly string basePath = "http://100.65.2.151:5000";

    public static GeoPosGateWay Instance;


    public GeoPosGateWay()
    {
        Instance = this;
    }

    public void GetDataAboutPos(double lat, double lon)
    {   

        var url = (basePath + "/GetGeoInfo" + "?" + $"x={lat.ToString("0.0000000", new CultureInfo("en-US"))}" + "&" + $"y={lon.ToString("0.0000000", new CultureInfo("en-US"))}");
        Debug.Log(url);
        RestClient.Get(url).Then(res =>
        {
            this.LogMessage("Success",res.Text);
            var finishModel = JsonUtility.FromJson<GeoCadasterResponseModel>(res.Text);
        }
        ).Catch(error =>
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
