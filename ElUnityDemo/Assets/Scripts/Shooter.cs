using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public int shootLimit = 1;

    public Transform bulletSpawn;

    private float verticalLook;
    public int lookSpeed = 5;
    private Vector3 dist;

    // Start is called before the first frame update
    void Start()
    { 
       
    }

    // Update is called once per frame
    void Update()
    {
        //Look up and down
        verticalLook = Input.GetAxis("Mouse X") * lookSpeed;
        transform.Rotate(verticalLook, 0, 0);

        //Shoot bullets
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootLimit == 1)
            {
                //Ray click = Camera.main.ScreenPointToRay(Input.mousePosition);
                //RaycastHit hit;

                //if (Physics.Raycast(click, out hit))
                //{
                    
                    //Transform shot = hit.transform;
                    //Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                    //shootLimit -= 1; //Lower shoot limit
                //}

                Instantiate(projectile, bulletSpawn.transform.position, transform.rotation * Quaternion.Euler(45f, 0f, 0f));
                shootLimit -= 1; //Lower shoot limit
            }             
        }
    }
}
