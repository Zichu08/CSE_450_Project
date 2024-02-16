using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace scene_1
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] private float remainingTime;
        [SerializeField] private player_1_controller player1Controller;
        [SerializeField] private player_2_controller player2Controller;
        [SerializeField] private GameObject gameOverText; 
        
        private void Start()
        {
            remainingTime = 150;
            gameOverText.SetActive(false); // Ensure game over text is hidden at start
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
            gameOverText.SetActive(true);
        }

    }

}
