using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class OdinSaveData : SerializedMonoBehaviour
{
    public List<Vector3> _saveablePositions = new List<Vector3> ( );
    public List<InteractableObject> _saveables = new List<InteractableObject> ( );
    public Vector3 _playerPosition;
    public GameObject _player;
    public delegate void SaveDelegate( SaveDataStorage saveData );
    public static event SaveDelegate OnSave;
    public delegate SaveDataStorage LoadDelegate ( string fileName );
    public static event LoadDelegate OnLoad;

    private void Start ( )
    {
        FindObjects ( );
    }

    public void FindObjects()
    {
        _saveablePositions.Clear ( );
        _saveables = FindObjectsOfType<InteractableObject> ( ).ToList ( );

        foreach ( var item in _saveables )
        {
            _saveablePositions.Add ( item.transform.position );
        }
        _player = GameObject.FindGameObjectWithTag ( "Player" );
        _playerPosition = _player.transform.position;
    }
  

    [Button]
    public void SaveData( string saveName )
    {
        if (OnSave != null )
        {
            SaveDataStorage saveStorage = new SaveDataStorage ( );
            saveStorage.saveablePositions = _saveablePositions;
            saveStorage.playerPosition = _playerPosition;
            saveStorage.saveName = saveName;
            OnSave ( saveStorage );

        }
    }

    [Button]
    public void LoadData (string fileName)
    {
        SaveDataStorage saveData = new SaveDataStorage ( );
        saveData = OnLoad?.Invoke ( fileName );
        for ( int i = 0 ; i < _saveablePositions.Count ; i++ )
        {
            _saveablePositions [ i ] = saveData.saveablePositions [ i ];
            _saveables [ i ].transform.position = _saveablePositions [ i ];
        }
        _playerPosition = saveData.playerPosition;
        _player.transform.position = _playerPosition;
    }
}

[Serializable]
public class SaveDataStorage
{
    public List<Vector3> saveablePositions = new List<Vector3> ( );
    public Vector3 playerPosition;
    public string saveName;
}
