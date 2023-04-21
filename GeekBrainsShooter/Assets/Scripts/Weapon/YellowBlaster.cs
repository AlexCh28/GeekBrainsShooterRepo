using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YellowBlaster : Weapon
{
    public override void Fire()
    {
        if (Input.GetMouseButtonDown(0)){
            RecoilAnimation();

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)){
                ParticleSystem hitEffect = Instantiate(_hitVFX, hitInfo.point, Quaternion.identity);
                hitEffect.transform.forward = hitInfo.normal;

                TrailRenderer trailEffect = Instantiate(_trail, _firePoint.position, Quaternion.identity);
                trailEffect.AddPosition(hitInfo.point);
            }
        }
    }

    public override void RecoilAnimation(){
        transform.DOPunchPosition(new Vector3(0,0,0.1f), 0.1f, 0, 0, false);
    }
    
}
