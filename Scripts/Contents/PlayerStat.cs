using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    private int _exp;

    [SerializeField]
    private int _maxExp;
    [SerializeField]
    private int _gold;
    [SerializeField]
    private int _hasPotion;

    public int maxExp { get { return _maxExp; } set { _maxExp = value; } }
    public int Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    public int Potion { get { return _hasPotion; } set { _hasPotion = value; } }

    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _moveSpeed = 5.0f;
        _defense = 5;
        _exp = 1;
        _maxExp = 20;
        _hasPotion = 0;
    }

    private void Update()
    {
        LevelUp();
    }

    void LevelUp()
    {
        if(_exp >= 20)
        {
            _level += 1;
            _maxHp += 100;
            _hp = _maxHp;
            _defense += 1;
            _maxExp += 20;
            _attack += 10;

            _exp = 0;
        }
    }
}

