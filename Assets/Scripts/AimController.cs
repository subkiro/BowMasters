using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    public  float strenth;
    public Transform shotPoint;
    private Vector2 direction;
    private bool isPressed;

    //Points Visuals
    [SerializeField] public GameObject pointPrefab;
    public GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;

    private TrajectoryDots dotsVisuals;
    void Start()
    {

        
        dotsVisuals = new TrajectoryDots(pointPrefab, numOfPoints, shotPoint);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;

        }
        if (Input.GetMouseButton(0) && isPressed)
        {

            Vector2 bowPos = this.transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = -(mousePosition - bowPos);
            transform.right = direction;

            float distanceFactor = Vector3.Distance(GetMouseWorldPositon(), shotPoint.position);
            strenth = Mathf.Clamp( distanceFactor*10,0,100);
            dotsVisuals.DrawPoints(direction, strenth, spaceBetweenPoints/distanceFactor);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            Throw();

        }





    }


    void Throw() {
        GameObject bow = Instantiate(BulletPrefab, shotPoint.position,shotPoint.rotation);
        bow.GetComponent<Rigidbody2D>().velocity = transform.right * strenth;
        
    }

    private Vector3 GetMouseWorldPositon()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

}
