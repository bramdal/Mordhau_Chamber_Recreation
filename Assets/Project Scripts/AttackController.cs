using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{

    [Header("Public References")]
    public Transform viewPoint1;
    public Transform viewPoint2;
    float previousYRotation = 0f;
    float previousXRotation = 0f;
    int quadrant = -1;

    //cursor
    public Image director;
    public Swordbehaviour swordbehaviour;

    public Animator swordAnim;
    private void Start() {
        director.rectTransform.SetPivot(new Vector2(0.5f, -0.38f));   //pre calculated
    }

    private void Update() {
        CameraMovementDirection();
        previousYRotation = viewPoint1.eulerAngles.y;
        previousXRotation = viewPoint2.localEulerAngles.x;

        Block();
        Attack(quadrant);
        Feint();
    }

    void Attack(int quadrant){
        if(!swordbehaviour.block){
            if(Input.GetButtonDown("Fire1")){
                if(quadrant == 1){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 2){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 3){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 4){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 5){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 6){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 7){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }
                else if(quadrant == 8){
                    swordAnim.SetInteger("quadrant", quadrant);
                    swordAnim.SetTrigger("strike");
                }    
            }
        }
    }

    void Block(){
        if(!swordbehaviour.block)
            if(Input.GetButtonDown("Fire2")){
                swordAnim.SetTrigger("block");
            }
    }

    void Feint(){
        if(swordbehaviour.windUp){
            if(Input.GetKeyDown(KeyCode.Q)){
                swordAnim.SetTrigger("idle");
                swordbehaviour.Idle();
            }
        }
    }

    int CameraMovementDirection(){
        float currentYRotation = viewPoint1.eulerAngles.y;
        float currentXRotation = viewPoint2.localEulerAngles.x;
        
        if(currentXRotation < previousXRotation && currentYRotation == previousYRotation){
            //turned top
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 180f);
            quadrant = 1;
        }
        else if(currentXRotation < previousXRotation && currentYRotation > previousYRotation){
            //turned top right
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 135f);
            quadrant = 2;
        }
         else if(currentXRotation == previousXRotation && currentYRotation > previousYRotation){
            //turned right
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 90f);
            quadrant = 3;
        }
        else if(currentXRotation > previousXRotation && currentYRotation > previousYRotation){
            //turned bottom right
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 45f);
            quadrant = 4;
        }
        else if(currentXRotation > previousXRotation && currentYRotation == previousYRotation){
            //turned bottom
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 0f);
            quadrant = 5;
        }
        else if(currentXRotation > previousXRotation && currentYRotation < previousYRotation){
            //turned bottom left
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 315f);
            quadrant = 6;
        }
        else if(currentXRotation == previousXRotation && currentYRotation < previousYRotation){
            //turned left
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 270f);
            quadrant = 7;
        }
        else if(currentXRotation < previousXRotation && currentYRotation < previousYRotation){
            //turned top left
            director.rectTransform.eulerAngles = new Vector3(director.rectTransform.eulerAngles.x, director.rectTransform.eulerAngles.y, 225f);
            quadrant = 8;
        }
        return quadrant;
    }
    
}
