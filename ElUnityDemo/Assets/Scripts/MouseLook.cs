using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Camera camera;
    bool canclick;
    bool removeBedText;

    public GameObject narration;
    public GameObject userChoices_scene1;
    public GameObject escalation;
    public GameObject outcome;
    public GameObject bedText;

    public float mouseXSensitivity = 100f;
    public float verMovementSpeed = 75f;
    public float horMovementSpeed = 75f;

    public Transform playerBody;

    float xRotation = 0f;

    private Dart_Shooter shooter;

    public bool scene1, scene2, scene3;
    public bool correct, wrong;
    bool op1, op2, op3;

    public GameObject correctSum;
    public GameObject wrongSum;

    public GameObject results;

    public Rigidbody rb;

    bool RightButton, LeftButton, UpButton, DownButton;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        
        if (player != null) { shooter = player.GetComponent<Dart_Shooter>(); }

        //Find player
        GameObject playerMove = GameObject.FindGameObjectWithTag("Player");

        if (playerMove != null) { rb = playerMove.GetComponent<Rigidbody>(); }

        scene1 = true;
    }

    void FixedUpdate()
    {
        Vector2 velocity = Vector2.zero;

        if (UpButton)
        {
            velocity.x += verMovementSpeed;
            UpButton = false;
        }

        else if (DownButton)
        {
            velocity.x -= verMovementSpeed;
            DownButton = false;
        }      

        else if (RightButton)
        {
            transform.position += Vector3.back * Time.deltaTime;
            RightButton = false;
        }

        else if (LeftButton)
        {
            transform.position += Vector3.forward * Time.deltaTime;
            LeftButton = false;
        }

        rb.velocity = velocity * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (removeBedText) { bedText.SetActive(false); }

        if (Input.GetMouseButtonDown(0) && canclick)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Patient") 
                {
                    removeBedText = true;
                    if (scene1) { userChoices_scene1.SetActive(true); }
                }
            }
        }

        if (scene2) { escalation.SetActive(true); }
        else if (scene3) { outcome.SetActive(true); }

        if (correct) { correctSum.SetActive(true);
            wrongSum.SetActive(false);
            wrong = false;
        }
        else if (wrong) { wrongSum.SetActive(true); }

        //if (shooter.gameOver == false)
        //{
        //    float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        //    float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

        //    xRotation -= mouseY;
        //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //    playerBody.Rotate(Vector3.up * mouseX);
        //} 
    }

    public void MoveLeft()
    {
        RightButton = false;
        LeftButton = true;
        UpButton = false;
        DownButton = false;
    }

    public void MoveRight()
    {
        RightButton = true;
        LeftButton = false;
        UpButton = false;
        DownButton = false;
    }

    public void MoveForward()
    {
        RightButton = false;
        LeftButton = false;
        UpButton = true;
        DownButton = false;
    }

    public void MoveBackward()
    {
        RightButton = false;
        LeftButton = false;
        UpButton = false;
        DownButton = true;
    }

    public void RemoveNarration() 
    {
        canclick = true;
        narration.SetActive(false);
        bedText.SetActive(true);
    }

    public void OptionA()
    {
        op1 = true;
        userChoices_scene1.SetActive(false);
        results.SetActive(true);
    }

    public void OptionB()
    {
        op2 = true;
        userChoices_scene1.SetActive(false);
        results.SetActive(true);
    }

    public void OptionC()
    {
        op3 = true;
        userChoices_scene1.SetActive(false);
        results.SetActive(true);
    }

    public void Results()
    {
        if (op1)
        {
            correct = true;
            scene1 = false;
            scene3 = true;
        }

        if (op2)
        {
            wrong = true;
            scene1 = false;
            scene2 = true;
        }

        if (op3)
        {
            wrong = true;
            scene1 = false;
            scene2 = true;
        }

        results.SetActive(false);
    }

    public void E_OptionA()
    {
        correct = true;
        scene2 = false;
        scene3 = true;
        escalation.SetActive(false);
    }

    public void E_OptionB()
    {
        wrong = true;
        scene2 = false;
        scene3 = true;
        escalation.SetActive(false);
    }

    public void E_OptionC()
    {
        wrong = true;
        scene2 = false;
        scene3 = true;
        escalation.SetActive(false);
    }
}
