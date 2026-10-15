using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBars : MonoBehaviour
{
   
    public Slider slider;
    public Color High;
    public Color Low;
    public Vector3 Offset;

   
    void Update()
    {

        slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position+Offset);
    }
     public void SetHealth(int health, int maxHealth){
        slider.gameObject.SetActive(health<maxHealth);
         slider.value=health;
         slider.maxValue=maxHealth;
         slider.fillRect.GetComponentInChildren<Image>().color=Color.Lerp(Low,High,slider.normalizedValue);
        
     }
}
