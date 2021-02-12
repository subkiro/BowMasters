using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControllerAI : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    public  float strenth;
    public Transform shotPoint;
    private GameObject arrow;
    
    

    void Start()
    {
        this.enabled = false;
    }


    void AiThrow()
    {
        Transform player1 = GameObject.FindGameObjectWithTag("Player1").transform;

        arrow.GetComponent<Rigidbody2D>().isKinematic = false;
        arrow.GetComponent<Bow>().enabled = true;

        float ranX = Random.Range(-2, 2);
        float ranY= Random.Range(-2, 2);
        float ranZ = 0;
        Vector3 randOffcet = new Vector3(ranX, ranY, ranZ);
        arrow.GetComponent<Rigidbody2D>().velocity = CalculateTrajectoryVelocity(transform.position, player1.transform.position + randOffcet, 5);

     
     
    }
    Vector3 CalculateTrajectoryVelocity(Vector3 origin, Vector3 target, float t)
    {
        float vx = (target.x - origin.x) / t;
        float vz = (target.z - origin.z) / t;
        float vy = ((target.y - origin.y) - 0.5f * Physics.gravity.y * t * t) / t;
        return new Vector3(vx, vy, vz);
    }

}
