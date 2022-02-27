using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startup : MonoBehaviour
{
    public GameObject panels;
    public GameObject skip;
    public GameObject info;
    void Start()
    {
        skip.SetActive(false);
        if (PlayerPrefs.HasKey("info"))
        {
            panels.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("info",1);
        }
    }

  
    void Update()
    {
        StartCoroutine(playvid());
        StartCoroutine(close());
        StartCoroutine(closeall());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(20);
        skip.SetActive(true);
    }

    IEnumerator playvid()
    {
        yield return new WaitForSeconds(11);
        info.SetActive(true);
    }

    IEnumerator closeall()
    {
        yield return new WaitForSeconds(24);
        panels.SetActive(false);
    }

}
