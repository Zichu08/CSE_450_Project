using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace scene_1
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] private float remainingTime;
        [SerializeField] private player_1_controller player1Controller;
        [SerializeField] private player_2_controller player2Controller;
        [SerializeField] private GameObject gameOverText;

        [SerializeField] private GameObject p1WinsText;
        [SerializeField] private GameObject p2WinsText;

        public GameObject button;
        public GameObject p1;
        public health_manager p1HM;
        public GameObject p2;
        public health_manager p2HM;

        private void Start()
        {
            
            remainingTime = 150;
            gameOverText.SetActive(false); // Ensure game over text is hidden at start

            p1WinsText.SetActive(false);
            p2WinsText.SetActive(false);

            // p1 = GameObject.Find("player_1");
            // p2 = GameObject.Find("player_2");
            p1HM = GameObject.Find("player_1").GetComponent<health_manager>();
            p2HM = GameObject.Find("player_2").GetComponent<health_manager>();
            button = GameObject.Find("button");
            button.SetActive(false);
        }

        private void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerDisplay(remainingTime);
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                GameOver();
            }
            
            int p1Lives = p1HM.livesRemaining;
            int p2Lives = p2HM.livesRemaining;
            
            
            if (p1Lives <= 0)
            {
                Debug.Log("P1 has no lives remaining");
                GameOver();
                p2WinsText.SetActive(true);
            }
            else if (p2Lives <= 0)
            {
                Debug.Log("P2 has no lives remaining");
                GameOver();
                p1WinsText.SetActive(true);
            }
        }
        
        void UpdateTimerDisplay(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        private void GameOver()
        {
            if (player1Controller != null) player1Controller.DisableMovement();
            if (player2Controller != null) player2Controller.DisableMovement();
           // gameOverText.SetActive(true);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
           button.SetActive(true);
        }

    }

}
