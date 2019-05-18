using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SerializedMonoBehaviour
{

    #region SINGLETON

    public static AudioManager instance = null;

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

    [OdinSerialize]
    private Dictionary<Unit, Dictionary<Sound, List<AudioClip>>> soundDictionary = new Dictionary<Unit, Dictionary<Sound, List<AudioClip>>> ( );
    [OdinSerialize]
    private Dictionary<Music, List<AudioClip>> musicDictionary = new Dictionary<Music, List<AudioClip>> ( );

    private void Awake ( )
    {
        MakeSingleton ( );
    }

    public void PlayOneShot ( AudioSource source, Unit unit, Sound sound )
    {
        if ( soundDictionary [ unit ] [ sound ] == null )
        {
            return;
        }
        int audioClips = soundDictionary [ unit ] [ sound ].Count;
        source.PlayOneShot ( soundDictionary [ unit ] [ sound ] [ Random.Range ( 0, audioClips ) ] );

    }

    public void PlayMusicLoop ( AudioSource source, Music music )
    {
        if ( musicDictionary [ music ] == null )
        {
            return;
        }
        int maudioClips = musicDictionary [ music ].Count;
        source.Stop ( );
        source.clip = musicDictionary [ music ] [ Random.Range ( 0, maudioClips ) ];
        source.Play ( );
        source.loop = true;
    }

}
