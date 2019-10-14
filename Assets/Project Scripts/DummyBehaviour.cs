using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour
{

    public Animator swordAnim;

    public int action;
    void Start()
    {
        swordAnim.SetInteger("quadrant", action);
        InvokeRepeating("Attack", 0f, 5f);
    }

    void Attack(){
        if(action>0)
            swordAnim.SetTrigger("strike");
        else 
            swordAnim.SetTrigger("block");
    }
    
}
