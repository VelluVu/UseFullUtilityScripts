using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveSystem : SerializedMonoBehaviour
{
    [OdinSerialize]
    private Dictionary<string, SaveData> saveDataDictionary = new Dictionary<string, SaveData> ( ); //List of saves

    #region Singleton
    public static SaveSystem instance;

    private void Awake ( )
    {
        if ( instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy ( gameObject );
        }

    }
    #endregion

    private void Start ( )
    {
        SaveTheSaveDictionary ( );
        UpdateTheSaveDictionary ( );
    }

    /// <summary>
    /// Creates new save or replaces the old if not in the Dictionary
    /// </summary>
    /// <param name="saveName"> Save Name stored from inputfield </param>
    /// <param name="storedData"> Data stored elsewhere and then passed on here </param>
    public void CreateSave ( string saveName, SaveData storedData )
    {
        Debug.Log ( "Checking the dictionary" );
        if ( !saveDataDictionary.ContainsKey ( saveName ) )
        {
            Debug.Log ( "Adding new Save to the dictionary" );
            saveDataDictionary.Add ( saveName, storedData );
        }
        else
        {
            Debug.Log ( "Overriding the previous save" );
            saveDataDictionary [ saveName ] = storedData;
        }
    }

    [Button]
    public void StoreData ( string saveName )
    {
        SaveData saveData = new SaveData ( );

        var saveAbleObjects = FindObjectsOfType<MonoBehaviour> ( ).OfType<ISaveAbleObject> ( );
        var playerData = FindObjectsOfType<MonoBehaviour> ( ).OfType<ISaveablePlayer> ( );

        foreach ( var item in saveAbleObjects )
        {
            item.MyPosition ( saveData );
            item.MyType ( saveData );
        }

        foreach ( var item in playerData )
        {
            item.MyPosition ( saveData );
        }


        foreach ( var item in saveData.objectPositions )
        {
            Debug.Log ( "Object Positions " + item );
        }

        Debug.Log ( "Player Position " + saveData.playerPosition );

        foreach ( var item in saveData.objectTypes )
        {
            Debug.Log ( "OBJECT TYPE " + item.ToString ( ) );
        }

        CreateSave ( saveName, saveData );

    }

    public void SaveTheSaveDictionary ( )
    {
        string path = Application.persistentDataPath + "SaveDictionary.json";
        string json = JsonUtility.ToJson ( saveDataDictionary );
        StreamWriter streamWriter = File.CreateText ( path );
        streamWriter.Close ( );
        File.WriteAllText ( path, json );
        Debug.Log ( "Saved The SaveDictionary to " + path);
    }

    public void UpdateTheSaveDictionary ( )
    {

        string path = Application.persistentDataPath + "SaveDictionary.json";
        string json = File.ReadAllText ( path );
        saveDataDictionary = JsonUtility.FromJson<Dictionary<string, SaveData>> ( json );
        Debug.Log ( "Updated The Save Dictionary" );

    }

    [Button]
    public void SaveGameData ( string saveName )
    {
        if ( saveDataDictionary.ContainsKey ( saveName ) )
        {
            string path = Application.persistentDataPath + saveName + ".json";
            string json = JsonUtility.ToJson ( saveDataDictionary [ saveName ] );
            StreamWriter streamWriter = File.CreateText ( path );
            streamWriter.Close ( );

            File.WriteAllText ( path, json );

            Debug.Log ( "Saved Save Data to Json file " + path );

            SaveTheSaveDictionary ( );
        }
        else
        {
            Debug.LogError ( "SaveName was not valid" );
        }


    }

    [Button]
    public void LoadGameData ( string saveName )
    {
        if ( saveDataDictionary.ContainsKey ( saveName ) )
        {
            string path = Application.persistentDataPath + saveName + ".json";
            string json = File.ReadAllText ( path );
            saveDataDictionary [ saveName ] = JsonUtility.FromJson<SaveData> ( json );
            Debug.LogError ( "Loaded Save Data from Json file " + path );
        }
        else
        {
            Debug.LogError ( "SaveName was not valid" );
        }
    }

}
