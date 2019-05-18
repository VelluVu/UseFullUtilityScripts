
using UnityEngine;

public class SyncCameraRotation : MonoBehaviour
{

    private void Start ( )
    {     
        transform.rotation = Camera.main.transform.rotation;
    }

}
