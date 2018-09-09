using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Reactions : MonoBehaviour
    {
        public float abConstant;
        public float abConstant_Cu;

        public float GetConstant(bool catalyst)
        {
            if (catalyst)
            {
                return abConstant_Cu;
            }
            else
            {
                return abConstant;
            }
        }
    }
}
