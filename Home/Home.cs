using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Home : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI High_score;
    [SerializeField] TextMeshProUGUI Coin_text;
    [SerializeField] TextMeshProUGUI Shop_Coin;

    public AudioSource Music;
    public AudioMixer AudioMixer;

    private void Start()
    {
        Music.Play();
    }

    private void Update()
    {
        High_score.text = PlayerPrefs.GetFloat("high_score", 0).ToString("0");//high score
        Coin_text.text = PlayerPrefs.GetInt("total_coins", 0).ToString("0");//total coins
        Shop_Coin.text = PlayerPrefs.GetInt("total_coins", 0).ToString("0");//total coins
    }

    //play game
    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    //quit game
    public void Quit()
    {
        Application.Quit();
    }

    //music volume
    public void Options_Music(float volume)
    {
        AudioMixer.SetFloat("Music_vol", volume);
    }

    //sfx volume
    public void Options_SFX(float volume)
    {
        AudioMixer.SetFloat("SFX_vol", volume);
    }
}
