using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimController : MonoBehaviour
{
    public  float strenth;
    public Transform shotPoint;
    private Vector2 direction;
    private bool isPressed;
    private GameObject arrow;
    private CinemachineVirtualCamera playerCamera;

    //Points Visuals
    [SerializeField] public GameObject pointPrefab;
    public GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;
    private Vector3 mouseStartPos;
    [SerializeField] private UIHelper UIHelper;

    private TrajectoryDots dotsVisuals;

    private void Awake()
    {
        UIHelper.gameObject.SetActive(false);
        this.enabled = false;
        
    }
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera1")?.GetComponent<CinemachineVirtualCamera>();

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
                UIHelper.gameObject.SetActive(true);
                //This is prepere animation befor throw
                Animator anim = GamePlay.instance.Player1.GetComponent<Player>().animator;
                anim.Play("PrepereToThrow");


                mouseStartPos = GetMouseWorldPositon();
                playerCamera.m_Lens.OrthographicSize = 5;


            }
            if (Input.GetMouseButton(0) && isPressed)
            {
                
                Vector2 bowPos = this.transform.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = -(mousePosition - bowPos);
                transform.right = direction;
                arrow.transform.right = direction;

                float distanceFactor = Vector3.Distance(GetMouseWorldPositon(), shotPoint.position);

                //visualize dots
                strenth = Mathf.Clamp(distanceFactor*10, 0, 30);
                dotsVisuals.DrawPoints(direction, strenth, (spaceBetweenPoints+0.04f) / distanceFactor);


                //animate camera
                playerCamera.m_Lens.OrthographicSize = 5+ Mathf.Clamp(distanceFactor*0.3f,0,3f); 
                UIHelper.UpdateUIHelper(strenth*2+40, this.transform.rotation.z);
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
        foreach (Collider2D c in GetComponents<Collider2D>())
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
        SoundManager.instance.PlayVFX("Throw1");
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
        SoundManager.instance.PlayVFX("Throw1");

        Transform player1 = GamePlay.instance.Player1.transform;
        arrow = GamePlay.instance.Player2.GetComponent<Player>().NewWeapon();
        arrow.tag = "Bow";
        arrow.GetComponent<Bow>().ownerPlayer = "Player2";
        arrow.GetComponent<Collider2D>().enabled = true;


        arrow.GetComponent<Rigidbody2D>().isKinematic = false;
        arrow.GetComponent<Bow>().enabled = true;

        float ranX = Random.Range(-1, 1);
        float ranY = Random.Range(-3, 1);
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
