using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthStats : MonoBehaviour
{
    public Slider Healthbar;
    public float health;
    
    private Enemy en;
    public GameObject Dangertext;
    public CharacterController player;
    
    ///public Rigidbody player; 
    void Start()
    {
        //  player = GetComponent<Rigidbody>();
        if (PlayerPrefs.HasKey("Health"))
        {
            loadStat();
        }
       
    }

   
    void Update()
    {
        en = GameObject.FindObjectOfType<Enemy>();
        SaveStat();
        Healthbar.value = health;
       
        if (health >= 100)         
        {
            health = 100;
        }
        else if (health <= 0)
        {
            health = 0;
           
        }

        
    }

 

private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("hc"))
        {
            Increse();   
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (en.gameObject.CompareTag("Enemy"))
        {
            Dangertext.SetActive(true);
        }
        else
        {
            Dangertext.SetActive(false);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (en.gameObject.CompareTag("Enemy"))
        {
            
        }
    }
    public void Increse()
    {
        health +=0.2f;
      
    }


    private void SaveStat()
    {
        PlayerPrefs.SetFloat("Health", health);
       
    }

    private void loadStat()
    {
        health = PlayerPrefs.GetFloat("Health");
    }
}
