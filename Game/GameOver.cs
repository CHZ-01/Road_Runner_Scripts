using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI coin;
    [SerializeField] TextMeshProUGUI High_score;
    [SerializeField] TextMeshProUGUI Total_Coin;

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetFloat("score", 0).ToString("0");//high score
        coin.text = PlayerPrefs.GetInt("coins", 0).ToString("0");//high score
        High_score.text = PlayerPrefs.GetFloat("high_score", 0).ToString("0");//high score
        Total_Coin.text = PlayerPrefs.GetInt("total_coins", 0).ToString("0");//total coins
    }

    //Restart game
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    //Home page
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

}
