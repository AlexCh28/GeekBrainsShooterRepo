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

    public virtual void Fire(){
        RecoilAnimation();

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            ParticleSystem muzzleFlash = Instantiate(_muzzleFlashVFX, _firePoint.position, Quaternion.identity);
            muzzleFlash.transform.parent = _firePoint;

            ParticleSystem hitEffect = Instantiate(_hitVFX, hitInfo.point, Quaternion.identity);
            hitEffect.transform.forward = hitInfo.normal;

            TrailRenderer trailEffect = Instantiate(_trail, _firePoint.position, Quaternion.identity);
            trailEffect.AddPosition(hitInfo.point);
        }
    }

    public virtual void Reload(){}

    public virtual void RecoilAnimation(){}

    public virtual void ReloadAnimation(){}
}
