using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static AudioClip drawSwordSound,sheatheSwordSound,chestSound,invSound,pickupSound,punchAirSound,swordAirSound,kickAirSound,skeletonHurtSound,skeletonDeathSound;
    public static AudioSource src;
    void Start()
    {
        drawSwordSound=Resources.Load<AudioClip>("swordDraw");
        sheatheSwordSound=Resources.Load<AudioClip>("swordSheath");
        chestSound=Resources.Load<AudioClip>("OpenChest");
        invSound=Resources.Load<AudioClip>("openInventory");
        pickupSound=Resources.Load<AudioClip>("itempickup");
        punchAirSound=Resources.Load<AudioClip>("punchAir");
        swordAirSound=Resources.Load<AudioClip>("swordAir");
        kickAirSound=Resources.Load<AudioClip>("kick");
        skeletonHurtSound=Resources.Load<AudioClip>("Skeletonhit");
        skeletonDeathSound=Resources.Load<AudioClip>("Skeleton_death");
        src=GetComponent<AudioSource>();
    }
   static public void PlaySound(string sound){
            switch(sound){
                case "DrawSword":
                src.PlayOneShot(drawSwordSound);
                break;
                case "SheathSword":
                src.PlayOneShot(sheatheSwordSound);
                break;
                case "OpenChest":
                src.PlayOneShot(chestSound);
                break;
                case "ItemPickup":
                src.PlayOneShot(pickupSound);
                break;
                case "OpenInventory":
                src.PlayOneShot(invSound);
                break;
                case "punchAir":
                src.PlayOneShot(punchAirSound);
                break;
                case "swordAir":
                src.PlayOneShot(swordAirSound);
                break;
                case "kick":
                src.PlayOneShot(kickAirSound);
                break;
                case "SkeletonHurt":
                src.PlayOneShot(skeletonHurtSound);
                break;
                case "SkeletonDeath":
                src.PlayOneShot(skeletonDeathSound);
                break;
                
            }
    }
    static public void StopSound(){
        src.Stop();
    }
}
