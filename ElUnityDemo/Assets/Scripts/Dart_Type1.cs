using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Type1 : MonoBehaviour
{
    Dart_Shooter shooter;
    Rigidbody rb;
    private bool stuck = false;
    //private bool hitSomething = false;

    private bool timerOn = false;
    private float timer = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shooter = GameObject.Find("Main Camera").GetComponent<Dart_Shooter>();
        timer = 0.0f;
        //timerOn = true;
    }

    void Update()
    {
        if(timerOn)
            timer += Time.deltaTime;

        if(timer >= 3.0f)
        {
            shooter.SetReady();
        }
    }

    void FixedUpdate()
    {
        if(!stuck)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Wall")
        {
            //hitSomething = true;
            timerOn = false;
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
        }
        else if(hit.gameObject.tag == "Patient")
        {
            //hitSomething = true;
            timerOn = false;
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
            //make noise
        }
        else if(hit.gameObject.tag == "Other")
        {
            timerOn = false;
            shooter.SetReady();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            stuck = true;
        }
    }
}
