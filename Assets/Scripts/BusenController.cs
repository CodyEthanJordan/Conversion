using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class BusenController : MonoBehaviour
    {
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;
        [SerializeField] private Vector2 heatOrigin;
        [SerializeField] private Vector2 heatSize;

        public float HeatApplied = 0.3f;

        private SpriteRenderer sr;

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
        }

        private void Start()
        {
            Activated = false;
        }

        private void UpdateAnimation()
        {
            if(Activated)
            {
                sr.sprite = onSprite;
            }
            else
            {
                sr.sprite = offSprite;
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
