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

        private void Update()
        {
            var currentPosition = new Vector2(transform.position.x, transform.position.y);
            foreach (var item in Physics2D.OverlapBoxAll(currentPosition + reactionOrigin, reactionSize, 0))
            {
                var liquid = item.GetComponent<Liquid>();
                if (liquid == null)
                {
                    continue;
                }
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(reactionOrigin.x, reactionOrigin.y, 0), reactionSize);
        }
    }
}
