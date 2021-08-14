using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Vector3 moveVector;
    private CharacterController controller;
    private float verticalVelocity = 0.0f;
    public float speed = 5.0f;
    public float gravity = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Movement();
    }

    private void Movement(){
        //X
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        if(moveVector.x ==0.0f){
            moveVector.x = Input.gyro.attitude.x*speed*2;
        }
        //Y
        moveVector.y = verticalVelocity;

        //Z
        moveVector.z = speed;
        controller.Move(moveVector*Time.deltaTime);

    }
    private void Gravity(){
        if(controller.isGrounded){
            verticalVelocity = -0.5f;
        }else
        {
            verticalVelocity -= gravity;
        }

    }
}
