using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{

    Stat _stat;
    PlayerStat _playerStat;
    Rigidbody _rigid;
    BoxCollider _collider;
    NavMeshAgent _nav;
    Animator _anim;


    [SerializeField]
    GameObject _player;

    float _scanRange = 3f;
    

    private void Awake()
    {
        _stat = GetComponent<Stat>();
        _rigid = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStat = _player.GetComponent<PlayerStat>();

    }

    private void Update()
    {
        Navi();
        Die();
    }

    void Navi()
    {
        
        if (_player == null)
        {
            _anim.Play("Idle");
            return;
        }
 
        float distance = (_player.transform.position - transform.position).magnitude;
        if(distance <= _scanRange)
        {
            _nav.SetDestination(_player.transform.position);
        }

        if(distance <= 1.0f)
        {
            _anim.Play("Attack");
        }
        else
        {
            _anim.Play("Idle");
        }

    }

    void HitEvent()
    {
        if (_player != null)
        {
            
            PlayerStat playerStat = _player.GetComponent<PlayerStat>();
            int damage = Mathf.Max(0, _stat.Attack - playerStat.Defence);
            playerStat.Hp -= damage;

        }
        else if (_player == null)
        {
            return;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Melee")
        {
            Weapon weapon =other.GetComponent<Weapon>();
            int damage = Mathf.Max(0, (weapon.Damage + _playerStat.Attack) - _stat.Defence);
            _stat.Hp -= damage;

            Debug.Log ("Melee : " + _stat.Hp);
        }
        else if(other.tag == "Arrow")
        {
            Arrow arrow = other.GetComponent<Arrow>();
            int damage = Mathf.Max(0, (arrow.Damage +_playerStat.Attack)  - _stat.Defence);
            _stat.Hp -= damage;
        }
    }

    void Die()
    {
        if(_stat.Hp <= 0)
        {
            PlayerStat playerStat = _player.GetComponent<PlayerStat>();
            playerStat.Exp += 20;
            playerStat.Gold += 100;
            Destroy(this.gameObject);
        }
    }
}
