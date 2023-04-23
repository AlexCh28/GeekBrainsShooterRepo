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

    private int _spawnIndex;

    private void Update() {
        if (_spawnPoints.Count == 0) return;
        if (_enemyPrefabs.Count == 0) return;

        timer += Time.deltaTime;
        if (timer > timeInterval && GameManager.singleton.AmountOfEnemies > 0){
            timer = 0;

            Vector3 spawnPointPosition = _spawnPoints[_spawnIndex].position;
            GameObject enemyToSpawn = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];

            Instantiate(enemyToSpawn, spawnPointPosition, Quaternion.identity);

            GameManager.singleton.AmountOfEnemies -= 1;
            _spawnIndex = _spawnIndex+1>=_spawnPoints.Count ? 0 : _spawnIndex+1;
        }
    }

}
