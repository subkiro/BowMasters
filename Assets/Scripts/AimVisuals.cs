using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] dots;
    Vector3 startPos, endPos;
    float distance;
    bool isPressed=false;
    void Start()
    {
        startPos = Vector3.zero;
    }


   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            
           
            this.transform.position = GetMouseWorldPositon();


        }
        if (Input.GetMouseButton(0) && isPressed)
        {
            OnDown();


            distance = Vector3.Distance(GetMouseWorldPositon(), startPos);
            Vector3 dir = GetMouseWorldPositon() - startPos;
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.localPosition = -dir.normalized * distance  * i *0.1f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            OnUp();
        }








      
    }


    void OnDown() {
       
        foreach (var item in dots)
        {
            item.gameObject.SetActive(true);
        }
    }
    void OnUp()
    {
        foreach (var item in dots)
        {
            item.gameObject.SetActive(false);
        }
    }


    private Vector3 GetMouseWorldPositon() {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
