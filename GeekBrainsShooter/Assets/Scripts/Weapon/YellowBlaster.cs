using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class YellowBlaster : Weapon
{
    public override void RecoilAnimation(){
        transform.DOPunchPosition(new Vector3(0,0,-0.1f), 0.1f, 0, 0, false);
    }
}
