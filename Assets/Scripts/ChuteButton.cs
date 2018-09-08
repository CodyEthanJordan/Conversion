using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChuteButton : MonoBehaviour
    {
        public Chute chute;

        private void OnMouseOver()
        {
            if (Input.GetMouseButton(0))
            {
                chute.Dispense();
            }
        }
    }
}
