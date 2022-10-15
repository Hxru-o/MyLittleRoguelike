using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    GameObject TP2;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
                other.gameObject.transform.position = TP2.transform.position;

        }
        else
        {
            Debug.Log("NO");
        }
    }
}
