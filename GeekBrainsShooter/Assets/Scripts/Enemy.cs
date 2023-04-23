using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerTag>().transform;
    }

    private void Update() {
        _agent.destination = _player.position;
    }
}
