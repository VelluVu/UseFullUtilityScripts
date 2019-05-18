using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;


public class SetGradient : MonoBehaviour
{
   
    public Material material;

    public Color color1;
    public Color color2;

    void Start()
    {
     
        material.SetColor ( "_Color", color1 );
        material.SetColor ( "_Color2", color2 );
        
    }

    [Button]
    public void UpdateColors()
    {
        material.SetColor ( "_Color", color1 );
        material.SetColor ( "_Color2", color2 );
    }

}
