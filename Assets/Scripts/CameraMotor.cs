using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationbDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0.0f,5.0f,5.0f);
    private float mytime =0;

    // Start is called before the first frame update
    void Start()
    {
        transition=0;
        if(!lookAt)lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position-lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        mytime += Time.deltaTime;
        moveVector = lookAt.position+startOffset;

        //x
        moveVector.x =0;
        //y
        moveVector.y = 3.0f;
        // if(moveVector.y < 2)  moveVector.y=2;
        // moveVector.y =Mathf.Clamp(moveVector.y,2.0f,17.0f);
        if(transition >=1.0f)
        {
            transform.position = moveVector;
        }
        else{
            transform.position = Vector3.Lerp(moveVector+animationOffset,moveVector,transition);
            transition = Mathf.Clamp(mytime/animationbDuration,0,1);
            // bug because use Time.time
            // transform.LookAt(lookAt.position+Vector3.up); 
        }
    }
}
