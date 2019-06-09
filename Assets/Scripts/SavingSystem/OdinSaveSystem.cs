using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OdinSaveSystem : MonoBehaviour
{

    private void OnEnable ( )
    {
        OdinSaveData.OnSave += OnSaveGame;
        OdinSaveData.OnLoad += OnLoadGame;
    }

    private void OnDisable ( )
    {
        OdinSaveData.OnSave -= OnSaveGame;
        OdinSaveData.OnLoad -= OnLoadGame;
    }

    public void OnSaveGame ( SaveDataStorage saveData)
    {
        string filePath = Application.persistentDataPath + saveData.saveName;
        byte [ ] bytes = SerializationUtility.SerializeValue ( saveData, DataFormat.Binary );
        File.WriteAllBytes ( filePath, bytes );
        Debug.Log ( "CREATED SAVE GAME  " + filePath );
    }

    public SaveDataStorage OnLoadGame ( string fileName )
    {

        string filePath = Application.persistentDataPath + fileName;

        if ( File.Exists ( filePath ) )
        {
            SaveDataStorage saveData = new SaveDataStorage ( );
            byte [ ] bytes = File.ReadAllBytes ( filePath );
            saveData = SerializationUtility.DeserializeValue<SaveDataStorage> ( bytes, DataFormat.Binary );
            Debug.Log ( "LOADED SAVE GAME  " + filePath );
            return saveData;      
        }
        else
        {
            Debug.LogError ( "NO FILE FOUND " + filePath );
            return null;
        }
    }
}
