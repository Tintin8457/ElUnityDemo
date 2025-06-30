using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Selector : MonoBehaviour
{
    [SerializeField] private List<GameObject> dartTypes = new List<GameObject>();
    [SerializeField] private List<GameObject> dartProjectiles = new List<GameObject>();
    [SerializeField] private List<Sprite> dartImages = new List<Sprite>();

    //[SerializeField] private Dart_Shooter shooter null;

    [SerializeField] private int numTypes;
    [SerializeField] private int currTypeIndex = 0;

    void Awake()
    {
        numTypes = dartTypes.Count;
    }

    // Update is called once per frame
    void Update()
    {
        numTypes = dartTypes.Count;

        if(Input.GetKeyDown(KeyCode.Q))
        {
            currTypeIndex = GetPrevDartIndex(currTypeIndex);

        }
            
        if(Input.GetKeyDown(KeyCode.E))
        {
            currTypeIndex = GetNextDartIndex(currTypeIndex);

        }
    }

    int GetPrevDartIndex(int currentIndex)
    {
        currentIndex--;
        if(currentIndex < 0)
            currentIndex = dartTypes.Count - 1;
        
        return currentIndex;
    }

    public GameObject GetCurrDart()
    {
        return dartTypes[currTypeIndex];
    }

    public GameObject GetCurrProjectile()
    {
        return dartProjectiles[currTypeIndex];
    }

    int GetNextDartIndex(int currentIndex)
    {
        currentIndex++;
        if(currentIndex >= dartTypes.Count)
            currentIndex = 0;

        return currentIndex;
    }
}
