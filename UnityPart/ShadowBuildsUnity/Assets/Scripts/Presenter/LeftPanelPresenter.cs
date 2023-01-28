using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftPanelPresenter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textContent;

    private RectTransform rectTransform;

    private bool isPanelOpen;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        isPanelOpen = false;
    }

    public void SwitchPanel()
    {
        if (isPanelOpen)
            ClosePanel();
        else
            OpenPanel();
    }

    public void OpenPanel()
    {
        isPanelOpen = true;
        rectTransform.DOLocalMoveX(1000, 0.6f);
    }

    public void ClosePanel()
    {
        isPanelOpen = false;
        rectTransform.DOLocalMoveX(2000, 0.6f);
    }
}
