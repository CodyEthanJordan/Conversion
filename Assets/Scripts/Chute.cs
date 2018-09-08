using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chute : MonoBehaviour
    {
        public GameObject Thing;
        [SerializeField] private Vector3 dispenseOrigin;
        public float Cooldown;

        private float timeSinceLastDispense = 100;

        public void Dispense()
        {
            if (timeSinceLastDispense > Cooldown)
            {
                var newThing = Instantiate(Thing, this.transform.position + dispenseOrigin, Quaternion.identity);
                newThing.GetComponent<Rigidbody2D>().velocity = UnityEngine.Random.insideUnitCircle / 3;
                timeSinceLastDispense = 0;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(this.transform.position + dispenseOrigin, new Vector3(1, 1, 1));
        }

        private void Update()
        {
            timeSinceLastDispense += Time.deltaTime;
        }
    }
}
