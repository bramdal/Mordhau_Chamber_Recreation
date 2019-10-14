using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordbehaviour : MonoBehaviour
{
    [Header("State bools")]
    public bool attack = false;
    public bool windUp = false;
    public bool swing = false;
    public bool block = false;

    [Header("Public references")]
    public ParticleSystem sparkEffect;
    
    public AudioSource chamberSound;
    public AudioSource blockSound;

 

    void SetWindUp(){
        attack = true;
        windUp = true;
        swing = false;
    }

    void SetSwing(){
        windUp = false;
        swing = true;
    }

    public void Idle(){
        attack = false;
        windUp = false;
        swing = false;
        block = false;
    }

    void Block(){
        block = true;
    }

    public void Interrupt(){
        GetComponent<Animator>().SetTrigger("idle");
        Idle();
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Weapon"){
            Swordbehaviour otherWeapon = other.gameObject.GetComponent<Swordbehaviour>();
            if(attack){
                if(windUp){
                    if(otherWeapon.swing){
                        otherWeapon.Interrupt(); 
                        print("chambered");
                        ContactPoint contact = other.GetContact(0);
                        if(sparkEffect!= null){
                            sparkEffect.transform.position = contact.point;
                            sparkEffect.Emit(20);
                        }  
                        if(chamberSound!=null)
                            chamberSound.Play(); 
                    }    
                }
                else if(swing){
                    if(otherWeapon.block){
                        print("blocked");
                        Interrupt();
                        if(blockSound!=null)
                            blockSound.Play(); 
                        if(sparkEffect!=null)
                            sparkEffect.Emit(20);    
                    }
                }
            }   
        }
    }
}
