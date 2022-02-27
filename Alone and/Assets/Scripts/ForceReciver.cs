using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciver : MonoBehaviour
{

    public float decelaration = 6f;
    public float Mass = 3f;

    private Vector3 intencity;
    private CharacterController controller;
        
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        intencity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(intencity.magnitude >= 0.2f)
        {
            controller.Move(intencity * Time.deltaTime);
        }

        intencity = Vector3.Lerp(intencity, Vector3.zero, decelaration * Time.deltaTime);
    }

    public void AddForce(Vector3 direction,float Force)
    {
        intencity += (direction.normalized *  Force / Mass);
    }
}
