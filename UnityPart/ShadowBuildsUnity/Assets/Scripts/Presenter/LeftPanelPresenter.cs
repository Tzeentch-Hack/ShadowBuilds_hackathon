using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using models;
using interactor;

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
        MapInteractor.instance.GetResponse.AddListener(OpenPanel);
    }

    public void OpenPanel(GeoCadasterResponseModel geoCadasterResponseModel)
    {
        var feature = geoCadasterResponseModel.features[0];
        textContent.text = feature.properties.tuman + "\n" + feature.properties.tur + "\n" + feature.properties.uy_raqam;
        rectTransform.DOLocalMoveX(1000, 0.6f);
    }


    public void ClosePanel()
    {
        rectTransform.DOLocalMoveX(2000, 0.6f);
    }
}
