using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;

    public delegate void TakeDamageDelegate(object sender, int damage);
    public TakeDamageDelegate TakeDamageEvent;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(object sender, int damage) {
        TakeDamageEvent(sender,damage);
        
    }
}
