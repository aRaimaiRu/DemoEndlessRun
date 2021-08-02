using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private CharacterController controller;
    public bool tap,swipteLeft,swipeRight,swipeUp,swipeDown;
    private Vector2 swipeDelta,startTouch;
    private bool isDraging;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSwipte();
    }

    private void GetSwipte(){
        //reset
        tap = swipteLeft = swipeRight = swipeDown = swipeUp = false;

        //check for inputs

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0)){
            isDraging = true;
            tap = true;
            startTouch = Input.mousePosition;
        }else if(Input.GetMouseButtonUp(0)){
            isDraging = false;
            startTouch = swipeDelta =Vector2.zero;

        }
        #endregion

        #region Mobile Inputs
        //atleast have 1 touche
        if(Input.touches.Length > 0){
            if(Input.touches[0].phase == TouchPhase.Began){
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;

            }else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
              Reset(); 
            }


        }
        #endregion
        //calculate distance
        swipeDelta = Vector2.zero;
        if(isDraging){
            if(Input.touches.Length > 0)
            swipeDelta = Input.touches[0].position-startTouch;
            else if(Input.GetMouseButton(0)) swipeDelta = (Vector2)Input.mousePosition - startTouch;
            

        }
        // Did we cross the deadzone
        if(swipeDelta.magnitude > 125){
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if(x<0) swipteLeft = true;
                else swipeRight = true;
            }else{
                //Up or down
                if(y<0) swipeDown = true;
                else swipeUp = true;

                
            }
            Reset();
            
        }

    }
    private void Reset() {
        startTouch = swipeDelta =Vector2.zero;
        isDraging = false;
        
    }
}
