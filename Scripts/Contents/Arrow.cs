using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    int _damage = 10;

    public int Damage { get { return _damage; } set { _damage = value; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null)
        {
            Destroy(this.gameObject, 10f);
            return;
        }
           
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == null)
        {
            Destroy(this.gameObject, 10f) ;
        }

        else if(other.tag == "Slime")
        {
            Destroy(this.gameObject, 1f);

        }
        else if (other.tag == "Boss")
        {
            Destroy(this.gameObject, 1f);

        }
    }
}
