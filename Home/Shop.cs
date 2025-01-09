using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Shop : MonoBehaviour
{
    public int CurrentPlayer;
    public GameObject[] Players;
    public PlayerData[] Data;
    public GameObject Purchase;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Name;
    public Button Buy;

    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayerData player in Data)
        {
            if(player.price == 0)
            {
                player.unlocked = true;
            }
            else
            {
                player.unlocked = PlayerPrefs.GetInt(player.name, 0) != 0;
            }
        }

        CurrentPlayer = PlayerPrefs.GetInt("Selected_Player", 0);
        foreach (GameObject Runner in Players)
        {
            Runner.SetActive(false);
        }

        Players[CurrentPlayer].SetActive(true);
        PlayerData pd = Data[CurrentPlayer];
        Name.text = pd.name;
    }

    void Update()
    {
        UI_update();
    }

    //player unlock
    public void Unlock()
    {
        PlayerData pd = Data[CurrentPlayer];
        PlayerPrefs.SetInt(pd.name, 1);
        PlayerPrefs.SetInt("Selected_Player", CurrentPlayer);
        pd.unlocked = true;
        PlayerPrefs.SetInt("total_coins", PlayerPrefs.GetInt("total_coins", 0) - pd.price);
    }

    //next button
    public void Next()
    {
        Players[CurrentPlayer].SetActive(false);
        CurrentPlayer++;

        if (CurrentPlayer == Players.Length)
        {
            CurrentPlayer = 0;
        }

        Players[CurrentPlayer].SetActive(true);

        PlayerData pd = Data[CurrentPlayer];
        Name.text = pd.name;

        if (!pd.unlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("Selected_Player", CurrentPlayer);
    }

    //previous button
    public void Previous()
    {
        Players[CurrentPlayer].SetActive(false);
        CurrentPlayer--;

        if (CurrentPlayer == -1)
        {
            CurrentPlayer = Players.Length - 1;
        }

        Players[CurrentPlayer].SetActive(true);

        PlayerData pd = Data[CurrentPlayer];
        Name.text = pd.name;

        if (!pd.unlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("Selected_Player", CurrentPlayer);
    }

    //purchase option
    private void UI_update()
    {
        PlayerData pd = Data[CurrentPlayer];

        if(pd.unlocked)
        {
            Purchase.SetActive(false);
        }
        else
        {
            Purchase.SetActive(true);
            Price.text = pd.price.ToString("0");

            if(pd.price <= PlayerPrefs.GetInt("total_coins", 0))
            {
                Buy.interactable = true;
            }
            else
            {
                Buy.interactable= false;
            }
        }
    }

}
