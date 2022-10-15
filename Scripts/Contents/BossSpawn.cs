using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{

    GameObject Boss;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int enter = other.GetComponent<PlayerController>().KeyCount;
            if(enter >= 3)
            {
                Boss = Managers.Resource.Instantiate("Boss") ;
            }
        }
    }

}
