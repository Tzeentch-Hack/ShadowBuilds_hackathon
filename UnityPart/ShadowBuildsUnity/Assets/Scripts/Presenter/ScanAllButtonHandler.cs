using interactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanAllButtonHandler : MonoBehaviour
{
    Button scanButton;

    private void Awake()
    {
        scanButton = gameObject.GetComponent<Button>();
        scanButton.onClick.AddListener(Scan);
    }

    private void Scan()
    {
        MapInteractor.instance.getCornersAndCentreForAll?.Invoke();
    }
}
