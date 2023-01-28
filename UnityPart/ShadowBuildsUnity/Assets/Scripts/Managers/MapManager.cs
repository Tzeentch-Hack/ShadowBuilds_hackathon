using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private OnlineMaps map;

        private void Awake()
        {
            //map = GetComponent<OnlineMaps>();
        }

        public void GetCorners()
        {
            double tlx, tly, btx, bty;
            map.GetCorners(out tlx, out tly, out btx, out bty);
            Debug.Log(tlx.ToString() + tly.ToString() + btx.ToString() + bty.ToString());
        }
    }
}

