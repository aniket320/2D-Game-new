using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapfollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 loc = player.position;
        transform.position = loc;
    }
}
