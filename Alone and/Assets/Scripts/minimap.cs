using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform player;


    private void LateUpdate()
    {
        Vector3 newpos = player.position;
        newpos.y = transform.position.y;
        transform.position = newpos;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
