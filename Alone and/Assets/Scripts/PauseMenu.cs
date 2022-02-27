using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public AudioClip sound;
    public AudioSource Source;
    public GameObject pausemenu;
    public GameObject QuitPanel;
  
    /////  Sliders  /////
    public Slider VolunmeSlider;
    public Slider Brightnessslider;
    public Light BrightnessObj;
    public Text Warning;
    public bool checker;
    public GameObject firebubt;
    public GameObject Scopfire;
    public Toggle button;
    public GameObject[] hider;
    void Start()
    {
        LoadSlider();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }


    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            checker = !checker;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
                QuitPanel.SetActive(true);
        }

        if (checker)
        {
            checker = true;
            pausemenu.SetActive(true);
            Time.timeScale = 0;
           foreach(GameObject hide in hider)
            {
                hide.SetActive(false);
            }
        }
        else
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1;
            foreach (GameObject hide in hider)
            {
                hide.SetActive(true);
            }
        }

        savesliders();

        
       
    }

    public void OnMouse()
    {
        Source.PlayOneShot(sound);
    }

    public void QuitButton()
    {
      SceneManager.LoadScene("Menu");
        checker = false;
        
    }

   
    public void QuitYes()
    {
        
        Application.Quit();
    }

    public void Resume()
    {
        checker = false;
    }

    public void DelAllData()
    {
        PlayerPrefs.HasKey("x");
        PlayerPrefs.HasKey("y");
        PlayerPrefs.HasKey("z");
        PlayerPrefs.HasKey("kills");
        PlayerPrefs.HasKey("counts");
        PlayerPrefs.HasKey("cbullets");
        PlayerPrefs.HasKey("uammo");
        PlayerPrefs.HasKey("autofireon");
        PlayerPrefs.HasKey("Health");

        SceneManager.LoadScene("Menu");
        
    }
    public void DelAllDataWar()
    {
        Warning.text = "Important: Before Pressing Press(I + Delete) Key";
    }
    public void DelAllDataCan()
    {
        Warning.text = "";
    }


    void savesliders()
    {
        PlayerPrefs.SetFloat("vol", VolunmeSlider.value);
        PlayerPrefs.SetFloat("brightness", Brightnessslider.value);
        if (button.isOn == true)
        {
            PlayerPrefs.SetInt("norfire", 1);
            firebubt.SetActive(false);
            Scopfire.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("norfire", 0);
            firebubt.SetActive(true);
            Scopfire.SetActive(false);
        }
        
    }

    void LoadSlider()
    {
        if (PlayerPrefs.HasKey("vol"))
        {
            VolunmeSlider.value = PlayerPrefs.GetFloat("vol");
        }
        else
        {
            VolunmeSlider.value = 0.7f;
        }

        if (PlayerPrefs.HasKey("brightness"))
        {
            Brightnessslider.value = PlayerPrefs.GetFloat("brightness");
        }
        else
        {
            Brightnessslider.value = 0.5f;
        }
        if (PlayerPrefs.GetInt("norfire") == 1)
        {
            button.isOn = true;
           

        }
        else
        {
            button.isOn = false;          
        }

    }
}
