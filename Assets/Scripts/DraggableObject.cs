using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTrans;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform ObjectGrabTrans)
    {
        this.objectGrabPointTrans = ObjectGrabTrans;
        objectRigidBody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTrans = null;
        objectRigidBody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTrans != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTrans.position, Time.deltaTime * 10f);
            objectRigidBody.MovePosition(newPosition);
        }
    }
}
