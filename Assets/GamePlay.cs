﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private ArrayScriptable AssetList;
    [SerializeField] private Transform SpawnPos_Player1, SpawnPos_Player2;
    private PlayerSO Player1_SO, Player2_SO;
    private WeaponSO weapon1, weapon2;


    public GameObject Player1, Player2;
    private GameObject background;

    private List<PlayerSO> PlayersList;
    private List<WeaponSO> WeaponsList;
    private List<BackgroundsSO> Backgrounds;
    // Start is called before the first frame update

    public static GamePlay instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        PlayersList =  AssetList.Get_Characters();
        WeaponsList = AssetList.Get_Weapons();
        Backgrounds = AssetList.Get_Backgrounds();
    }

    //MenuFuctions
    public void SetPlayersFromScriptable(int index_p1, int index_p2, int index_w1, int index_w2) {

        Player1_SO = PlayersList[index_p1];
        Player2_SO = PlayersList[index_p2];
        weapon1 = WeaponsList[index_w1];
        weapon2 = WeaponsList[index_w2];

        Debug.Log("UI player select ok");
    }

    //GameFunction
    public void InitPlayers()
    {
        if (Player1_SO != null && Player2_SO != null && weapon1 != null && weapon1 != null)
        {
            Player1 = Player1_SO.InitializeCharacter(SpawnPos_Player1.transform.position, SpawnPos_Player1.transform.rotation, weapon1);
            Player1.tag = "Player1";


            Player2 = Player1_SO.InitializeCharacter(SpawnPos_Player2.transform.position, SpawnPos_Player2.transform.rotation, weapon2);
            Player2.tag = "Player2";

            //This is for turning the AI player towords to the Plyaer
            Player2.transform.rotation =  new Quaternion(0, 180, 0,0);
            Debug.Log("init player in Game ok");
        }
        else {
            Debug.Log("You have to SetPlayers Before Initialize them: Player1_SO / Player2_SO / weapon1 / weapon1  some of them are NUL");
        }

        GameStateController.instance.Player1State();
    }

    public void InitBackground(int Background_index) {
        if (Background_index < Backgrounds.Count && Background_index>=0) {
            Backgrounds[Background_index].InitializeBackground(new Vector3(0, -5, 0));
            Debug.Log("BackGround in Game ok");
        }
    }




    //Test functions for UI
    public void SetPlayers_UI() {

        SetPlayersFromScriptable(0, 0, 0, 0);
    }

    public void InitBackground_UI()
    {

        InitBackground(0);
    }
    public void InitPlayersInLevel_UI() {

        InitPlayers();
    }
}
