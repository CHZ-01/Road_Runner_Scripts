using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public int CurrentPlayer = 0;
    public GameObject[] Player;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = PlayerPrefs.GetInt("Selected_Player", 0);
        foreach (GameObject Runner in Player)
        {
            Runner.SetActive(false);
        }

        Player[CurrentPlayer].SetActive(true);
    }
}
