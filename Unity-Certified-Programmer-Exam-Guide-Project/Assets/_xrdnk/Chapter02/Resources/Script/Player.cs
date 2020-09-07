using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{
    private int _travelSpeed;
    private int _health;
    private int _hitPower;
    private GameObject _actor;
    private GameObject _fire;
    private GameObject _Player;
    private float _width;
    private float _height;

    public int Health { get { return _health; } private set { _health = value; } }
    public GameObject Fire { get { return _fire; } private set { _fire = value; } }

    public void ActorStats(SOActorModel actorModel)
    {
        _health = actorModel.health;
        _travelSpeed = actorModel.speed;
        _hitPower = actorModel.hitPower;
        _fire = actorModel.actorBullets;
    }

    void Start()
    {
        var mainCamera = Camera.main;
        _height = 1 / (mainCamera.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
        _width = 1 / (mainCamera.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        _Player = GameObject.Find(FindName._Player);
    }

    void Update()
    {
        Movement();
        Attack();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public int SendDamage() => _hitPower;

    public void TakeDamage(int incomingDamage) => _health -= incomingDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagName.Enemy))
        {
            if (_health >= 1)
            {
                if (transform.Find(FindName.ENERGY))
                {
                    Destroy(transform.Find(FindName.ENERGY).gameObject);
                    _health -= other.GetComponent<IActorTemplate>().SendDamage();
                }
                else
                {
                    _health--;
                }
            }
            else
            {
                Die();
            }
        }
    }

    private void Movement()
    {
        if (Input.GetAxisRaw(InputName.HORIZONTAL) > 0)
        {
            if (transform.localPosition.x < _width + _width / 0.9f)
            {
                transform.localPosition += new Vector3(Input.GetAxisRaw(InputName.HORIZONTAL) * Time.deltaTime * _travelSpeed, 0, 0);
            }
        }

        if (Input.GetAxisRaw(InputName.HORIZONTAL) < 0)
        {
            if (transform.localPosition.x > _width + _width / 6f)
            {
                transform.localPosition += new Vector3(Input.GetAxisRaw(InputName.HORIZONTAL) * Time.deltaTime * _travelSpeed, 0, 0);
            }
        }

        if (Input.GetAxisRaw(InputName.VERTICAL) < 0)
        {
            if (transform.localPosition.y > -_height / 3f)
            {
                transform.localPosition += new Vector3(0, Input.GetAxisRaw(InputName.VERTICAL) * Time.deltaTime * _travelSpeed, 0);
            }
        }

        if (Input.GetAxisRaw(InputName.VERTICAL) > 0)
        {
            if (transform.localPosition.y < _height / 2.5f)
            {
                transform.localPosition += new Vector3(0, Input.GetAxisRaw(InputName.VERTICAL) * Time.deltaTime * _travelSpeed, 0);
            }
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown(InputName.FIRE_ONE))
        {
            var bullet = Instantiate(_fire, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            bullet.transform.SetParent(_Player.transform);
            bullet.transform.localScale = new Vector3(7, 7, 7);
        }
    }
}
