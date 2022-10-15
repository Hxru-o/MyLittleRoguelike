using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;

    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;
    [SerializeField]
    protected float _moveSpeed;

    GameObject go;

    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int maxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }

    public int Defence { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }


    private void Start()
    {

        go = this.gameObject;
        Boss();
        Slime();
    }

    void Boss()
    {
        if(go.tag ==  "Boss")
        {
            _level = 1;
            _hp = 1000;
            _maxHp = 1000;
            _attack = 10;
            _moveSpeed = 5.0f;
            _defense = 5;
        }
    }

    void Slime()
    {
        if(go.tag == "Slime")
        {
            _level = 1;
            _hp = 100;
            _maxHp = 100;
            _attack = 10;
            _moveSpeed = 5.0f;
            _defense = 5;
        }

      
    }


}
