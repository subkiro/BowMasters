using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;

    public delegate void TakeDamageDelegate(object sender);
    public TakeDamageDelegate TakeDamageEvent;

    public delegate void StartMatchDelegate(object sender, Player p1, Player p2);
    public StartMatchDelegate StartMatchEvent;


    public delegate void WinnerEndMatchDelegate(object sender, Player p);
    public WinnerEndMatchDelegate WinnerEndMatchEvent;


    public Action<object> MatchStartAction;
    public Action<object> MatchEndAction;
    public Action<object> ExitMatchAction;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(object sender)
    {
        TakeDamageEvent(sender);
        Debug.Log(sender);
    }

    public void StartMatch(object sender, Player p1, Player p2)
    {
        StartMatchEvent(sender, p1, p2);


    }
    public void Winner(object sender, Player p)
    {
        GamePlay.instance.winner = p;
        if (WinnerEndMatchEvent != null)
        {
            WinnerEndMatchEvent(sender, p);

        }
        Debug.Log("Winner is : " + p.transform.tag);
    }

    public void StartMatch(object sender)
    {
        MatchStartAction?.Invoke(sender);
    }

    public void MatchEnd(object sender)
    {
        MatchEndAction?.Invoke(sender);
    }

    public void ExitMatch(object sender)
    {
        ExitMatchAction?.Invoke(sender);
    }


}