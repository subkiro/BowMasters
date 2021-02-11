using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Tools/Asset List")]
public class ArrayScriptable : ScriptableObject
{
    [SerializeField]private  List<PlayerSO> Characters_SObj;
    [SerializeField]private List<WeaponSO> Weapons_SObj;
    [SerializeField] private List<BackgroundsSO> Backgrounds_SObj;
    public List<PlayerSO> Get_Characters() {
        return Characters_SObj;
    }

    public List<WeaponSO> Get_Weapons()
    {
        return Weapons_SObj;
    }


    public List<BackgroundsSO> Get_Backgrounds()
    {
        return Backgrounds_SObj;
    }
}
