using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author = Veli-Matti Vuoti
/// 
/// </summary>
public class PlayerControl : MonoBehaviour
{
    [HideInInspector] public PlayerMovement movement;
    [HideInInspector] public PlayerEyes playerEyes;
    Transform rightHand;
    Transform leftHand;
    FixedJoint objSnapPoint;

    [Range ( 0, 15 )] public float rayCastDistance;
    public LayerMask hitMask;
    public LayerMask teleportMask;
    Camera eyeSight;
    RayCastData newHitData;

    public GameObject selectedObject;
    public GameObject hoveredGameObject;
    public bool hovering;
    public bool hasObjSelected;
    public bool senderActive;

    public delegate void MouseDelegate ( object sender, RayCastData hitData );
    public static event MouseDelegate mouseHoverIn;
    public static event MouseDelegate mouseHoverOut;
    public static event MouseDelegate mouseClick;

    private void Start ( )
    {
        movement = gameObject.GetComponent<PlayerMovement> ( );
        playerEyes = gameObject.GetComponentInChildren<PlayerEyes> ( );
        eyeSight = playerEyes.gameObject.GetComponent<Camera> ( );
        leftHand = gameObject.transform.GetChild ( 1 );
        rightHand = gameObject.transform.GetChild ( 2 );
        objSnapPoint = rightHand.GetComponent<FixedJoint> ( );

        RayCastData newHitData = new RayCastData ( );
        newHitData.distance = 0;
        newHitData.hitPoint = Vector3.zero;
        newHitData.target = null;
    }

    private void Update ( )
    {
        HasObjectSelected ( );
        RayCastToPointer ( );

    }

    private void HasObjectSelected ( )
    {
        if ( selectedObject != null )
        {
            hasObjSelected = true;
        }
        else
        {
            hasObjSelected = false;
        }
    }

    public void RayCastToPointer ( )
    {

        RaycastHit hit;

        Ray ray = eyeSight.ScreenPointToRay ( Input.mousePosition );
        bool rayHit = Physics.Raycast ( ray, out hit, rayCastDistance, hitMask );

        if ( rayHit )
        {
            if ( hit.collider.transform.gameObject.GetComponent<InteractableObject> ( ) )
            {
                senderActive = true;
                hovering = true;
                hoveredGameObject = hit.transform.gameObject;
                MouseHover ( hit );

                //Debug.Log("HOVERING ON OBJECT ELEMENT");

                if ( Input.GetMouseButtonDown ( 0 ) && hoveredGameObject == hit.transform.gameObject && !hasObjSelected )
                {
                    Debug.Log ( "SELECTED OBJECT" );
                    MouseClicked ( hit );
                    selectedObject = hit.transform.gameObject;
                    if (hit.distance <= 2f)
                    {
                        Debug.Log ( "PICKED UP THE OBJECT" );
                        hit.transform.position = rightHand.position;
                        objSnapPoint.connectedBody = hit.rigidbody;
                        objSnapPoint.connectedBody.useGravity = false;
                    }
                }
                else if ( Input.GetMouseButtonDown ( 0 ) && selectedObject == hoveredGameObject && selectedObject != null && hasObjSelected )
                {
                    Debug.Log ( "DESELECTED OBJECT" );
                    selectedObject = null;

                    DropObject ( );
                }
            }
            else
            {

                //Debug.Log("HOVERING ON UI ELEMENT");
                senderActive = true;
                hovering = true;
                hoveredGameObject = hit.transform.gameObject;
                MouseHover ( hit );

                if ( Input.GetMouseButtonDown ( 0 ) && senderActive )
                {
                    MouseClicked ( hit );
                }

            }
        }
        else
        {
            MouseExited ( hit );

            if ( Input.GetMouseButtonDown ( 0 ) && selectedObject != null )
            {
                Debug.Log ( "DESELECTED OBJECT" );
                selectedObject.AddComponent<InteractableObject> ( ).selected = false;
                ExtensionMethods.ChangeColor ( selectedObject, Color.white );
                selectedObject = null;

                DropObject ( );
            }

            senderActive = false;
            hovering = false;
        }

    }

    public void MouseHover ( RaycastHit hit )
    {
        if ( mouseHoverIn != null && senderActive )
        {
            newHitData.distance = hit.distance;
            newHitData.hitPoint = hit.point;
            newHitData.target = hoveredGameObject.transform;
            mouseHoverIn ( this, newHitData );
        }
    }

    public void MouseClicked ( RaycastHit hit )
    {
        if ( mouseClick != null && senderActive )
        {
            newHitData.distance = hit.distance;
            newHitData.hitPoint = hit.point;
            newHitData.target = hoveredGameObject.transform;
            mouseClick ( this, newHitData );
        }
    }

    public void MouseExited ( RaycastHit hit )
    {
        if ( mouseHoverOut != null && senderActive )
        {
            newHitData.distance = hit.distance;
            newHitData.hitPoint = hit.point;
            newHitData.target = hoveredGameObject.transform;
            mouseHoverOut ( this, newHitData );
        }
    }

    public void DropObject()
    {
        if ( objSnapPoint.connectedBody != null )
        {
            Debug.Log ( "DROPPED OBJECT" );
            objSnapPoint.connectedBody.useGravity = true;
            objSnapPoint.connectedBody = null;
        }
    }

    public void PCTeleport ( )
    {
        RaycastHit hit;

        Ray ray = eyeSight.ScreenPointToRay ( Input.mousePosition );
        bool rayHit = Physics.Raycast ( ray, out hit, rayCastDistance, teleportMask );

        if ( rayHit )
        {
            transform.position = hit.point;
        }

    }
}

public struct RayCastData
{
    public float distance;
    public Vector3 hitPoint;
    public Transform target;
}

