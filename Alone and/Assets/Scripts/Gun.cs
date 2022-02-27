using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public float Damage = 10;
    public float Range = 100f;

    public TMP_Text Bullets;
    public float cbullets;
    float maxammo = 30f;
    public TMP_Text usedammo;
    public float UsedAmmo;
    public Camera Cam;
    
    public ParticleSystem flash;
    public GameObject Effect;
    public GameObject bloodeffect;
    
    public float firerate = 15;
    private float nextfire = 0f;

    public GameObject Scope;
    public GameObject Scopeimg;
    private AudioSource Audios;
    public AudioClip gun;
    public AudioClip reload;
    public Image aim;
    public animatio anime;
    public Toggle autofire;

    public GameObject Firebutton;
    public GameObject Andinputs;
    public bool inputcheck;
    public bool autofirecheck;
    private bool firel=false;
    private void Start()
    {
        Audios = GetComponent<AudioSource>();
        loader();
       
    }
    private void Update()
    {
        saver();
        aimimg();
        Bullets.text =  cbullets + "/".ToString();

        if (autofirecheck == true) ////Autofire play
        {
            Firebutton.SetActive(false);
        }
        else if (autofirecheck == false)
        {
            Firebutton.SetActive(true);
        }

        if (firel == true)   ////Onclick fire play
        {
            if (cbullets > 0)
            {
                Shoot();
            }         
        }
        else if(firel == false)
        {
            anime.stopfire1();
        }
     
        usedammo.text = UsedAmmo.ToString();

        if (cbullets == 0)
        {
            Audios.Stop();
            cbullets = 0;
            
            flash.Stop();
            reloadbut();          
        }      

        if (inputcheck == false)
        {
            Andinputs.SetActive(false);
        }
        else 
        {
            Andinputs.SetActive(true);
        }

        
    }
    IEnumerator reloader()  //// Stop Reload Animation
    {
        yield return new WaitForSeconds(3);
        anime.stoprel();
        StartCoroutine(delayammo());
    }

    IEnumerator delayammo()    /// Delay Ammo Reload
    {
        yield return new WaitForSeconds(1);
        cbullets = maxammo;
    }
    public void reloadbut()       ////Reload
    {
        anime.stopfire1();
        StartCoroutine(reloader());
        anime.Reloadani();
        Audios.PlayOneShot(reload);   
    }

     void Shoot()    /// OnClick Fire Button
    {
        anime.fire1();
        if (Time.time > nextfire)
        {  
            nextfire = Time.time + 1f / firerate;   
            Audios.PlayOneShot(gun);
            cbullets--;
            UsedAmmo++;
            flash.Play();
        RaycastHit hit;

      if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range))
         {
            if (hit.collider.tag == "Enemy")
            {
                GameObject bloode = Instantiate(bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloode, 2);
                Enemy Damager = hit.transform.GetComponent<Enemy>();
                Damager.dam(Damage);
            }
            
           GameObject hiteffect = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hiteffect, 2);
       }
      }
     }

    public void firedown()   
    {
        firel = true;
    }

    public void fireup()
    {
        firel = false;
    }


    void aimimg()    ////AutoFire
    {
        RaycastHit hit1;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit1, Range))
        { 
            if (hit1.collider.tag == "Enemy")
            {
                aim.color = Color.red;
                if (autofire.isOn == true)
                {
                    if (cbullets > 0 )
                    {
                        Shoot();
                    }
                    if (cbullets == 0)
                    {
                        Audios.Stop();
                        cbullets = 0;
                        flash.Stop();
                        anime.stopfire1();
                        reloadbut();
                    }
                }
                if (autofire.isOn == false)
                {
                    return;
                }
            }
            else if(hit1.collider.tag=="Ground")
            {
                aim.color = Color.white;
                anime.stopfire1();
            }
        }
    }
  
    void saver()      ///////Saving Data
    {
        PlayerPrefs.SetFloat("cbullets", cbullets);
        PlayerPrefs.SetFloat("uammo", UsedAmmo);
        if (autofire.isOn == false)
        {
            PlayerPrefs.SetInt("autofireon", 1);
            autofirecheck = false;
        }
        else
        {
            PlayerPrefs.SetInt("autofireon", 0);
            autofirecheck = true;
        }
    }
    void loader()
    {
        cbullets = PlayerPrefs.GetFloat("cbullets");
        UsedAmmo = PlayerPrefs.GetFloat("uammo");

        if (PlayerPrefs.GetInt("autofireon") == 1)
        {
            autofire.isOn = false;
        }
        else
        {
            autofire.isOn=true;
        }
    }
}
