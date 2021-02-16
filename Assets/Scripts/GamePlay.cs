using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private ArrayScriptable AssetList;
    [SerializeField] private Transform SpawnPos_Player1, SpawnPos_Player2;
    [SerializeField] public Transform dotContainer;
    public PlayerSO Player1_SO, Player2_SO;
    private WeaponSO weapon1, weapon2;
    public Player winner;

    public GameObject Player1, Player2;
    private GameObject background;

    public List<PlayerSO> PlayersList;
    private List<BackgroundSO> Backgrounds;


    public TMPro.TMP_Text logText;
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
        Backgrounds = AssetList.Get_Backgrounds();
    }

   

    //MenuFuctions
    public void SetPlayersFromScriptable(int index_p1, int index_p2) {

        Player1_SO = PlayersList[index_p1];
        Player2_SO = PlayersList[index_p2];
        weapon1 = Player1_SO.weapon;
        weapon2 = Player2_SO.weapon;

        logText.text = "UI player select ok";
        Debug.Log("UI player select ok");
    }


    public void SetPlayersFromScriptable(PlayerSO player1,PlayerSO player2)
    {

        Player1_SO = player1;
        Player2_SO = player2;

        weapon1 = Player1_SO.weapon;
        weapon2 = Player2_SO.weapon;

        logText.text = "UI player select ok";
        Debug.Log("UI player select ok");
    }

    //GameFunction
    public void InitPlayers()
    {
        if (Player1_SO != null && Player2_SO != null && weapon1 != null && weapon1 != null)
        {
            Player1 = Player1_SO.InitializeCharacter(SpawnPos_Player1.transform.position, SpawnPos_Player1.transform.rotation, weapon1);
            Player1.tag = "Player1";



            Vector3 spawnOffcet = new Vector3(Random.Range(-10, 10), 1, 0);
            Player2 = Player2_SO.InitializeCharacter(SpawnPos_Player2.transform.position+ spawnOffcet, SpawnPos_Player2.transform.rotation, weapon2,true);
            Player2.tag = "Player2";

            //This is for turning the AI player towords to the Plyaer
            Player2.transform.rotation =  new Quaternion(0, 180, 0,0);
            logText.text = "init player in Game ok";
            Debug.Log("init player in Game ok");

            GameStateController.instance.Player1State();
            //Send Start Match event 



            EventHandler.instance.StartMatch(this,Player1.GetComponent<Player>(),Player2.GetComponent<Player>());
        }
        else {
            logText.text = "You have to SetPlayers Before Initialize them: Player1_SO ("+Player1.name+ ") / Player2_SO (" + Player2.name + ") / weapon1(" + weapon1.name + ") / weapon1(" + weapon2.name + ") ";
            Debug.Log("You have to SetPlayers Before Initialize them: Player1_SO / Player2_SO / weapon1 / weapon1  some of them are NUL");
        }
        logText.text = "You have to SetPlayers Before Initialize them: Player1_SO (" + Player1.name + ") / Player2_SO (" + Player2.name + ") / weapon1(" + weapon1.name + ") / weapon1(" + weapon2.name + ") ";


    }

    public void InitBackground(int Background_index) {

            background =  Backgrounds[Background_index].InitializeBackground(new Vector3(0, -5, 0));
           
            logText.text = "BackGround in Game ok: " + Backgrounds[Background_index].name;
            Debug.Log("BackGround in Game ok");
      
    }




    //Test functions for UI
    public void SetPlayers_UI() {

        SetPlayersFromScriptable(0, 1);
    }


    public void PrepereForNewMatch() {
     
        Destroy(Player1);
        Destroy(Player2);
        Destroy(background);
        foreach (Transform dot in dotContainer)
        {
            Destroy(dot.gameObject);
        }


        winner = null;
        
    }
    public void OnMatchStart(object sender) {
        PrepereForNewMatch();
        InitBackground(0);
        InitPlayers();
    }

    private void OnEnable()
    {
        EventHandler.instance.MatchStartAction += OnMatchStart;
        EventHandler.instance.WinnerEndMatchEvent += SetWinner;

    }
    private void OnDisable()
    {
        EventHandler.instance.MatchStartAction -= OnMatchStart;
        EventHandler.instance.WinnerEndMatchEvent -= SetWinner;
    }
    private void SetWinner(object sender, Player winner) {
        this.winner = winner;
    }
}

