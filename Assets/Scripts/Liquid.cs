using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Liquid : Chemical
    {
        public Dictionary<string, float> Composition;

        private void Start()
        {
            if (Composition == null)
            {
                Composition = new Dictionary<string, float>();
            }

            if (Composition.Count == 0)
            {
                MakeWater(); //default all substances to water, can set when instantiated if we want
            }
        }

        public void MakeWater()
        {
            Composition.Clear();
            Composition.Add("H2O", 100);
        }

        public static string GetComposition(Dictionary<string, float> Composition)
        {
            string composition = "";
            foreach (var kvp in Composition)
            {
                composition = composition + kvp.Key + ":" + kvp.Value + "%\n";
            }

            return composition;
        }

        
    }
}
