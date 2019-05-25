using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    
    public static void ChangeColor(GameObject obj, Color color)
    {

        if ( obj != null)
        {

            MeshRenderer [ ] meshrenderers = obj.GetComponents<MeshRenderer> ( );

            foreach ( MeshRenderer meshRenderer in meshrenderers )
            {
                meshRenderer.material.color = color;
            }

        }

    }

}
