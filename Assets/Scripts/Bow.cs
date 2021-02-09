﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit) { 
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        Destroy(this.gameObject, 2f);
    }
}
