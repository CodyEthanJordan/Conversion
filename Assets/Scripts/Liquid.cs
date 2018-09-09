using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Liquid : Chemical
    {
        public float rateConstant = 0.1f;

        [SerializeField] private GameObject goalium;

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
                composition = composition + kvp.Key + ":" + kvp.Value.ToString("0.") + "%\n";
            }

            return composition;
        }

        private float HowMuch(string chemical)
        {
            if(Composition.ContainsKey(chemical))
            {
                return Composition[chemical];
            }

            return 0;
        }

        private void SetAmount(string chemical, float amount)
        {
            if(amount < 0)
            {
                amount = 0;
            }

            if(amount == 0)
            {
                Composition.Remove(chemical);
            }
            else
            {
                if(Composition.ContainsKey(chemical))
                {
                    Composition[chemical] = amount;
                }
                else
                {
                    Composition.Add(chemical, amount);
                }
            }
        }

        private void Update()
        {
            //lets do some reactions

            var abRate = rateConstant * HowMuch("A") * HowMuch("B");
            SetAmount("A", HowMuch("A") - abRate / 2 * Time.deltaTime);
            SetAmount("B", HowMuch("B") - abRate / 2 * Time.deltaTime);
            SetAmount("C", HowMuch("C") + abRate  * Time.deltaTime);

            //precipitate
            if(HowMuch("C") > 0.9f)
            {
                Instantiate(goalium, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        public static void Normalize(CompDict input)
        {
            float total = 0;
            foreach (var kvp in input)
            {
                total += kvp.Value;
            }

            List<string> keys = new List<string>(input.Keys);
            foreach (var key in keys)
            {
                input[key] = input[key] / total * 100;
            }
        }


    }
}
