using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FireMode))]
public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    protected Transform _anchor;
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

    public Transform Anchor => _anchor;

    private FireMode _fireMode;

    private void Start() {
        _fireMode = GetComponent<FireMode>();
    }

    public virtual void Fire(){
        if (!_fireMode.CanShoot) return;
        
        if (!_fireMode.IsAutomatic) {
            _fireMode.WasReleased = false;
        }
        
        _fireMode.Timer = 0f;

        RecoilAnimation();

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            ParticleSystem muzzleFlash = Instantiate(_muzzleFlashVFX, _firePoint.position, Quaternion.identity);
            muzzleFlash.transform.parent = _firePoint;

            if (hitInfo.transform.gameObject.layer != 12){
                ParticleSystem hitEffect = Instantiate(_hitVFX, hitInfo.point, Quaternion.identity);
                hitEffect.transform.forward = hitInfo.normal;
            }

            TrailRenderer trailEffect = Instantiate(_trail, _firePoint.position, Quaternion.identity);
            trailEffect.AddPosition(hitInfo.point);

            IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(_damagePerShot);
            }
        }
    }

    public virtual void Reload(){}

    public virtual void RecoilAnimation(){}

    public virtual void ReloadAnimation(){}
}
