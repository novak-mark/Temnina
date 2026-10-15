using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour{
   
    public GameObject loadingBar;
    public GameObject MainMenu;
    public Slider Slider;

    public void LoadGame(int index){
        StartCoroutine(LoadAsyncronously(index));
    }
        IEnumerator LoadAsyncronously(int index){
        loadingBar.SetActive(true);
         MainMenu.SetActive(false);
         GameManager.EnableInput=true;
        AsyncOperation oper=SceneManager.LoadSceneAsync(index);
       
        while(!oper.isDone){
            float progress=Mathf.Clamp01(oper.progress/0.9f);
           Slider.value=progress;
            yield return null;
        }
        }
}
