using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private float length,startpos,distance,temp;
    public GameObject cam;
    public float Effect;
    void Start()
    {
        startpos=transform.position.x;
        length=GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        temp=(cam.transform.position.x*(1-Effect));
        distance= (cam.transform.position.x*Effect);
        transform.position=new Vector3(startpos+distance,transform.position.y,transform.position.z);
    if(temp>startpos+length){
        startpos+=length;
    }
    else if(temp<startpos-length){
         startpos-=length;
    }
    }
}
