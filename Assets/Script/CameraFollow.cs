using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject followTarget;

    [SerializeField]
    private float cameraSpeed=4.0f;

    [SerializeField]
    private Vector3 targetPosition;

    private Camera theCamera;
    private BoxCollider2D cameraLimits;
    private Vector3 minLimits, maxLimits;
    float halfWidth,halfHeight;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition=new Vector3(followTarget.transform.position.x,
                    followTarget.transform.position.y,
                    this.transform.position.z);
        
        this.transform.position=Vector3.Lerp(this.transform.position,
        targetPosition,cameraSpeed*Time.deltaTime);

        float clampX=Mathf.Clamp(this.transform.position.x,minLimits.x+halfWidth,maxLimits.x-halfWidth);
        float clampY=Mathf.Clamp(this.transform.position.y,minLimits.y+halfHeight,maxLimits.y-halfHeight);
        this.transform.position=new Vector3(clampX,clampY,this.transform.position.z);


    }

    public void ChangeLimits(BoxCollider2D newCamelaLimit){

        minLimits=newCamelaLimit.bounds.min;
        maxLimits=newCamelaLimit.bounds.max;

        theCamera = GetComponent<Camera>();
        halfWidth=theCamera.orthographicSize;
        halfHeight=halfWidth/Screen.width*Screen.height;
    }
}
