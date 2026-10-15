using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive: MonoBehaviour
{

    public bool isinRange;
    public KeyCode interactKey;
    public UnityEvent interact;
    public GameObject NotifyWindow;
    void Update()
    {
        if(isinRange){
            if(Input.GetKeyDown(interactKey)){
                interact.Invoke();
                SoundManager.PlaySound("OpenChest");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isinRange=true;
            Debug.Log("Player in range");
            NotifyWindow.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
          if(collision.gameObject.CompareTag("Player")){
            isinRange=false;
            NotifyWindow.SetActive(false);
            Debug.Log("Player is not in range");
        }
    }
}
