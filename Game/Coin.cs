using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Game_Audio Audio_play;

    private void Awake()
    {
        Audio_play = GameObject.FindGameObjectWithTag("Audio").GetComponent<Game_Audio>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1);
            PlayerPrefs.SetInt("total_coins", PlayerPrefs.GetInt("total_coins", 0) + 1);
            Audio_play.Play_SFX(Audio_play.Coin);
            Destroy(this.gameObject);
        }
    }
}
