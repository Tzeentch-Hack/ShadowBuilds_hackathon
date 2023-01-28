using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class StartManager : MonoBehaviour
    {
        private GeoPosGateWay geoPosGateWay;
        void Awake()
        {
            geoPosGateWay = new GeoPosGateWay();
            geoPosGateWay.GetDataAboutPos(41.265849, 69.187614);
        }
    }
