using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private SOActorModel _actorModel;
    private GameObject _playerShip;

    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        // CREATE PLAYER
        _actorModel = Instantiate(Resources.Load(PathName.PLAYER_DEFAULT)) as SOActorModel;
        _playerShip = Instantiate(_actorModel.actor) as GameObject;
        _playerShip.GetComponent<Player>().ActorStats(_actorModel);

        // SET PLAYER UP
        _playerShip.transform.rotation = Quaternion.Euler(0, 180, 0);
        _playerShip.transform.localScale = new Vector3(60, 60, 60);
        _playerShip.name = ObjectName.Player;
        _playerShip.transform.SetParent(this.transform);
        _playerShip.transform.position = Vector3.zero;
    }
}
