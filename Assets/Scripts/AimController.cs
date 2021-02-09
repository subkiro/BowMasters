using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    public  float strenth;
    public Transform shotPoint;
    private Vector2 direction;


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
        Vector2 bowPos = this.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPos;
        transform.right = direction;


        if (Input.GetMouseButtonDown(0)) {

            Throw();
            
        }

        dotsVisuals.DrawPoints(direction,strenth,spaceBetweenPoints);
    }


    void Throw() {
        GameObject bow = Instantiate(BulletPrefab, shotPoint.position,shotPoint.rotation);
        bow.GetComponent<Rigidbody2D>().velocity = transform.right * strenth;
        
    }


   
}
