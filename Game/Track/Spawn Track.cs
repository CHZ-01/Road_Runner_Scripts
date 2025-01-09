using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrack : MonoBehaviour
{
    public static SpawnTrack instance;
    [SerializeField] GameObject road;
    [SerializeField] Transform pos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Spawn_track()
    {
        //spawn track
        Instantiate(road, pos.position, Quaternion.identity);

        //increment position
        pos.position = new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z + 50f);
    }

    private void OnDestroy()
    {
        Destroy(instance);
    }
}
