﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author = Veli-Matti Vuoti
/// 
/// </summary>
public class PlayerInput : MonoBehaviour
{
    PlayerControl player;
    public bool lockRotation;

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

        if ( !lockRotation )
        {
            player.movement.RotationalMove ( mouseX, mouseY );
        }
        

        if( Input.GetButton("Fire3"))
        {
            lockRotation = true;
        }
        if ( Input.GetButtonUp ( "Fire3" ) )
        {
            lockRotation = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            player.PCTeleport ( );
        }


    }
}
