using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionWaypoint : MonoBehaviour
{
    // Indicator icon
    public CanvasGroup img;
    // The target (location, enemy, etc..)
    public Transform target;
    public Transform source;
    // UI Text to display the distance
    public TMP_Text  meter;
    // To adjust the position of the icon
    public Vector3 offset;

    bool isReady = false;

    private void Update()
    {
        if (!isReady)
        {

            img.alpha = 0;
            return;

        }
        
       


        if (target != null && source != null) {

            if (Vector3.Distance((target.transform.position - source.transform.position), source.transform.right) < 10)
            {
                img.alpha -= Time.deltaTime;
            }
            else {

                img.alpha += Time.deltaTime;
            }

            meter.text = ((int)Vector3.Distance(target.position, source.transform.position)).ToString() + "m";
        }
    }
    // Check if the target is behind us, to only show the icon once the target is in front



    public void ReadyToStart(object sender, Player p1, Player p2) {
        source = p1.transform;
        target = p2.transform;
        isReady = true;
    }

    public void Disable(object sender)
    {
       
        isReady = false;
        
    }
    private void OnEnable()
    {
        EventHandler.instance.ExitMatchAction += Disable;
        EventHandler.instance.StartMatchEvent += ReadyToStart;
    }
    private void OnDisable()
    {
        EventHandler.instance.ExitMatchAction -= Disable;
        EventHandler.instance.StartMatchEvent -= ReadyToStart;
    }



}
