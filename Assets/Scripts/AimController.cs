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
    void Start()
    {

        InitPoints();
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

        DrawPoints();
    }


    void Throw() {
        GameObject bow = Instantiate(BulletPrefab, shotPoint.position,shotPoint.rotation);
        bow.GetComponent<Rigidbody2D>().velocity = transform.right * strenth;
        
        Destroy(bow, 2f);
    }


    public void InitPoints() {

        points = new GameObject[numOfPoints];
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, shotPoint.position, Quaternion.identity);  
        }
    }

    private Vector2 PointPosition(float t) {
        Vector2 position = ((Vector2)shotPoint.position +direction.normalized*strenth*t)+0.5f*Physics2D.gravity *(t*t);
        return position;
    }

    private void DrawPoints() {
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i*spaceBetweenPoints);
        }
    
    }
}
