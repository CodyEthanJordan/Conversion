using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Liquid : Chemical
    {
    public CompDict Composition = new CompDict()
        {
            {"H20", 100 }
        };

        private void Start()
        {
            if (Composition == null)
            {
                Composition = new CompDict();
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

        public static string GetComposition(CompDict Composition)
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
