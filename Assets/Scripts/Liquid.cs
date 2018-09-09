using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Liquid : Chemical
    {
        [SerializeField] private GameObject goalium;
        private float explosionRadius = 3;
         private float explosionVelocity = 1000;

        private AudioSource audio;

        public bool CatalystPresent = false;

        private Reactions reactions;

        public CompDict Composition = new CompDict()
        {
            {"H20", 100 }
        };

        private void Start()
        {
            if (Composition == null)
            {
                Composition = new CompDict();
            }

            if (Composition.Count == 0)
            {
                MakeWater(); //default all substances to water, can set when instantiated if we want
            }

            reactions = GameObject.Find("GameManager").GetComponent<Reactions>();
        }

        private void Awake()
        {
            audio = GetComponent<AudioSource>();
        }

        public void MakeWater()
        {
            Composition.Clear();
            Composition.Add("H2O", 100);
        }

        public static string GetComposition(CompDict Composition)
        {
            string composition = "";
            foreach (var kvp in Composition)
            {
                composition = composition + kvp.Key + ":" + kvp.Value.ToString("0.") + "%\n";
            }

            return composition;
        }

        private float HowMuch(string chemical)
        {
            if (Composition.ContainsKey(chemical))
            {
                return Composition[chemical];
            }

            return 0;
        }

        private void SetAmount(string chemical, float amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }

            if (amount == 0)
            {
                Composition.Remove(chemical);
            }
            else
            {
                if (Composition.ContainsKey(chemical))
                {
                    Composition[chemical] = amount;
                }
                else
                {
                    Composition.Add(chemical, amount);
                }
            }
        }

        private void Update()
        {
            //lets do some reactions
            float abConstant = reactions.GetConstant("A", "B", CatalystPresent);
            var abRate = abConstant * HowMuch("A") * HowMuch("B");
            SetAmount("A", HowMuch("A") - abRate / 2 * Time.deltaTime);
            SetAmount("B", HowMuch("B") - abRate / 2 * Time.deltaTime);
            SetAmount("E", HowMuch("E") + abRate * Time.deltaTime);

            float acConstant = reactions.GetConstant("A", "C", CatalystPresent);
            var acRate = acConstant * HowMuch("A") * HowMuch("C");
            SetAmount("A", HowMuch("A") - acRate / 2 * Time.deltaTime);
            SetAmount("C", HowMuch("C") - acRate / 2 * Time.deltaTime);
            SetAmount("G", HowMuch("G") + acRate * Time.deltaTime);

            float bdConstant = reactions.GetConstant("B", "D", CatalystPresent);
            var bdRate = abConstant * HowMuch("B") * HowMuch("D");
            SetAmount("B", HowMuch("B") - bdRate / 2 * Time.deltaTime);
            SetAmount("D", HowMuch("D") - bdRate / 2 * Time.deltaTime);
            SetAmount("G", HowMuch("G") + bdRate * Time.deltaTime);

            //precipitate
            if (HowMuch("G") > 50)
            {
                Instantiate(goalium, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (HowMuch("E") > 50)
            {
                GameObject.Find("Exploder").GetComponent<AudioSource>().Play();
                var currentPosition = new Vector2(transform.position.x, transform.position.y);
                foreach (var item in Physics2D.OverlapCircleAll(currentPosition, explosionRadius))
                {
                    Debug.Log(item.name);
                    var rigidBody = item.GetComponent<Rigidbody2D>();
                    if(rigidBody != null)
                    {
                        rigidBody.AddForce(UnityEngine.Random.insideUnitCircle * explosionVelocity);
                    }
                }
                Destroy(this.gameObject);
            }

            //explode
        }

        public static void Normalize(CompDict input)
        {
            float total = 0;
            foreach (var kvp in input)
            {
                total += kvp.Value;
            }

            List<string> keys = new List<string>(input.Keys);
            foreach (var key in keys)
            {
                input[key] = input[key] / total * 100;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(this.transform.position, explosionRadius * Vector3.one);
        }


    }
}
