using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public int startPoint;
    public Transform[] Points;
    private int i;
    private float distance;
    
    void Start()
    {
        transform.position=Points[startPoint].position;
    }

   
    void Update()
    {
        distance=Vector2.Distance(transform.position,Points[i].position);
        if(distance< 0.02f){
            i++;
            if(i==Points.Length){
                i=0;
            }
        }
        transform.position=Vector2.MoveTowards(transform.position,Points[i].position,speed*Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D colls){
        colls.transform.SetParent(transform);

    }
    void OnCollisionExit2D(Collision2D colls){
    colls.transform.SetParent(null);
    }
}
