using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public Text outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    public bool tap,swipteLeft,swipeRight,swipeUp,swipeDown;
    public float swipeRange;
    public float tapRange;

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        tap = swipeRight = swipteLeft = swipeDown = swipeUp = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        //mouse version
        if (Input.GetMouseButtonDown(0)){
            startTouchPosition = Input.mousePosition;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    swipteLeft = true;
                    // outputText.text = "Left";
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    swipeRight= true;
                    // outputText.text = "Right";
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {  
                    swipeUp = true;
                    // outputText.text = "Up";
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    swipeDown = true;
                    // outputText.text = "Down";
                    stopTouch = true;
                }

            }

        }
        
        //mouse version
        if(Input.GetMouseButtonUp(0)){
            currentPosition = Input.mousePosition;
            Vector2 Distance = currentPosition - startTouchPosition;
                if (Distance.x < -swipeRange)
                {
                    swipteLeft = true;
                    // outputText.text = "Left";
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    swipeRight= true;
                    // outputText.text = "Right";
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {  
                    swipeUp = true;
                    // outputText.text = "Up";
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    swipeDown = true;
                    // outputText.text = "Down";
                    stopTouch = true;
                }
            
        }
        //detect when tap but not move
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                // outputText.text = "Tap";
                tap = true;
            }

        }


    }
}
