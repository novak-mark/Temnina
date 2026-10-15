using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems: MonoBehaviour
{
    public List<GameObject> ItemPrefab=new List<GameObject>();
   
    
    public bool isRandomized;
    void Start()
    {
        SpawnObject();
    }

    void SpawnObject(){
        int index;
        if(isRandomized){
            index= Random.Range(0,ItemPrefab.Count);
        }
        else {
            index=0;
        }
        /*Preverjamo če je naš list kaj vsebuje*/
        if(ItemPrefab.Count>0){
            Instantiate(ItemPrefab[index],transform.position,transform.rotation);
        }
    }
   
 
}
