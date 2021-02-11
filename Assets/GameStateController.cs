using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;
    public string nextState;

    public Animator GameState;
    private void Awake()
    {
        instance = this;
    }

    public void FlyingBowState() {


        Transform bow = GameObject.FindGameObjectWithTag("Bow")?.transform;
        CinemachineVirtualCamera camera = GameObject.FindGameObjectWithTag("ArrowCamera").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = bow;

        GameState.Play("BowFlying");
    }


    public void Player1State()
    {



        Transform Player = GamePlay.instance.Player1.transform;
        CinemachineVirtualCamera camera = GameObject.FindGameObjectWithTag("PlayerCamera1").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = Player;

        GameState.Play("Player1");
    }

    public void Player2State()
    {


        Transform Player = GamePlay.instance.Player2.transform;
        CinemachineVirtualCamera camera = GameObject.FindGameObjectWithTag("PlayerCamera2").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = Player;

        GameState.Play("Player2");
    }

    public void NextPlayer()
    {
        if (nextState == "Player1")
        {
            Player1State();
        }
        else {
            Player2State();
        }
       
    }

}
