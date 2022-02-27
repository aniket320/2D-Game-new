using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkeffect : MonoBehaviour
{
    public Player movement;
    public AudioSource walking;
    void Start()
    {
        walking = GetComponent<AudioSource>();
    }

}
