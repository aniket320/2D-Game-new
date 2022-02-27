using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip buttonsound;
    public Dropdown graphics;
    
    public RenderPipelineAsset[] qualitylevels;

    float Volume;
    public Slider vol;
   

   
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (PlayerPrefs.HasKey("menubgm"))
        {
            loadvol();
        }
        else
        {
            Volume = 0.5f;
        }
        graphics.value = QualitySettings.GetQualityLevel();
       

        Cursor.visible = true;
    }
    private void Update()
    {
        vol.value = Volume;   
        savevol();

        if (Volume >= 100)
        {
            Volume = 100;
        }
        else if (Volume <= 0)
        {
            Volume = 0;
        }
    }

    public void OnMouseOver()
    {
       Sound.PlayOneShot(buttonsound);
    }

    public void Playbut()
    {
        SceneManager.LoadScene("Servival");
       
    }


    public void Quiteapp()
    {
        Application.Quit();
    }

    public void plusbgm()
    {
        Volume += 0.1f;
    }
    public void minbgm()
    {
        Volume -= 0.1f;
    }
   

    
    public void SetQuality(int Values)
    {
        //QualitySettings.renderPipeline = qualitylevels[Values];
        QualitySettings.SetQualityLevel(Values);
    }

    void savevol()
    {
        PlayerPrefs.SetFloat("menubgm", Volume);
    }

    void loadvol()
    {
        Volume = PlayerPrefs.GetFloat("menubgm");
    }
}
