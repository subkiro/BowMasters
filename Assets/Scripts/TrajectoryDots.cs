using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDots: MonoBehaviour
{
    //Points Visuals
     GameObject pointPrefab;
     GameObject[] points;
     int numOfPoints;
     float spaceBetweenPoints;
     Vector3 direction;
     Transform shotPoint;
     float force;

    public TrajectoryDots(GameObject pointPrefab, int numOfPoints,Transform shotPoint)
    {
        this.pointPrefab = pointPrefab;
        this.numOfPoints = numOfPoints;
        this.shotPoint = shotPoint;
        InitPoints();
    }
    
    public void InitPoints()
    {

        points = new GameObject[numOfPoints];
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, shotPoint.position, Quaternion.identity);
        }
    }

    private Vector2 PointPosition(float t)
    {
        Vector2 position = ((Vector2)shotPoint.position + (Vector2)direction.normalized * this.force * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    public void DrawPoints(Vector2 direction,float force,float spaceBetweenPoints)
    {

        this.direction = direction;
        this.force = force;
        this.spaceBetweenPoints = spaceBetweenPoints;
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }

    }
}
