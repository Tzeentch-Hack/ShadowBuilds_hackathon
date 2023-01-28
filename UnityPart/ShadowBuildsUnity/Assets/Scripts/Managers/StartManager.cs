using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interactor;


    public class StartManager : MonoBehaviour
    {
        private GeoPosGateWay geoPosGateWay;
        private MapInteractor mapInteractor;
        void Awake()
        {
            mapInteractor = new MapInteractor();
            geoPosGateWay = new GeoPosGateWay();
        }
    }
