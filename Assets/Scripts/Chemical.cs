using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chemical : MonoBehaviour
    {
        public static readonly float RoomTemperature = 300;

        public string ChemicalName;
        public float Temperature = RoomTemperature;

        public void ApplyHeat(float heat)
        {
            Temperature += heat;
            Debug.Log(this.name + " is now " + Temperature + "K");
        }

        private void FixedUpdate()
        {
            
        }
    }
}
