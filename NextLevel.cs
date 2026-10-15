using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject loadingBar;
    public Slider Slider;
    public static bool isloaded=false;
        
        public void LoadGame(int index){

        StartCoroutine(LoadAsyncronously(index));
        isloaded=true;
    }
        IEnumerator LoadAsyncronously(int index){
        loadingBar.SetActive(true);
        AsyncOperation oper=SceneManager.LoadSceneAsync(index);
        while(!oper.isDone){
            float progress=Mathf.Clamp01(oper.progress/0.9f);
           Slider.value=progress;
            yield return null;
        }
        }
}
