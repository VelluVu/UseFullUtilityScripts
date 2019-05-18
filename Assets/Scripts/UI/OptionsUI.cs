using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{

    public Button [ ] buttons;
    public Slider [ ] sliders;
    public AudioMixer audioMixer;

    private void Awake ( )
    {
        buttons [ 0 ].onClick.AddListener ( ( ) => BackToMenu ( ) );
        sliders [ 0 ].onValueChanged.AddListener ( delegate { MasterCheckVal ( ); } );
        sliders [ 1 ].onValueChanged.AddListener ( delegate { SoundCheckVal ( ); } );
        sliders [ 2 ].onValueChanged.AddListener ( delegate { MusicCheckVal ( ); } );

    }

    void MasterCheckVal ( )
    {
        //Debug.Log ( "MASTER VOLUME " + sliders [ 0 ].value );
        audioMixer.SetFloat ( "MasterVol", Mathf.Log10 ( sliders [ 0 ].value ) * 20f );

    }

    void SoundCheckVal ( )
    {
        //Debug.Log ( "SOUND VOLUME " + sliders [ 1 ].value );
        audioMixer.SetFloat ( "SoundVol", Mathf.Log10 ( sliders [ 1 ].value ) * 20f );
    }

    void MusicCheckVal ( )
    {
        //Debug.Log ( "MUSIC VOLUME " + sliders [ 2 ].value );
        audioMixer.SetFloat ( "MusicVol", Mathf.Log10 ( sliders [ 2 ].value ) * 20f );
    }

    void BackToMenu ( )
    {

        UIController.instance.ActivateUIElement ( UIElements.MenuUI );
        UIController.instance.ActivateUIElement ( UIElements.OptionsUI );

    }

}
