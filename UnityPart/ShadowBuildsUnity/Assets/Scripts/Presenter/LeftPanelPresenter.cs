using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using models;
using interactor;
using System.Text.RegularExpressions;

public class LeftPanelPresenter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textContent;

    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        MapInteractor.instance.GetGeoInfoResponse.AddListener(OpenPanel);
    }

    public void OpenPanel(GeoCadasterResponseModel geoCadasterResponseModel)
    {
        var feature = geoCadasterResponseModel.features[0].properties;
        var str = feature.kadastr + "\n" + feature.kucha + "\n" + feature.mahalla + "\n" + feature.manzil + "\n" + feature.maydoni_ga + "\n" + feature.name + "\n" + feature.narx + "\n" + feature.saylov_manzil + "\n" + feature.saylov_nom + "\n" + feature.saylov_uchastka + "\n" + feature.subyekt4 + "\n" + feature.tuman + "\n" + feature.uy_raqam + "\n" + feature.tur + "\n" + feature.uzgarish + "\n" + feature.xujjat + "\n" + feature.yer_turi + "\n" + feature.ax;
        textContent.text =  Regex.Replace(str, "\n+", match => match.Value.Length > 1 ? "\n" : match.Value); 
        rectTransform.DOLocalMoveX(1000, 0.6f);
    }

    public void ClosePanel()
    {
        rectTransform.DOLocalMoveX(2000, 0.6f);
    }
}

