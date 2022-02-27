using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Status : MonoBehaviour
{
    public GameObject StatusPanel;
    public TMP_Text Ammoused;
    public TMP_Text Kills;
    public float killscount;
    public TMP_Text CAmmo;
    public Slider healthbar;
    public GameObject Dead;
    public GameObject Blackscreen;
    public Slider progress;
    public GameObject comp;
    public float counter;
    public TMP_Text DisplayCounter;
    public TMP_Text DisplayCount;
    public Button yes;
    public TMP_Text msg1;
    
    public Gun gun;
    public HealthStats healthstats;
    public PauseMenu menu;
    public GameObject audiomus;

    public GameObject Spawners;
    // Start is called before the first frame update
    void Start()
    {
        loakil();
        Dead.SetActive(false);
        StartCoroutine(delayspwn());
    }

    // Update is called once per frame
    void Update()
    {
        savkil();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StatusPanel.SetActive(!StatusPanel.activeSelf);
        }
        Ammoused.text = gun.UsedAmmo.ToString();
        CAmmo.text = gun.cbullets.ToString();
        healthbar.value = healthstats.health;
        Kills.text = killscount.ToString();
        progress.value = killscount;
        DisplayCounter.text = counter.ToString("n0");
        

        if (healthstats.health <= 0)
        {
            Dead.SetActive(true);
            Debug.Log("dead");
            Blackscreen.SetActive(true);   
        }
       

        if (killscount > 99)
        {
            comp.SetActive(true);
            StatusPanel.SetActive(true);
           
        }
        if (killscount > 95)
        {
            audiomus.SetActive(true);
        }
        if (killscount >= 100)
        {
            Spawners.SetActive(false);
        }
        if (counter <= 2000)
        {
            yes.interactable = false;
            msg1.text = "You need more than 2000 points to continue";
        }
        else
        {
            msg1.text = "";
            yes.interactable = true;
        }
    }

    IEnumerator delayspwn()
    {
        yield return new WaitForSeconds(4);
        Spawners.SetActive(true);
    }

    IEnumerator showcount()
    {
        yield return new WaitForSeconds(1);
        DisplayCount.enabled = false;
    }
    IEnumerator delayloadlevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }
    IEnumerator delayblackscreen()
    {
        yield return new WaitForSeconds(3);
        Blackscreen.SetActive(false);
    }
    public void enabletext()
    {
        DisplayCount.enabled = true;
        StartCoroutine(showcount());
    }
    public void YesDead()
    {
        healthstats.health = 50;
        killscount -= 5;
        counter -= 2000;
        StartCoroutine(delayloadlevel());
    }
    public void NoDead()
    {
        healthstats.health = 30;
        killscount = 10;
        if (counter > 200)
        {
            counter -= 200;
        }
        else
        {
            counter = 100;
        }
        Dead.SetActive(false);
        StartCoroutine(delayblackscreen());
        StartCoroutine(delayloadlevel());
    }

    public void tabbut()
    {
        StatusPanel.SetActive(!StatusPanel.activeSelf);
    }
    void savkil()
    {
        PlayerPrefs.SetFloat("kills", killscount);
        PlayerPrefs.SetFloat("counts", counter);
    }

    void loakil()
    {
        killscount = PlayerPrefs.GetFloat("kills");
        counter = PlayerPrefs.GetFloat("counts");
    }
}
