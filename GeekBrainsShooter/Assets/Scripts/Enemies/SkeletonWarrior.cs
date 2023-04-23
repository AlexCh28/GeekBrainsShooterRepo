using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarrior : Enemy
{
    protected override void DoDamage(float damage)
    {
        _player.GetComponent<IDamagable>().GetDamage(damage);
    }
}
