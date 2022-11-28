using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    [SerializeField] private Transform cameraTrans;
    [SerializeField] private Transform objectGrabTrans;
    [SerializeField] private LayerMask layerMask;

    private DraggableObject draggableObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (draggableObject == null)
            {
                float pickUpDist = 0.5f;
                Physics.Raycast(cameraTrans.position, cameraTrans.forward, out RaycastHit hitInfo, pickUpDist, layerMask);
                if (hitInfo.transform.TryGetComponent(out draggableObject))
                {
                    draggableObject.Grab(objectGrabTrans);
                    Debug.Log(draggableObject);
                }
            }
            else
            {
                draggableObject.Drop();
                draggableObject = null;
            }
        }
    }
}
