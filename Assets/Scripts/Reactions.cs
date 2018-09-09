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

        public float acConstant;
        public float acConstant_Cu;

        public float bdConstant;
        public float bdConstant_Cu;


        public float GetConstant(string first, string second, bool catalyst)
        {
            if ((first == "A" && second == "B") || (second == "A" && first == "B"))
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
            else if ((first == "A" && second == "C") || (second == "A" && first == "C"))
            {
                if (catalyst)
                {
                    return acConstant_Cu;
                }
                else
                {
                    return acConstant;
                }
            }
            else if ((first == "D" && second == "B") || (second == "D" && first == "B"))
            {
                if (catalyst)
                {
                    return bdConstant_Cu;
                }
                else
                {
                    return bdConstant;
                }
            }
            else
            {
                return 0.0f;
            }
        }
    }
}
