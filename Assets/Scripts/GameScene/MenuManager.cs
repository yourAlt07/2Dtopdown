using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SettingsPanel;

    public void OpenPanel(){
        Time.timeScale=0;
        Panel.SetActive(true);
        
    }
    public void OpenSettings(){
        Time.timeScale=0;
        Panel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void CloseSettings(){
        Time.timeScale=0;
        Panel.SetActive(true);
        SettingsPanel.SetActive(false);
    }


    public void Continue(){
        if(Panel !=null){
            Time.timeScale=1;
            Panel.SetActive(false);

        }
    }
    public void Exit(){
        Application.Quit();
    }

}
