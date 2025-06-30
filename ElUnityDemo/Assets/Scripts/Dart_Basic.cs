using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Basic : MonoBehaviour
{
    Dart_Shooter shooter;
    Rigidbody rb;
    private bool stuck = false;
    //private bool hitSomething = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shooter = GameObject.Find("Main Camera").GetComponent<Dart_Shooter>();
    }

    void FixedUpdate()
    {
        if(!stuck)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Target")
        {
            Debug.Log("Hit target");
            shooter.UpdateScore(1);
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
            
            Destroy(hit.gameObject);
        }

        if(hit.gameObject.tag == "Wall")
        {
            //hitSomething = true;
            Debug.Log("Hit wall");
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
        }

        if(hit.gameObject.tag == "Patient")
        {
            //hitSomething = true;
            Debug.Log("Hit patient");
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
            //make noise
        }

        if(hit.gameObject.tag == "Other")
        {
            Debug.Log("Hit other");
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
        }
    }
}
