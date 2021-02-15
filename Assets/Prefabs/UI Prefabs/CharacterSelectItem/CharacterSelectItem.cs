using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image icon;
    private PlayerSO player;
    [SerializeField] public Button button;
   

    // Update is called once per frame
    public void InitializeItem (PlayerSO player)
    {
        this.icon.sprite = player.ProfilePic;
        this.player = player;
    }

    
}
