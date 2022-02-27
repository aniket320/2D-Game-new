using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatio : MonoBehaviour
{
    public Animator Ani;

    public GameObject[] guncontrol;
    public GameObject batcontrol;
    public GameObject Guns;
    public GameObject Bat;
    public bool swticher;
    public GameObject autocheck;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
       
    }
    private void Update()
    {
       
        if (swticher == true)
        {
            Bat.SetActive(true);
            Guns.SetActive(false);
            batcontrol.SetActive(true);
            autocheck.GetComponent<Gun>().enabled = false;
            foreach (GameObject gun in guncontrol)
            {
                gun.SetActive(false);
            }
        }

        else if (swticher == false)
        {
            Bat.SetActive(false);
            batcontrol.SetActive(false);
            Guns.SetActive(true);
            autocheck.GetComponent<Gun>().enabled = true;
            foreach (GameObject gun in guncontrol)
            {
                gun.SetActive(true);
            }
        }
    }
    public void Reloadani()
    {
        Ani.SetBool("standfire", true);
    }
    public void stoprel()
    {
        Ani.SetBool("standfire", false);
        Ani.SetBool("idle", true);
    }

    public void fire1()
    {
        Ani.SetBool("run", true);
    }
    public void stopfire1()
    {
        Ani.SetBool("run", false);
        Ani.SetBool("idle", true);
    }


    public void batani()
    {
        Ani.SetBool("idle", false);
        Ani.SetBool("bidle", true);
        swticher = true;
       
    }
    public void bathit()
    {
        Ani.SetBool("bhit", true);
    }

    public void bhitstop()
    {
        Ani.SetBool("bhit", false);
        Ani.SetBool("bidle", true);
    }

    public void gunani()
    {
        Ani.SetBool("bidle", false);
        Ani.SetBool("idle", true);
        swticher = false;
    }

}
