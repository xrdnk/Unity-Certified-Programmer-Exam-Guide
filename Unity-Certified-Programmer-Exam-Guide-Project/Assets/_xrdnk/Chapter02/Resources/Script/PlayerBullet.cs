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

    void Start()
    {

    }

    void Update()
    {

    }

    public void ActorStats(SOActorModel actorModel)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public int SendDamage()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int incomingDamage)
    {
        throw new System.NotImplementedException();
    }
}
