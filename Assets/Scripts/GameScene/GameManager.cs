using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToWaitBeforeExit;
    [SerializeField] private int enemyToKill=30;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text goalText;
    [SerializeField] private GameObject notifPanel;

    private int level=1;
    public int killCount {get;private set;}= 0;
    // public UnityEvent OnScoreChanged;

    public void OnPlayerDied(){
        Invoke(nameof(EndGame), timeToWaitBeforeExit);
    }

    public void AddKillCount(int amount){
        killCount+=amount;
        // OnScoreChanged.Invoke();
        scoreText.text = $"Killed: {killCount}";
        if(killCount>=enemyToKill){
            Spawner[] spawners = FindObjectsOfType<Spawner>();
            foreach (Spawner spawner in spawners){
                spawner.TurnOff();
            }
             GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies){
                Destroy(enemy);
                // HealthController hpControl = enemy.GetComponent<HealthController>();
                // hpControl.RemoveFromScene();

            }
            Invoke(nameof(NextLevel), 3);
        }
    }

    private void EndGame(){
        notifPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    
    private void NextLevel(){
        killCount=0;
        scoreText.text = $"Killed: {killCount}";
        
        if (level == 3)
        {
            // If level 3 is complete, show the congratulations message
            // ShowCongratulations();
            notifPanel.SetActive(true);
            TMP_Text notifText = notifPanel.GetComponentInChildren<TMP_Text>();
            notifText.text="Game Completed";
            scoreText.text = "All Levels Completed. Going Back To Menu.";
            // Load the main menu after a delay (optional)
            Invoke(nameof(GoToMainMenu),3);
        }
        else
        {
            // Load the next level (increase the current level)
            level++;
            switch (level)
            {
            case 2:
                enemyToKill = 1;
                break;
            case 3:
                enemyToKill = 1;
                break;
            default:
                enemyToKill = 10; // Set a default enemyToKill or handle other levels accordingly
                break;
            }
        }
        goalText.text = $"Objective: Kill {enemyToKill}";

        Spawner[] spawners = FindObjectsOfType<Spawner>();
            foreach (Spawner spawner in spawners){
                spawner.TurnOn();
            }
    }
    private void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
