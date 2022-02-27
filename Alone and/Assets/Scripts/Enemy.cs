using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    float speed = 0.3f;
    public float close;
    private float dist;
    private GameObject Player;
    public HealthStats healthdec;
    public Status status;
    private AudioSource aud;
    public AudioClip zsound;
    private float RandomNumber = 300f;
    public GameObject healthcit;
    public Transform spwner;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthdec = GameObject.FindObjectOfType<HealthStats>();
        status = GameObject.FindObjectOfType<Status>();
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(zsound);
    }

    // Update is called once per frame
    void Update()
    {
        
        Follow();
        transform.LookAt(Player.transform, Vector3.up);
        dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < close)
        {
            speed = 0;
            healthdec.health-=1 * 0.2f;

        }
       else if (dist > close)
        {
            speed = 0.3f;         
        }
        if (health <= 0)
        {
            health = 0;
            Destroy(GetComponent<Animator>());
            Destroy(GetComponent<Enemy>());

            status.killscount++;   ///////////////////////////  Score , Points 
            RandomNumber = Random.Range(50, 120);
            status.counter += RandomNumber;
            status.enabletext();
            status.DisplayCount.text = "+"+RandomNumber.ToString();
            
            aud.Stop();
            Instantiate(healthcit, spwner.position, Quaternion.identity);
            Destroy(GetComponent<Collider>());
        }
        
        
    }

    
    void Follow()
    {
        float steps = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, steps);
    }

    public void dam(float ammount)
    {
        health -= ammount;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("g2"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("bat"))
        {
            health -= 40;
        }
    }

   
}
