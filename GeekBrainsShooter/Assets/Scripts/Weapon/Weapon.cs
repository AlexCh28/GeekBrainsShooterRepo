using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    protected Transform _firePoint;
    [SerializeField]
    protected ParticleSystem _hitVFX;
    [SerializeField]
    protected ParticleSystem _muzzleFlashVFX;
    [SerializeField]
    protected float _damagePerShot;
    [SerializeField]
    protected TrailRenderer _trail;

    protected virtual void Update() {
        Fire();
    }

    public virtual void Fire(){}

    public virtual void Reload(){}

    public virtual void RecoilAnimation(){}

    public virtual void ReloadAnimation(){}
}
