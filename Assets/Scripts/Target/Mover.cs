using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    public Vector3 target;
    public int time = 5;


    void Start()
    {
        transform.DOLocalMove(target, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void onComlete()
    {

    }


}
