using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public float NormalSpeed;
    public float RunSpeed;

     public float Force;
    private float Speed;
    private Rigidbody2D _rigidBody2d;
    private Animator anim;
    private bool jump;
    private bool canMove;
    private bool isRunning=false;
    private bool isCrouching;
    private bool isFacingleft=false;
    private AudioSource src;
    private void Start()
    {
        _rigidBody2d=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        src=GetComponent<AudioSource>();
       canMove=true;
    }
    void Animations(){
       if(GameManager.EnableInput){
           if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.RightArrow))) && !isRunning){
            anim.SetBool("PcanWalk",true);
            
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
            anim.SetBool("PcanWalk",false);
        }
        //skakanje
        if(Input.GetButtonDown("Jump")){
            anim.SetBool("PisJumping",true);
        }
        if(Input.GetButtonUp("Jump")){
             anim.SetBool("PisJumping",false);
        }
      
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            anim.SetBool("HandAttack",false);
        }
        //crouching
        if(Input.GetKeyDown(KeyCode.C)){
            if(isCrouching){
                isCrouching=false;
                anim.SetBool("Crouch",false);
            }
            else {
                isCrouching=true;
                anim.SetBool("Crouch",true);
            }
        }
        //running
        if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))){
            if(!src.isPlaying){
                src.Play();
            }
            isRunning=true;
            Speed=RunSpeed;
            anim.SetBool("Run",true);
        }
        else {
            src.Stop();
            anim.SetBool("Run",false);
            Speed=NormalSpeed;
            isRunning=false;
        }
       }
    }
    private void Update()
    {
        var Movement=Input.GetAxis("Horizontal");
        Debug.Log(Movement);
        Animations();
        if(GameManager.EnableInput){
        if(canMove){
        transform.position+= new Vector3(Movement,0,0)*Time.deltaTime*Speed;
        }
        if(Movement>0){
            isFacingleft=false;
        }
        if(Movement<0 && canMove){
            transform.rotation=Quaternion.Euler(0,180,0);
            isFacingleft=true;
        }
        else if(canMove && !isFacingleft){
           transform.rotation=Quaternion.identity;
         
        }
        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidBody2d.velocity.y) < 0.001f){
            
            _rigidBody2d.AddForce(new Vector2(0,Force),ForceMode2D.Impulse);
        }
        }
    }
}