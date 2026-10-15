using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverWindow;
   
   public void EnableGameOver(){
    Debug.Log("Game Over");
    
    GameManager.EnableInput=false;
    Debug.Log($"Input is: {GameManager.EnableInput}");
    GameOverWindow.SetActive(true);
   }
   public void Restartlevel(){
        GameManager.EnableInput=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void GoToMainMenu(){
     GameManager.EnableInput=true;
     SceneManager.LoadScene("Scenes/Main Menu");
   }
}
