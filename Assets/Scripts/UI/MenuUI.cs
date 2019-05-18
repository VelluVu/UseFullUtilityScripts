using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{

    public Button [ ] buttons;

    private void Awake ( )
    {
        buttons [ 0 ].onClick.AddListener ( ( ) => StartGame ( ) );
        buttons [ 1 ].onClick.AddListener ( ( ) => Options ( ) );
        buttons [ 2 ].onClick.AddListener ( ( ) => Quit ( ) );
    
    }

    void StartGame ( )
    {
        UIController.instance.ActivateUIElement ( UIElements.MenuUI );     
        UIController.instance.ActivateUIElement ( UIElements.StartButton );
        SceneLoader.instance.SetSceneToLoad ( SceneNames.GameScene );
    }

    void Options ( )
    {
        UIController.instance.ActivateUIElement ( UIElements.OptionsUI );
        UIController.instance.ActivateUIElement ( UIElements.MenuUI );
    }

    void Quit ( )
    {
        Application.Quit ( );
    }

}
