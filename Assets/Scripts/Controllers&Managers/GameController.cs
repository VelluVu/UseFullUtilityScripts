using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// @Author = Veli-Matti Vuoti
/// 
/// </summary>
public class GameController : MonoBehaviour
{

    #region SINGLETON
    public static GameController instance = null;

    private void MakeSingleton ( )
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

    public AudioSource sound_audioSource;
    public AudioSource music_audioSource;

    public GameMode gameMode;

    private void Awake ( )
    {
        MakeSingleton ( );   
    }
 
    #region DebuggingFunctions
    /// <summary>
    /// Convert this to menu button or keyboard input
    /// </summary>
    [Button]
    public void EnableGameUI()
    {      
        UIController.instance.ActivateUIElement ( UIElements.GameUI );
    }

    [Button]
    public void DeathSound ( )
    {
        AudioManager.instance.PlayOneShot ( sound_audioSource, Unit.Player, Sound.Death );
    }

    [Button]
    public void PainSound ( )
    {
        AudioManager.instance.PlayOneShot ( sound_audioSource, Unit.Player, Sound.Pain );
    }

    [Button]
    public void ChooseThemeMusic()
    {       
        AudioManager.instance.PlayMusicLoop ( music_audioSource, Music.Theme );        
    }

    [Button]
    public void ChooseBattleMusic ( )
    {     
        AudioManager.instance.PlayMusicLoop ( music_audioSource, Music.Battle );
    }
    #endregion


}
