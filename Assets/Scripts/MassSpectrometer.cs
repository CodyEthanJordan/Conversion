using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MassSpectrometer : MonoBehaviour
    {
        [SerializeField] private Vector2 probeOrigin;
        [SerializeField] private Vector2 probeSize;
        [SerializeField] private Text outputText;

        private void Update()
        {
            var currentPosition = new Vector2(transform.position.x, transform.position.y);
            if (Physics2D.OverlapBoxAll(currentPosition + probeOrigin, probeSize, 0).Length == 0)
            {
                outputText.text = "No Sample";
            }

            int detectedSamples = 0;
            Dictionary<string, float> composition = new Dictionary<string, float>();

            foreach (var item in Physics2D.OverlapBoxAll(currentPosition + probeOrigin, probeSize, 0))
            {
                var liquid = item.GetComponent<Liquid>();
                if(liquid == null)
                {
                    continue;
                }
                detectedSamples++;
                foreach (var kvp in liquid.Composition)
                {
                    if(composition.ContainsKey(kvp.Key))
                    {
                        composition[kvp.Key] = composition[kvp.Key] + kvp.Value;
                    }
                    else
                    {
                        composition.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            if(detectedSamples == 0)
            {
                outputText.text = "No Sample";
            }
            else
            {
                //normalize results
                float total = 0;
                foreach (var kvp in composition)
                {
                    total += kvp.Value;
                }

                //foreach (var kvp in composition)
                //{
                //    composition[kvp.Key] = kvp.Value / total;
                //}

                outputText.text = Liquid.GetComposition(composition);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(probeOrigin.x, probeOrigin.y, 0), probeSize);
        }
    }
}
