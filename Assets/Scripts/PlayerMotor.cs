using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    public float gravity = 12.0f;
    private float animationDuration = 3.0f;
    private bool isDeath = false;
    [SerializeField]
    private LayerMask ObstacleLayer;
    public float mytime =0;
    private bool tap,swipteLeft,swipeRight,swipeUp,swipeDown;
    private Vector2 swipeDelta,startTourch;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        mytime+=Time.deltaTime;
        checkColli();
        if(isDeath)return;
        if(mytime < animationDuration){
            controller.Move(Vector3.forward*Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
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
    public void SetSpeed(float modifier){
        speed =5.0f+modifier;

    }
    private void checkColli(){
        if(Physics.Raycast(this.transform.position,this.transform.forward,GetComponent<CharacterController>().radius+0.1f,ObstacleLayer))
        {
            Death();
        }
    }
    //Bug
    // private void OnControllerColliderHit(ControllerColliderHit hit) {
    //     if(hit.point.z > transform.position.z + controller.radius){
    //         Debug.Log("Hello");
    //         Destroy(hit.gameObject);
    //         Death();
    //     }
    // }
    private void Death(){
        isDeath=true;
        GetComponent<Score>().OnDeath();
    }

}
