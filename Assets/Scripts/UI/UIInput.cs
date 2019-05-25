using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{
    
    private void OnEnable ( )
    {
        PlayerControl.mouseHoverIn -= HandlePointerHit;
        PlayerControl.mouseHoverIn += HandlePointerHit;
        PlayerControl.mouseHoverOut -= HandlePointerLeft;
        PlayerControl.mouseHoverOut += HandlePointerLeft;
        PlayerControl.mouseClick -= HandlePointerClick;
        PlayerControl.mouseClick += HandlePointerClick;
    }

    /// <summary>
    /// Handles Pointer Hit Event On UI Button
    /// </summary>
    /// <param name="sender">Class that sends the data </param>
    /// <param name="hitInfo">Information of the Raycast hit </param>
    public void HandlePointerHit ( object sender, RayCastData hitInfo )
    {
           
        Button button = hitInfo.target.gameObject.GetComponent<Button> ( );
        if ( button != null )
        {
            button.Select ( );         
        }

        Debug.Log ( "POINTER HITS UI" );

    }

    /// <summary>
    /// Handles Pointer Left Event On UI Button
    /// </summary>
    /// <param name="sender"> Class that sends the data </param>
    /// <param name="hitInfo"> Information of the Raycast hit </param>
    public void HandlePointerLeft ( object sender, RayCastData hitInfo )
    {
        

        Button button = hitInfo.target.gameObject.GetComponent<Button> ( );
        if ( button != null )
        {
            EventSystem.current.SetSelectedGameObject ( null );       
        }

        Debug.Log ( "POINTER LEFT UI" );

    }

    /// <summary>
    /// Handles Pointer Click Event on UI Button
    /// </summary>
    /// <param name="sender"> Class that sends the data </param>
    /// <param name="hitInfo"> Information of the Raycast hit </param>
    public void HandlePointerClick ( object sender, RayCastData hitInfo )
    {
          
        if ( EventSystem.current.currentSelectedGameObject != null )
        {
            ExecuteEvents.Execute ( EventSystem.current.currentSelectedGameObject, new PointerEventData ( EventSystem.current ), ExecuteEvents.submitHandler );        
        }

        Debug.Log ( "CLICKED UI" );

    }
}
