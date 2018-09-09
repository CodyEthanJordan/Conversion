using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class BusenController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer flameRenderer;
        [SerializeField] private Vector2 heatOrigin;
        [SerializeField] private Vector2 heatSize;

        public float HeatApplied = 0.3f;

        private SpriteRenderer sr;
        private AudioSource audio;

        private bool _activated;
        public bool Activated
        {
            get { return _activated; }
            set
            {
                _activated = value;
                UpdateAnimation();
            }
        }

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            audio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Activated = false;
        }

        private void UpdateAnimation()
        {
            if(Activated)
            {
                audio.Play();
                flameRenderer.enabled = true;
            }
            else
            {
                flameRenderer.enabled = false;
                audio.Stop();
            }
        }

        private void OnMouseDown()
        {
            Activated = !Activated;
        }

        private void FixedUpdate()
        {
            if(Activated) //heat up stuff
            {
                var currentPosition = new Vector2(transform.position.x, transform.position.y);
                foreach (var item in Physics2D.OverlapBoxAll(currentPosition + heatOrigin, heatSize, 0))
                {
                    Chemical chem = item.GetComponent<Chemical>();
                    if(chem != null)
                    {
                        chem.ApplyHeat(HeatApplied);
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(heatOrigin.x, heatOrigin.y, 0), heatSize);
        }
    }

    
}
