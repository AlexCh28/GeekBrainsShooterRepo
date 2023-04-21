using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RedPistol : Weapon
{
    public override void RecoilAnimation(){
        transform.DOPunchPosition(new Vector3(0,0,-0.1f), 0.1f, 0, 0, false);
        transform.DOPunchRotation(new Vector3(30,0,0),0.1f,0,0);
    }
}
