using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Building : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");//call player game object 
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z > transform.position.z + 270f)
        {
            SpawnBuilding.instance.Spawn_building();//call spawn function
            Destroy(this.gameObject);//destroy passed building
        }
    }
}
