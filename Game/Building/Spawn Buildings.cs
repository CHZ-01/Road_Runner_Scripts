using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    public static SpawnBuilding instance;
    [SerializeField] GameObject building;
    [SerializeField] Transform pos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Spawn_building()
    {
        //spawn building set 1
        Instantiate(building, pos.position, Quaternion.identity);

        //increment spawn position
        pos.position = new Vector3(pos.transform.position.x, pos.transform.position.y, pos.transform.position.z + 270f);
    }

    private void OnDestroy()
    {
        Destroy(instance);
    }

}
