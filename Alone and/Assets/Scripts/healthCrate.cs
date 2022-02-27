using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCrate : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(destroyer());
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
   
}
