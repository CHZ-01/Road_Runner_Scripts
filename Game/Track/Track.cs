using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject[] Levels;
    public bool start; 

    // Start is called before the first frame update
    void Start()
    {
        if(!start)
        {
            int Random_track = Random.Range(1, Levels.Length);
            Levels[Random_track].gameObject.SetActive(true);
        }
    }

}
