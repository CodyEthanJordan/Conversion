using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ice : Chemical
    {
        public static readonly float MeltingPoint = 273;

        public int WaterContained = 5;

        [SerializeField] private GameObject water;

        private void Start()
        {
            this.Temperature = 250;
        }

        private void Update()
        {
            if (Temperature > MeltingPoint)
            {
                for (int i = 0; i < WaterContained; i++)
                {
                    Instantiate(water, this.transform.position, this.transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
