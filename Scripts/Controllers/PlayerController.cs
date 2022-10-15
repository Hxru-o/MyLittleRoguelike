using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    GameObject _equipWeapon;

    [SerializeField]
    Shop _shop;


    Transform _arrowPos;

    GameObject _target;
    PlayerStat _stat;

    float vAxis;
    float hAxis;
    float _motionSpeed = 0;
    float _motionDelay = 0;
   
    int keyCount = 0;
    int weaponIndex = 0;
    public int WeaponIndex { get { return weaponIndex; } }
    public int KeyCount { get { return keyCount; } }
    bool _isFireReady;

    [SerializeField]
    Weapon _weapon;


    void Update()
    {
        _weapon = GetComponentInChildren<Weapon>();

        Moving();
        Attack();
        Key();

    }

   

    private void Start()
    {
        _stat = GetComponent<PlayerStat>();
        _arrowPos = transform.Find("ArrowPos");
        _shop = GameObject.Find("NPC").GetComponentInChildren<Shop>();

        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;

        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
        Managers.UI.MakeOverlayUI<UI_User>(transform);

       
    }

    void Moving()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Animator anim = GetComponent<Animator>();

        Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * Time.deltaTime * _stat.MoveSpeed;

        if (vAxis > 0)
        {
            transform.LookAt(transform.position + moveVec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.3f);
            _motionSpeed = Mathf.Lerp(_motionSpeed, 1, _stat.MoveSpeed * Time.deltaTime);
           anim.SetFloat("Blend", _motionSpeed);
       

        }



        if (vAxis < 0)
        {
            transform.LookAt(transform.position + moveVec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f);
            _motionSpeed = Mathf.Lerp(_motionSpeed, 1, _stat.MoveSpeed * Time.deltaTime);
            anim.SetFloat("Blend", _motionSpeed);

        }



        if (hAxis < 0)
        {
           transform.LookAt(transform.position + moveVec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f);
            _motionSpeed = Mathf.Lerp(_motionSpeed, 1, _stat.MoveSpeed * Time.deltaTime);
            anim.SetFloat("Blend", _motionSpeed);

        }



        if (hAxis > 0)
        {
            transform.LookAt(transform.position + moveVec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f);
            _motionSpeed = Mathf.Lerp(_motionSpeed, 1, _stat.MoveSpeed * Time.deltaTime);
            anim.SetFloat("Blend", _motionSpeed);
        }

        if(moveVec == Vector3.zero)
        {
            _motionSpeed = Mathf.Lerp(_motionSpeed, 0, _stat.MoveSpeed * Time.deltaTime);
            anim.SetFloat("Blend", _motionSpeed);
        }
 
        
    }

    void Attack()
    {
        
        if(_weapon != null)
        {
            
            _motionDelay += Time.deltaTime;
            _isFireReady = _weapon.Rate < _motionDelay;



            if(_isFireReady && Input.GetKey(KeyCode.A))
            {
                if(_weapon.gameObject.tag == "Melee")
                {
                    _weapon.Melee();
                    Animator anim = GetComponent<Animator>();
                    anim.Play("Knife");
                    _motionDelay = 0;
                }

                if (_weapon.gameObject.tag == "Bow")
                {
                    _weapon.Bow();
                    Animator anim = GetComponent<Animator>();
                    anim.Play("Bow");
                    _motionDelay = 0;
                }

            }
        }

        
    }

    void Key()
    {
        keyCount = _stat.Level - 1;
        GameObject child;
        switch(keyCount)
        {
            case 1:
                child = transform.Find("Key1").gameObject;
                child.SetActive(true);
                break;

            case 2:
                child = transform.Find("Key2").gameObject;
                child.SetActive(true);
                break;
            case 3:
                child = transform.Find("Key3").gameObject;
                child.SetActive(true);
                break;
        
            default:
                Debug.Log("ERROR");
                break;
        }
        
       
            
    }

    void OnKeyBoard()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(_stat.Potion > 0)
            {
                _stat.Hp += 100;
                _stat.Potion--;
            }
            else
            {
                Debug.Log("ERROR POTION");
            }
        }

       
        if (Input.GetKeyDown(KeyCode.Alpha1)) weaponIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) weaponIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_equipWeapon != null)
                _equipWeapon.SetActive(false);

            _equipWeapon = weapons[weaponIndex];
            _equipWeapon.SetActive(true);
        }

        if(_shop.Active == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _shop.Exit();
            }
        }
    }
}
