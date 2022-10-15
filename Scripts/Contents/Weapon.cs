using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    GameObject _arrow;
    [SerializeField]
    Transform _arrowPos;

    [SerializeField]
    int _damage;
    public int Damage { get { return _damage; } set { _damage = value;  } }

    float _rate = 1.0f;
    public float Rate { get { return _rate; } set { _rate = value; } }

    [SerializeField]
    BoxCollider _meleeArea ;


 
    private void Start()
    {
        _meleeArea = GetComponent<BoxCollider>();
        _meleeArea.enabled = false;

    }

    public void Melee()
    {
       
      StopCoroutine("Swing");
      StartCoroutine("Swing");
        
    }

    public void Bow()
    {
        StopCoroutine("Shot");
        StartCoroutine("Shot");
    }

    IEnumerator Shot()
    {
        GameObject intantArrow = Instantiate(_arrow, _arrowPos.position, _arrowPos.rotation);
        Rigidbody arrowrb = intantArrow.GetComponent<Rigidbody>();
        arrowrb.velocity = _arrowPos.forward * 50;

        yield return null;
    }

    IEnumerator Swing()
    {
       
        yield return new WaitForSeconds(0.1f);
        _meleeArea.enabled = true;

        yield return new WaitForSeconds(0.3f);
        _meleeArea.enabled = false;
    }
}
