using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [OdinSerialize]
    public Button [ ] buttons;
    [OdinSerialize]
    public TMP_InputField inputField;

    GameObject roomObj;
    Transform roomHolder;
    //RoomInfo [ ] roomsList;

    private void Awake ( )
    {
        roomHolder = transform.GetChild ( 1 ).GetChild ( 0 ).GetChild ( 0 ).transform;
        buttons [ 0 ].onClick.AddListener ( ( ) => CreateRoom ( ) );
        buttons [ 1 ].onClick.AddListener ( ( ) => LeaveLobby ( ) );
    }

    void CreateRoom ( )
    {
    

    }

    void LeaveLobby ( )
    {
        UIController.instance.ActivateUIElement ( UIElements.MenuUI );
        UIController.instance.ActivateUIElement ( UIElements.LobbyUI );
       
    }

    private void OnCreatedRoom ( )
    {
      
        UIController.instance.ActivateUIElement ( UIElements.LobbyUI );
        UIController.instance.ActivateUIElement ( UIElements.RoomUI );
        
    }

    private void OnJoinedRoom ( )
    {
        Debug.Log ( "Joined Room" );
           
    }

    private void OnReceivedRoomListUpdate ( )
    {
      
        Debug.Log ( "Added Room" );

       
    }

    private void RoomReceived ()
    {
       

    
    }

    private void RemoveOldRooms()
    {

    }

}
