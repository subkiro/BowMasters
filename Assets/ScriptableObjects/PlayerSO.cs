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

    public GameObject InitializeCharacter(Vector3 initPosition, Quaternion initRotation, WeaponSO weapon,bool isAI = false)
    {
       

     
            GameObject PlayerObj = Instantiate(Prefab,initPosition,initRotation);
        if (isAI)
        {
            PlayerObj.layer = 12;  //Layer name for collisions PlayerAI = 12
        }
        else {
            PlayerObj.layer = 10; //Layer name for collisions Player

        }
            Player tmp = PlayerObj.AddComponent<Player>();
            tmp.InitPlayer(id, Name,PlayerFaceIcon, weapon );

            return PlayerObj;
      
        
    }


}
