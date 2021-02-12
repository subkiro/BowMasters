using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public  float strenth;
    public Transform shotPoint;
    private Vector2 direction;
    private bool isPressed;
    private GameObject arrow;

    //Points Visuals
    [SerializeField] public GameObject pointPrefab;
    public GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;

    private TrajectoryDots dotsVisuals;
    void Start()
    {
        this.enabled = false;
        dotsVisuals = new TrajectoryDots(pointPrefab, numOfPoints, shotPoint);
    }

    // Update is called once per frame

    //Layer 8  = Bow
    //Layer 9 = Backgournd
    //Layer 10 = Player
    //Layer 11 = BowAI
    //Layer 12 = PlayerAi


    void Update()
    {

        if (GameStateController.instance.GameState.GetCurrentAnimatorStateInfo(0).IsName("Player1"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressed = true;

                //Prepere Arrow
                arrow = GamePlay.instance.Player1.GetComponent<Player>().NewWeapon();
                arrow.tag = "Bow";
                arrow.GetComponent<Bow>().ownerPlayer = "Player1";
                arrow.GetComponent<Rigidbody2D>().isKinematic = true;
                arrow.GetComponent<Bow>().enabled = false;
            }
            if (Input.GetMouseButton(0) && isPressed)
            {

                Vector2 bowPos = this.transform.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = -(mousePosition - bowPos);
                transform.right = direction;
                arrow.transform.right = direction;

                float distanceFactor = Vector3.Distance(GetMouseWorldPositon(), shotPoint.position);
                strenth = Mathf.Clamp(distanceFactor * 10, 0, 30);
                dotsVisuals.DrawPoints(direction, strenth, spaceBetweenPoints / distanceFactor);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isPressed = false;


                Throw();

            }


        }



    }




    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }


    void Throw() {
        //  GameObject bow = Instantiate(BulletPrefab, shotPoint.position,shotPoint.rotation);
        arrow.GetComponent<Rigidbody2D>().isKinematic = false;
        arrow.GetComponent<Bow>().enabled = true;
        arrow.GetComponent<Rigidbody2D>().velocity = transform.right * strenth;
        GamePlay.instance.Player1.GetComponent<Player>().animator.Play("Throw");
        GameStateController.instance.FlyingBowState();
    }



    private Vector3 GetMouseWorldPositon()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }






    public void PrepearToThrowAI() {
        IEnumerator c = ThrowAfterDelay(2.5f);
        StartCoroutine(c);
    }
    
    
    
    public IEnumerator ThrowAfterDelay(float delayTime) {

      
            yield return new WaitForSeconds(delayTime);
            AiThrow();
       
    }

    public void AiThrow()
    {
        Transform player1 = GamePlay.instance.Player1.transform;
        arrow = GamePlay.instance.Player2.GetComponent<Player>().NewWeapon();
        arrow.tag = "Bow";
        arrow.GetComponent<Bow>().ownerPlayer = "Player2";
        arrow.GetComponent<Collider2D>().enabled = true;


        arrow.GetComponent<Rigidbody2D>().isKinematic = false;
        arrow.GetComponent<Bow>().enabled = true;

        float ranX = Random.Range(-5, 5);
        float ranY = Random.Range(-1, 1);
        float ranZ = 0;
        Vector3 randOffcet = new Vector3(ranX, ranY, ranZ);
        arrow.GetComponent<Rigidbody2D>().velocity = CalculateTrajectoryVelocity(transform.position, player1.transform.position + randOffcet, Random.Range(3,5));
        GameStateController.instance.FlyingBowState();


    }
    Vector3 CalculateTrajectoryVelocity(Vector3 origin, Vector3 target, float t)
    {
        float vx = (target.x - origin.x) / t;
        float vz = (target.z - origin.z) / t;
        float vy = ((target.y - origin.y) - 0.5f * Physics.gravity.y * t * t) / t;
        return new Vector3(vx, vy, vz);
    }

}
