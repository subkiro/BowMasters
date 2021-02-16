using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bow : MonoBehaviour
{
    Rigidbody2D rb;
    public bool hit;
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
            SoundManager.instance.PlayVFX("Hit");
            SetAllCollidersStatus(false);
    
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.mass = 0;
            this.gameObject.transform.SetParent(collision.transform);
            hit = true;
            
           

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


    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = active;
        }
    }

}
