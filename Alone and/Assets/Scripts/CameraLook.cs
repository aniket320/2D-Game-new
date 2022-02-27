using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour
{
    private float Camera_Sensetivity;
    public Transform Player;
    public Slider Sensetivity;
    float VerticalRotation = 30;
    // Start is called before the first frame update
    void Start()
    {
        
        Loadslider();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        saveslider();
        Sensetivity.value = Camera_Sensetivity;
        float x = Input.GetAxis("Mouse X") * Camera_Sensetivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * Camera_Sensetivity * Time.deltaTime;

        VerticalRotation -= y;

        VerticalRotation =  Mathf.Clamp(VerticalRotation,-90, 90);
        transform.localRotation = Quaternion.Euler(VerticalRotation, 0, 0);

        Player.transform.Rotate (Vector3.up * x);

        if (Camera_Sensetivity >= 100)
        {
            Camera_Sensetivity = 100;
        }
        else if (Camera_Sensetivity <= 0)
        {
            Camera_Sensetivity = 0;
        }

    }


    public void plusSen()
    {
        Camera_Sensetivity += 10;
    }
    public void minSen()
    {
        Camera_Sensetivity -= 10;
    }


    void saveslider()
    {
        PlayerPrefs.SetFloat("Sensit", Camera_Sensetivity);
    }

    void Loadslider()
    {
        if (PlayerPrefs.HasKey("Sensit"))
        {
            Camera_Sensetivity = PlayerPrefs.GetFloat("Sensit");
        }
        else
        {
            Camera_Sensetivity = 40;
        }
       
    }
}
