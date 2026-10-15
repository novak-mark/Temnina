using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu:MonoBehaviour
{
    public GameObject pauseMenu;
   public bool IsPaused;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("ESCAPE WAS PRESSED");
            if(IsPaused){
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    public void Pause(){
        pauseMenu.SetActive(true);
        GameManager.EnableInput=false;
        Time.timeScale=0;
        IsPaused=true;
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        GameManager.EnableInput=true;
        Time.timeScale=1;
             IsPaused=false;
    }
    public void ReturnMain(){
        Time.timeScale=1;
        SceneManager.LoadScene("Main Menu");
    }
    public void SaveGame(){
        SaveSystem.SavePlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<PHealth>());
         SaveSystem.SaveInventory(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>());
       Debug.Log("GAME AND INVENTORY SAVED");
    }
    public void Quit(){
        Application.Quit();
    }
}
