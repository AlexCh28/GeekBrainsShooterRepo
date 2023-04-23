using UnityEngine;
using DG.Tweening;

public class EnemyHealthBar : HealthBarController
{
    private bool _isDead;
    private void OnEnable() {
        _isDead = false;
    }
    public override void GetDamage(float damage){
        base.GetDamage(damage);
        if (_health <= 0 && !_isDead) {
            _isDead = true;
            GameManager.singleton.DefeatToWin -= 1;
            transform.DOLocalRotate(new Vector3(-90,0,0),0.5f).OnComplete(()=>Destroy(gameObject));
        }
    }
}