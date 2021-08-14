using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationbDuration = 2.5f;
    public Vector3 animationOffset = new Vector3(0.0f,5.0f,5.0f);
    public float setY;
    private float mytime =0;
    void Start()
    {
        transition=0;
        if(!lookAt)lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position-lookAt.position;
        setY = this.transform.position.y;
    }
    void Update()
    {
        mytime += Time.deltaTime;
        moveVector = lookAt.position+startOffset;

        //x
        moveVector.x =0;
        //y
        moveVector.y = setY;
        if(transition >=1.0f)
        {
            transform.position = moveVector;
        }
        else{
            transform.position = Vector3.Lerp(moveVector+animationOffset,moveVector,transition);
            transition = Mathf.Clamp(mytime/animationbDuration,0,1);
            transform.LookAt(lookAt.position+Vector3.up); 
        }
    }
}