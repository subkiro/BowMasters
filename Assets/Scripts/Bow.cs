using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hit;
    public string ownerPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (!hit) {
           
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != ownerPlayer) {
            rb.isKinematic = true;
            rb.mass = 0;
            this.gameObject.transform.SetParent(collision.transform);
            hit = true;
            rb.velocity = Vector3.zero;
           

            Destroy(this.gameObject,2f);
        }
    }
    private void OnDestroy()
    {
        this.gameObject.transform.tag = "Untagged";
        GameStateController.instance.NextPlayer();
    }

    private void OnEnable()
    {
        if (GameStateController.instance.GameState.GetCurrentAnimatorStateInfo(0).IsName("Player1"))
        {
            gameObject.layer = 8; //Bow layer
        }
        else {
            gameObject.layer = 11; //Bow layer
        }
    }

}
