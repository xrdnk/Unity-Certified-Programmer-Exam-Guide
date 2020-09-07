using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, IActorTemplate
{
    private GameObject _actor;
    private int _hitPower;
    private int _health;
    private int _travelSpeed;

    [SerializeField]
    private SOActorModel _bulletModel;

    void Awake()
    {
        ActorStats(_bulletModel);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        _hitPower = actorModel.hitPower;
        _health = actorModel.health;
        _travelSpeed = actorModel.speed;
        _actor = actorModel.actor;
    }

    void Update()
    {
        transform.position += new Vector3(_travelSpeed, 0, 0) * Time.deltaTime;
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
            if (other.GetComponent<IActorTemplate>() != null)
            {
                if (_health >= 1)
                {
                    _health -= other.GetComponent<IActorTemplate>().SendDamage();
                }
                else
                {
                    Die();
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
