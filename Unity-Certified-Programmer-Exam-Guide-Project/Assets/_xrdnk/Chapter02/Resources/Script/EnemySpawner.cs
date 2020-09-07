using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SOActorModel _actorModel;
    [SerializeField] private float _spawnRate;
    [SerializeField, Range(0, 10)] private int _quantity;

    private GameObject m_enemies;

    void Awake()
    {
        m_enemies = GameObject.Find(FindName._Enemy);
        StartCoroutine(FireEnemy(_quantity, _spawnRate));
    }

    private IEnumerator FireEnemy(int qty, float spwnRte)
    {
        for (int i = 0; i < qty; i++)
        {
            var enemyUnit = CreateEnemy();
            enemyUnit.gameObject.transform.SetParent(this.transform);
            enemyUnit.transform.position = transform.position;
            yield return new WaitForSeconds(spwnRte);
        }
        yield return null;
    }

    private GameObject CreateEnemy()
    {
        var enemy = Instantiate(_actorModel.actor) as GameObject;
        enemy.GetComponent<IActorTemplate>().ActorStats(_actorModel);
        enemy.name = _actorModel.actorName.ToString();
        return enemy;
    }
}
