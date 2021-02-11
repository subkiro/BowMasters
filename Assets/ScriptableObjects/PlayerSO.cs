using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tools/Player Obj")]
public class PlayerSO : ScriptableObject
{
    public string id;
    public string Name;
    public GameObject Prefab;
    private Sprite PlayerFaceIcon;
    bool isAvaliable = false;

    public GameObject InitializeCharacter(Vector3 initPosition, Quaternion initRotation, WeaponSO weapon)
    {
       

     
            GameObject PlayerObj = Instantiate(Prefab,initPosition,initRotation);
            Player tmp = PlayerObj.AddComponent<Player>();
            tmp.InitPlayer(id, Name,PlayerFaceIcon, weapon );

            return PlayerObj;
      
        
    }


}
