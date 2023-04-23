using UnityEngine;
using DG.Tweening;

public class CameraPivot : MonoBehaviour
{
    void Start()
    {
        LeftSelfRotate();
    }

    private void LeftSelfRotate(){
        transform.DOLocalRotate(Vector3.up*360f, 100, RotateMode.FastBeyond360).OnComplete(()=>RightSelfRotate());
    }
    private void RightSelfRotate(){
        transform.DOLocalRotate(Vector3.up*(-360f), 100, RotateMode.FastBeyond360).OnComplete(()=>LeftSelfRotate());
    }
}
