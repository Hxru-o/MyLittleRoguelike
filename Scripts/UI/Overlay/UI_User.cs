using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_User : UI_Base
{
    [SerializeField]
    TextMeshProUGUI _swordText;
    [SerializeField]
    TextMeshProUGUI _bowText;
    [SerializeField]
    TextMeshProUGUI _potionText;
    [SerializeField]
    TextMeshProUGUI _coinText;

    [SerializeField]
    GameObject _player;
    [SerializeField]
    PlayerStat _stat;
    [SerializeField]
    PlayerController _playerController;

    enum GameObjects
    {
        UI_User
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _stat = _player.GetComponent<PlayerStat>();
        _playerController = _player.GetComponent<PlayerController>();
    }



    private void Update()
    {
        Swap();
        PotionCount();
        CointCount();
    }

    void Swap()
    {
        if(_playerController.WeaponIndex == 0)
        {
            _swordText.color = Color.red;
            _bowText.color = Color.white;
        }
        else if(_playerController.WeaponIndex == 1)
        {
            _swordText.color = Color.white;
            _bowText.color = Color.red;
        }
        else
        {
            Debug.Log("ERROR SWAP");
        }

    }

    void PotionCount()
    {
        _potionText.text = $"{_stat.Potion}";
    }
    void CointCount()
    {
        _coinText.text = $"{_stat.Gold}";
    }

   
}
