using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{

    public Vector3 playerPosition;
    public List<Vector3> enemyPositions = new List<Vector3>();
    public List<Vector3> objectPositions = new List<Vector3> ( );
    public List<ObjectType> objectTypes = new List<ObjectType> ( );
}
