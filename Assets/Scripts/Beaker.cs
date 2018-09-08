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




        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(reactionOrigin.x, reactionOrigin.y, 0), reactionSize);
        }
    }
}
