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
    }

    
}
