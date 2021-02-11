using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tools/BackGround Obj")]
public class BackgroundsSO : ScriptableObject
{
    public string id;
    public string Name;
    public GameObject Prefab;


    public GameObject InitializeBackground(Vector3 poisiton)
    {

        GameObject tmp = Instantiate(Prefab, poisiton, Quaternion.identity);
        tmp.tag = "Background";
        return tmp;
    }
        
    

}
