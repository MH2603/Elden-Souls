using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public Transform target;
    [Space]
    //public Transform cameraTrans;
    //public Transform cameraPivotTrans;
    private Vector3 cameraPos;
    private LayerMask ignoreLayers;


    //public static CameraHandler instance;

    public float lookSpeed = 0.1f;
    public float followSpeed =  0.1f;
    //public float smoothTime = 0.1f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;
    public float minimumPivot = -35f;
    public float maximumPivot = 35f;

    //public float floatShereRaidus = 0.2f;
    //public float cameaCollisionOffset = 0.2f;
    //public float minimumCollisionOffset = 0.2f;

    //Vector3 offSet;
    private Vector3 currentV = Vector3.zero;

    private void Awake()
    {
        //instance = this;
        //defaultPosition = cameraTrans.localPosition.z;
        ignoreLayers = 10;

        //offSet = this.transform.position - target.position;
    }

    public void FollowTarget( float delta)
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, target.position, ref currentV, delta/ followSpeed);
        this.transform.position = targetPosition;

        //Vector3 targetPos = target.position + offSet;
        //transform.position = Vector3.SmoothDamp( this.transform.position, targetPos, ref currentV, smoothTime);
    }

    public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        lookAngle += (mouseXInput * lookSpeed) / delta;
        pivotAngle -= (mouseYInput * pivotSpeed) / delta;
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        rotation.x = pivotAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        target.transform.rotation = targetRotation;

        //this.transform.rotation = targetRotation;

        //rotation = Vector3.zero;
        //rotation.x = pivotAngle;

        //targetRotation = Quaternion.Euler(rotation);
        //cameraPivotTrans.localRotation = targetRotation;
    }

    
}
