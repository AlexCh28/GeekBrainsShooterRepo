using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyHealthBar))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _damage;
    protected Animator _animator;
    protected NavMeshAgent _agent;
    protected EnemyHealthBar _healthBar;
    protected Transform _player;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _healthBar = GetComponent<EnemyHealthBar>();
        _player = FindObjectOfType<PlayerTag>().transform;
        _agent.destination = _player.position;
        _agent.avoidancePriority = Random.Range(1, 100);
    }

    private void Update() {
        _agent.destination = _player.position;
        
        if (_agent.remainingDistance < _agent.stoppingDistance) {
            Attack();
        }
        else if (_agent.hasPath) {
            _animator.SetBool("IsWalk", true);
        }
        else{
            _animator.SetBool("IsWalk", false);
        }
    }

    private void Attack(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        _animator.SetTrigger("Attack");
        DoDamage(_damage);
    }

    protected abstract void DoDamage(float damage);
}
