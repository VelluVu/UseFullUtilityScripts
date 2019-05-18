using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Button menuButton;

    private void Awake ( )
    {
        menuButton.onClick.AddListener ( ( ) => MenuButtonClick ( ) );
    }

    public void MenuButtonClick ( )
    {
        UIController.instance.ActivateUIElement ( UIElements.MenuUI );
    }
}
