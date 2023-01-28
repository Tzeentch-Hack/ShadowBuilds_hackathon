using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using System;
using models;

namespace interactor
{
    public class MapInteractor
    {
        public static MapInteractor instance;

        public MapInteractor()
        {
            if (instance == null)
                instance = this;
        }

        public Action getCornersAndCentre;
        public Action<MapCaptureData> onGetCornersAndCentre;
    }
}

