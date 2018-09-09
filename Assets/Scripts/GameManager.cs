using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int _score = 0;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                scoreText.text = "Score: " + value;
            }
        }

        [SerializeField] private Text scoreText;

        private void Start()
        {
            Score = 0;
        }


        public void ScorePoint(int points = 1)
        {
            Score += points;
        }
    }
}
