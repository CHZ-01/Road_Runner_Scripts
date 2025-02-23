using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score_text;
    [SerializeField] TextMeshProUGUI Coin_text;
    //[SerializeField] TextMeshProUGUI Total_Coin_text;

    [SerializeField] Transform Player;


    int playerscore;
    
    // Update is called once per frame
    void Update()
    {
        playerscore = (int)Player.transform.position.z * 3;
        PlayerPrefs.SetFloat("score", playerscore);
        Coin_text.text = PlayerPrefs.GetInt("coins", 0).ToString("0");
        //Total_Coin_text.text = PlayerPrefs.GetInt("total_coins", 0).ToString("0");
        Score_text.text = playerscore.ToString("0");

        if (playerscore > PlayerPrefs.GetFloat("high_score", 0f))
        {
            PlayerPrefs.SetFloat("high_score", playerscore);
        }
    }
}
