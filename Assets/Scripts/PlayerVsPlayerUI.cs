using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerVsPlayerUI : MonoBehaviour
{

    //Preview Character
    [SerializeField] TMP_Text CharcterName1;
    [SerializeField] TMP_Text CharcterName2;
    [SerializeField] Image CharacterPic1;
    [SerializeField] Image CharacterPic2;


    public void InitializedPlayerVsPlayer(PlayerSO p1, PlayerSO p2)
    {
        CharcterName1.text = p1.Name;
        CharacterPic1.sprite = p1.ProfilePic;

        CharcterName2.text = p2.Name;
        CharacterPic2.sprite = p2.ProfilePic;
    }

    private void Start()
    {
        ShowPlayerVSPlayer();


    }

    public void ShowPlayerVSPlayer()
    {

            PlayerSO p1 = GamePlay.instance.Player1_SO;
            PlayerSO p2 = GamePlay.instance.Player2_SO;
            InitializedPlayerVsPlayer(p1, p2);
 
    }

    private void OnDestroy()
    {
       
        EventHandler.instance.StartMatch(this);

    }

}
