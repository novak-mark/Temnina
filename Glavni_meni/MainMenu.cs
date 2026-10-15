using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
   public static bool isLoaded;
   
    public void LoadGame()
    {
        PlayerData data= SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.level);
        GameManager.EnableInput=true;
        isLoaded=true;
         
    }
    public void QuitGame(){
        Application.Quit();
    }
}
