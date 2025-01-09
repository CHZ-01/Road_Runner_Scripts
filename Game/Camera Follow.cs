using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform runner;//player position

    void LateUpdate()
    {
        //camera follow
        transform.position = new Vector3(runner.transform.position.x, transform.position.y, runner.transform.position.z -8);
    }
}
