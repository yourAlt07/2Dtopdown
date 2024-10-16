using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject SettingsPanel;

    public void Play(){
        SceneManager.LoadScene("Game");
    }
    public void OpenSettings(){
        mainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void CloseSettings(){
        mainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
}
