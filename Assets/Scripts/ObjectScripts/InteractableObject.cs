using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author = Veli-Matti Vuoti
/// 
/// </summary>
public class InteractableObject : MonoBehaviour, ISaveAbleObject
{

    [SerializeField] Color hoveringColor;
    [SerializeField] Color selectedColor;
    [SerializeField] Color examHoveringColor;
    [SerializeField] Color standardColor;
    [SerializeField] Color criticalColor;

    public ObjectType objectType;
    public bool manuallyPickedColors;

    public bool selected;

    private void OnEnable ( )
    {
        PlayerControl.mouseHoverIn += MouseHovering;
        PlayerControl.mouseHoverOut += MouseExit;
        PlayerControl.mouseClick += MouseClick;
    }

    private void OnDisable ( )
    {
        PlayerControl.mouseHoverIn -= MouseHovering;
        PlayerControl.mouseHoverOut -= MouseExit;
        PlayerControl.mouseClick -= MouseClick;
    }

    public void Start ( )
    {
        ObjIndicatorColor ( );
    }

    private void ObjIndicatorColor ( )
    {
        if ( !manuallyPickedColors )
        {
            hoveringColor = Color.yellow;
            selectedColor = Color.yellow;
            examHoveringColor = Color.yellow;
            standardColor = Color.green;
            criticalColor = Color.red;
        }

        if ( GameController.instance.gameMode == GameMode.Tutorial ||
                    GameController.instance.gameMode == GameMode.Training )
        {
            switch ( objectType )
            {
                case ObjectType.CriticalObject:
                    hoveringColor = criticalColor;
                    selectedColor = criticalColor;
                    break;
                case ObjectType.StandardObject:
                    hoveringColor = standardColor;
                    selectedColor = standardColor;
                    break;
                default:
                    break;
            }
        }
        else if ( GameController.instance.gameMode == GameMode.Exam )
        {
            switch ( objectType )
            {
                case ObjectType.CriticalObject:
                    hoveringColor = examHoveringColor;
                    selectedColor = criticalColor;
                    break;
                case ObjectType.StandardObject:
                    hoveringColor = examHoveringColor;
                    selectedColor = standardColor;
                    break;
                default:
                    break;
            }
        }
    }

    public void MouseHovering ( object sender, RayCastData hitData )
    {
        if ( hitData.target == transform )
        {
            Debug.Log ( "IM HOVERED OVER" );
            ExtensionMethods.ChangeColor ( gameObject, hoveringColor );
        }
    }

    public void MouseExit ( object sender, RayCastData hitData )
    {
        if ( hitData.target == transform )
        {
            Debug.Log ( "IM HOVERED EXIT" );
            PlayerControl pl = ( PlayerControl ) sender;
            if ( pl.selectedObject != gameObject )
            {
                selected = false;
                ExtensionMethods.ChangeColor ( gameObject, Color.white );
            }
        }
    }

    public void MouseClick ( object sender, RayCastData hitData )
    {
        if ( hitData.target == transform )
        {
            Debug.Log ( "IM CLICKED" );
            PlayerControl pl = ( PlayerControl ) sender;
            if ( pl.selectedObject != gameObject )
            {
                selected = true;
                ExtensionMethods.ChangeColor ( gameObject, selectedColor );
            }
            else
            {
                selected = false;
                ExtensionMethods.ChangeColor ( gameObject, Color.white );
            }
        }
    }

    public void MyType ( SaveData saveStorage )
    {
        saveStorage.objectTypes.Add ( objectType );
    }

    public void MyPosition ( SaveData saveStorage )
    {
        saveStorage.objectPositions.Add ( transform.position );
    }
}
