using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class KillPlane : MonoBehaviour
    {
        [SerializeField] private Vector2 killOirgin;
        [SerializeField] private Vector2 killSize;
        public GameManager gm;

        private void Start()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            var currentPosition = new Vector2(transform.position.x, transform.position.y);
            foreach (var item in Physics2D.OverlapBoxAll(currentPosition + killOirgin, killSize, 0))
            {
                var chemical = item.GetComponent<Chemical>();
                if(chemical != null)
                {
                    if(chemical.ChemicalName == "Goalium")
                    {
                        gm.ScorePoint();
                    }
                }

                Destroy(item);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(this.transform.position + new Vector3(killOirgin.x, killOirgin.y, 0), killSize);
        }
    }
}
