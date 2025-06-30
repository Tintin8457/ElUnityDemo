using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dart_Shooter : MonoBehaviour
{
    [SerializeField] private Dart_Selector selector = null;

    [SerializeField] private Game_Controller controller = null;

    [SerializeField] private Transform dartSpawn = null;

    private int limit = 5;

    private GameObject dartType = null;

    [SerializeField] private bool ready = true; 

    [SerializeField] private List<GameObject> dartsFired = new List<GameObject>();

    public Text scoreText;
    public int score = 0;
    public Text winText;
    public bool gameOver;

    private float timer = 0f;
    private bool timerOn = false;

    void Start()
    {
        winText.enabled = false;
        gameOver = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
            timer += Time.deltaTime;

        if(timer >= 2.0f)
        {
            SetReady();
            timerOn = false;
            timer = 0f;
        }

        if (gameOver == false)
        {
            if(ready)
            {
                if(dartType == null)
                {
                    controller.DisplayReady();
                    dartType = (GameObject)Instantiate(selector.GetCurrDart(), 
                    dartSpawn.position, dartSpawn.rotation);
                
                    dartType.transform.parent = dartSpawn.transform;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && ready)
            {
                GameObject firedDart = null;

                //Set ready to false and destroy the preview dart
                timer = 0f;
                timerOn = true;
                ready = false;
                controller.ClearReadyText();

                Destroy(dartType);

                //Spawn projectile
                firedDart = (GameObject)Instantiate(selector.GetCurrProjectile(), 
                    dartSpawn.position, dartSpawn.rotation);
                dartsFired.Add(firedDart);
                firedDart.GetComponent<Rigidbody>().velocity = dartSpawn.forward * 10;

                if (dartsFired.Count > limit)
                {
                    Destroy(dartsFired[0]);
                    dartsFired.Remove(dartsFired[0]);
                }
            }
        }

        scoreText.text = "Score: " + score.ToString();

        if (score == 5)
        {
            winText.enabled = true;
            gameOver = true;
        }
    }

    public void SetReady()
    {
        ready = true;
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
    }
}
