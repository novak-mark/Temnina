using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    Resolution[] res;
    public Dropdown resDropdown;
    void Start(){
        res=Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options= new List<string>();
        int currRes=0;
        for(int i=0;i<res.Length;i++){
            string opt= res[i].width + "x" + res[i].height;
            options.Add(opt);
            if(res[i].width==Screen.currentResolution.width && res[i].height==Screen.currentResolution.height){
                currRes=i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value=currRes;
        resDropdown.RefreshShownValue();
    }
    public void FullScreen(bool isFullscreen){
        Screen.fullScreen=isFullscreen;
    }
    public void SetResolution(int resIndex){
        Resolution resolution= res[resIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
}
