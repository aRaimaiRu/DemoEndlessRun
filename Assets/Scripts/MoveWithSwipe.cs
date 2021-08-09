    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveWithSwipe : MonoBehaviour
{
    private CharacterController controller;
    public SwipeTest swipeTest;
    private Animator animator;
    public float jumpspeed = 3;
    private float mytime;
    private bool isground=true;
    
  
    private void Start() {
        controller = GetComponent<CharacterController>();
        swipeTest = GetComponent<SwipeTest>();
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        mytime+=Time.deltaTime;
        if(swipeTest.swipeUp &&  mytime> 3.0f && isground ){

            animator.SetBool("jumping",true);
            isground=false;
            StartCoroutine(myjump(Vector3.up*jumpspeed));
            
        }
    }
    private IEnumerator myjump(Vector3 jumpto){
        for(int i=0;i<20;i++){
            controller.Move(jumpto*i/100);
            yield return null;
        }
        
        for(int i=20;i>0;i--){
            controller.Move(jumpto*i/100);
            yield return null;
        }
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag=="Ground"){
            animator.SetBool("jumping",false);
            isground = true;
        }

    }

  
}
