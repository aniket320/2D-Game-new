using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public GameObject bloodeffet;
    public AudioSource hit;
    public AudioClip hitsound;
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            foreach(ContactPoint contact in collision.contacts)
            {
                GameObject effet = Instantiate(bloodeffet, contact.point, Quaternion.identity);
                hit.PlayOneShot(hitsound);
                Destroy(effet, 2);
            }
           
        }
    }
    

}
