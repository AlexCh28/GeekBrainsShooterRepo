using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _damage;

    public float Damage {get{return _damage;} set{_damage = value;}}
    void Update()
    {
        transform.Translate(0, -_speed*Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other) {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null && other.GetComponent<PlayerTag>()) {
            damagable.GetDamage(_damage);
            Destroy(gameObject, 0.1f);
        }
        Destroy(gameObject, 10f);
    }
}
