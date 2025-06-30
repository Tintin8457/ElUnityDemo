using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawners : MonoBehaviour
{
    [Header("Targets")]
    public GameObject[] targets;

    [Header("Target Spawner Update")]
    public List<bool> targetNum = new List<bool>();

    private Dart_Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Dart_Shooter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.gameOver == false)
        {
            for (int i = 0; i < targetNum.Count; i++)
            {
                targetNum[shooter.score] = true;
            }

            targetNum[shooter.score] = true;
            targets[shooter.score].gameObject.SetActive(true);
        }
    }
}
