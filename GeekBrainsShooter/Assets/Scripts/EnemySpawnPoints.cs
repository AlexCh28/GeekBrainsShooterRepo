using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField]
    private float timeInterval = 2f;

    [SerializeField]
    private List<Transform> _spawnPoints = new();

    [SerializeField]
    private List<GameObject> _enemyPrefabs = new();

    private float timer;

    private void Update() {
        if (_spawnPoints.Count == 0) return;
        if (_enemyPrefabs.Count == 0) return;

        timer += Time.deltaTime;
        if (timer > timeInterval){
            timer = 0;

            Vector3 spawnPointPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            GameObject enemyToSpawn = _enemyPrefabs[Random.Range(0, _spawnPoints.Count)];

            Instantiate(enemyToSpawn, spawnPointPosition, Quaternion.identity);
        }
    }

}
