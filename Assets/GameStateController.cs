using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;

    public Animator GameState;
    private void Awake()
    {
        instance = this;
    }

    public void FlyingBowState() {


        Transform bow = GameObject.FindGameObjectWithTag("Bow").transform;
        CinemachineVirtualCamera camera = GameObject.FindGameObjectWithTag("ArrowCamera").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = bow;

        GameState.Play("BowFlying");
    }


    public void Player1State()
    {


        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;
        CinemachineVirtualCamera camera = GameObject.FindGameObjectWithTag("PlayerCamera1").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = Player;

        GameState.Play("Player1");
    }


}
