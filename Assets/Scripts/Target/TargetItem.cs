using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TargetItem : MonoBehaviour, IScore,IReacatble
{
    [SerializeField] private int _point = 1;
    [SerializeField] private TMP_Text pointText;
    public bool isMoveable = false;

    [SerializeField]public Vector3 target;
    [SerializeField]public int time = 5;
    private Sequence sequence;


    public int GetPoint()
    {
        return _point;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        ReactOnCollide();
    //    }
    //}

    public void SetPoint(int point)
    {
        _point = point;
        pointText.text = _point + "";
    }


    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetPoint(1);
        if (isMoveable)
        {
            SetPoint(Random.Range(2,10));
            StartMovement();
        }
    }

    private void StartMovement()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(target, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
    }

    private void OnDisable()
    {
        SetPoint(0);
        sequence?.Kill();
    }

    public void ReactOnCollide()
    {
        sequence?.Kill();
        GameManager.shared.GetGameInstances().soundManager.PlayTargetCollideSound();
        Debug.Log("Destroy Item...");
    }
}

public interface IReacatble
{
    void ReactOnCollide();
}
