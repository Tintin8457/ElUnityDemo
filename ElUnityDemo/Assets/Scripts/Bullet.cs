using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 defaultOrientation;

    Rigidbody bulletRB;
    private Shooter shooter;
    private Dart_Shooter altShooter;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();

        transform.eulerAngles = new Vector3(defaultOrientation.x, 0f, 0f);

        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Shooter>();
        }

        //Find ALT player
        GameObject pla = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            altShooter = pla.GetComponent<Dart_Shooter>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Bullet movement
        //Vector3 force = (transform.forward * -1) * speed;
        //bulletRB.AddForce(transform.forward * speed, ForceMode.Impulse);

        transform.Translate(-transform.forward * speed);
    }

    //Destroy bullet at dummy and adds another bullet to the player's bullet 
    void OnCollisionEnter(Collision hit)
    {
        if (/*hit.gameObject.tag == "Dummy" ||*/ hit.gameObject.tag == "Target")
        {
            //Destroy(gameObject);
            bulletRB.constraints = RigidbodyConstraints.FreezeAll;
            speed = 0.0f;
            shooter.shootLimit += 1;
            altShooter.UpdateScore(1);
        }

        if (hit.gameObject.tag == "Patient")
        {
            //Destroy(gameObject);
            bulletRB.constraints = RigidbodyConstraints.FreezeAll;
            speed = 0.0f;
            shooter.shootLimit += 1;
        }

        //Destroy bullet at wall
        if (hit.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            shooter.shootLimit += 1;
        }
    }
}
