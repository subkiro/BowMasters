using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("UI prefabs")]
    [SerializeField] private GameObject PvP_UI;

    public GameObject SelectCharacterItemPrefab;
    public Transform SelectionContainer;
    

    //Preview Character
    [SerializeField] TMP_Text CharcterName;
    [SerializeField] TMP_Text WeaponName;
    [SerializeField] Image CharacterPic;

    private PlayerSO SelectedPlayer;



    private void Start()
    {
        InitCharacterScrollList();
    }

    public void InitCharacterScrollList() {
        foreach (PlayerSO player in GamePlay.instance.PlayersList)
        {
            Debug.Log("Test from init characters");
            GameObject tmp = Instantiate(SelectCharacterItemPrefab, SelectionContainer);
            CharacterSelectItem item = tmp.GetComponent<CharacterSelectItem>();
            item.InitializeItem(player);
            if (player.isAvaliable)
            {
                item.button.interactable = true;
                item.button.onClick.AddListener(() => SelectCharacter(player));
                item.button.onClick.AddListener(() => SoundManager.instance.PlayVFX("ClickBuble"));
            }
            else {
                item.button.interactable = false;
            }
           
        }

        SelectionContainer.GetChild(0).transform.GetComponent<CharacterSelectItem>().button.onClick.Invoke();
        SoundManager.instance.PlayVFX("PlayerOneChoose");


    }


    public void SelectCharacter(PlayerSO player) {
       
        this.CharcterName.text = player.Name;
        this.CharacterPic.sprite = player.ProfilePic;
        this.WeaponName.text = player.weapon.Name;
        SelectedPlayer = player;
    }


    public PlayerSO GetRandomPlayer() {

        int randnum = Random.Range(1, GamePlay.instance.PlayersList.Count-1);

        return GamePlay.instance.PlayersList[randnum];
    }


    public void StartPlay()
    {

        if (SelectedPlayer != null) { 


            GamePlay.instance.SetPlayersFromScriptable(SelectedPlayer, GetRandomPlayer());
            GameObject pvp = Instantiate(PvP_UI, transform.parent);
            SoundManager.instance.PlayVFX("Pvp");
            Destroy(pvp, 1f);
            this.gameObject.SetActive(false);
        }
    }

    public void ExitApp()
    {
        Application.Quit();

    }

}
