using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    [SerializeField]
    Shop _shop;
   

    void Start()
    {

        Managers.UI.MakeOverlayUI<Shop>(transform);

        _shop = gameObject.GetComponentInChildren<Shop>();
    }

    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _shop.gameObject.SetActive(true);
            _shop.Active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _shop.gameObject.SetActive(false);
            _shop.Active =  false;
        }
    }

}
