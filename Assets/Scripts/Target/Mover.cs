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
        transform.DOMove(target, time).SetEase(Ease.OutQuint).SetLoops(100).OnComplete(onComlete);
    }

    private void onComlete()
    {

    }


}
