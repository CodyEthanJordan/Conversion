using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Beaker : MonoBehaviour
    {
        [SerializeField] private Vector2 reactionOrigin;
        [SerializeField] private Vector2 reactionSize;

        private AudioSource audio;

        private void Awake()
        {
            audio = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Glass"))
            {
                audio.Play();
            }
        }

        private void Update()
        {
            int detectedSamples = 0;
            var currentPosition = new Vector2(transform.position.x, transform.position.y);
            CompDict composition = new CompDict();
            bool catlystPresent = false;
            foreach (var item in Physics2D.OverlapBoxAll(currentPosition + reactionOrigin, reactionSize, 0))
            {
                var catalyst = item.GetComponent<Catalyst>();
                if (catalyst != null)
                {
                    catlystPresent = true;
                }

                var liquid = item.GetComponent<Liquid>();
                if (liquid == null)
                {
                    continue;
                }
                detectedSamples++;
                foreach (var kvp in liquid.Composition)
                {
                    if (composition.ContainsKey(kvp.Key))
                    {
                        composition[kvp.Key] = composition[kvp.Key] + kvp.Value;
                    }
                    else
                    {
                        composition.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            if (detectedSamples > 0)
            {
                Liquid.Normalize(composition);
                foreach (var item in Physics2D.OverlapBoxAll(currentPosition + reactionOrigin, reactionSize, 0))
                {
                    var liquid = item.GetComponent<Liquid>();
                    if (liquid == null)
                    {
                        continue;
                    }
                    liquid.CatalystPresent = catlystPresent;
                    liquid.Composition = CompDict.Clone(composition);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(reactionOrigin.x, reactionOrigin.y, 0), reactionSize);
        }
    }
}
