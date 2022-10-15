using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : UI_Base
{
    [SerializeField]
    PlayerStat _player;

    bool _active = false;
    public bool Active { get { return _active; } set { _active = value; } }

    enum GameObjects
    {
        Shop
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
    }

    void Start()
    {
        this.gameObject.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerStat>();
    }

    public void Potion()
    {
        if(_player.Gold >= 100)
        {
            _player.Gold -= 100;
            _player.Potion += 1;
        }
        else
        {
            Debug.Log("NO");
        }
    }

    public void Buff()
    {
        if(_player.Gold >= 100)
        {
            _player.Gold -= 100;
            _player.Attack += 30;
        }
    }

    public void Exit()
    {
        this.gameObject.SetActive(false);
    }
    
}
