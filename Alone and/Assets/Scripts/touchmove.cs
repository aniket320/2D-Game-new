using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchmove : MonoBehaviour
{
    public float x;
    public float y;
    float smoothness = 0.15f;
    private float rotationspeed;
    public Slider sensitivity;
    Vector3 tr;
    Vector3 currenvelocity;


  ///  Touch Areas for Camera  /////
    public TouchArea touch;
    public TouchArea touch2;

    private void Start()
    {
        Loadslider();

    }
    void Update()
    {
        saveslider();
        rotationspeed = sensitivity.value;

        y += touch.Touchdis.x * rotationspeed;
        x -= touch.Touchdis.y * rotationspeed;


        y += touch2.Touchdis.x * rotationspeed;
        x -= touch2.Touchdis.y * rotationspeed;





        x = Mathf.Clamp(x, -40, 50);     /// For Vertical Lock Rotation
        tr = Vector3.SmoothDamp(tr, new Vector3(x, y), ref currenvelocity, smoothness);
        transform.eulerAngles = tr;


    }


    void saveslider()
    {
        PlayerPrefs.SetFloat("Sensit", sensitivity.value);
    }

    void Loadslider()
    {
        if (PlayerPrefs.HasKey("Sensit"))
        {
            sensitivity.value = PlayerPrefs.GetFloat("Sensit");
        }
        else
        {
            sensitivity.value = 0.4f;
        }

    }

}
