using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using Sirenix.OdinInspector;

public class UIController : SerializedMonoBehaviour
{
  
    [OdinSerialize]
    private Dictionary<UIElements, Transform> uIElementDictionary = new Dictionary<UIElements, Transform> ( );

    #region SINGLETON
    public static UIController instance;

    private void MakeSingleton()
    {
        if ( instance == null )
        {
            instance = this;
        }
        else if ( instance != this )
        {
            Destroy ( gameObject );
        }
    }

    #endregion

    private void Awake ( )
    {

        MakeSingleton ( );
        
    }

    public void ActivateUIElement( UIElements element)
    {

        if ( !uIElementDictionary [element].gameObject.activeSelf )
        {
            uIElementDictionary [ element ].gameObject.SetActive ( true );
        }
        else if ( uIElementDictionary [ element ].gameObject.activeSelf )
        {
            uIElementDictionary [ element ].gameObject.SetActive ( false );
        }

    }

}