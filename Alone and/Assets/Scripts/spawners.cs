using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawners : MonoBehaviour
{
    public GameObject[] Enemies;
    public Transform[] posi;
    public Transform loc;
    float spawnrate;
    float nextspwn;
  
    void Start()
    {
        spawnrate = 12;
        nextspwn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        spwn();
        
    }

    void spwn()
    {
        if (nextspwn < Time.time)
        {
            loc = posi[Random.Range(0, posi.Length)];
            Instantiate(Enemies[Random.Range(0,Enemies.Length)],loc.position, Quaternion.identity);
            nextspwn = Time.time + spawnrate;

        }
    }
}
