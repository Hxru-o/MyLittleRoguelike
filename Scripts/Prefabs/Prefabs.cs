using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    GameObject prefab;

    GameObject Slime;

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Slime = Managers.Resource.Instantiate("Slime");
            Slime.gameObject.transform.position = this.gameObject.transform.position;
        }
        
       

    }
}
