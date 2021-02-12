using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tools/Weapon Obj")]
public class WeaponSO : ScriptableObject
{
    public string id;
    public string Name;
    public GameObject Prefab;


    public GameObject InitializeWeapon(Vector3 HoldingPoint)
    {

        GameObject tmp = Instantiate(Prefab, HoldingPoint, Quaternion.identity) ;
        tmp.AddComponent<Bow>();
        tmp.tag = "Bow";

        return tmp;
    }
        
    

}
