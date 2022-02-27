using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timetext;
    private int Min, Sec;
    private float timer = 0f;
    
   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Min = Mathf.FloorToInt(timer / 60f);
        Sec = Mathf.FloorToInt(timer - Min * 60);
       // timetext.text = string.Format("{0:00}:{1:00}", Min, Sec);

        if (Min > 48)
        {
          //// Do Something
        }
    }
}
