using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerControl player;

    private void Start ( )
    {
        player = gameObject.GetComponent<PlayerControl> ( );
    }

    void Update ( )
    {
        float horizontalMove = Input.GetAxis ( "Horizontal" );
        float verticalMove = Input.GetAxis ( "Vertical" );
        float mouseX = Input.GetAxis ( "Mouse X" );
        float mouseY = Input.GetAxis ( "Mouse Y" );

        player.movement.DirectionalMove ( horizontalMove, verticalMove );
        player.movement.RotationalMove ( mouseX, mouseY );



    }
}
