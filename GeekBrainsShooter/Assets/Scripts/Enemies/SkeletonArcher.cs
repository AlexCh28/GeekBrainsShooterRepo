using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkeletonArcher : Enemy
{
    [SerializeField] private GameObject _arrow;

    private void DoArrow(){
        GameObject arrow = Instantiate(_arrow, transform.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Damage = _damage;
        arrow.transform.forward = transform.forward;
        arrow.transform.Translate(0,0.5f,0);
        arrow.transform.Rotate(-90f,0,0);
    }
    protected override void DoDamage(float damage)
    {
        transform.DOLookAt(_player.position, 0.1f).OnComplete(()=>DoArrow());
    }
}
