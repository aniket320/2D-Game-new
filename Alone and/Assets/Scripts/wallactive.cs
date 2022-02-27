using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallactive : MonoBehaviour
{
    public GameObject wall;
    public GameObject Playerdetect;
    private float close;
    public float c;
  
    // Update is called once per frame
    void Update()
    {
        
        close = Vector3.Distance(wall.transform.position, Playerdetect.transform.position);
        MeshRenderer mesh = wall.GetComponent<MeshRenderer>();
        c= Vector3.Distance(transform.position, Playerdetect.transform.position);
        if (close > 6)
        {     
            mesh.enabled = false;
            
        }
        else if(close < 6)
        {
            mesh.enabled = true;
           
        }
      
    }

    
}
