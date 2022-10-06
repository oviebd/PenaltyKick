using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetItem : MonoBehaviour, IScore,IReacatble
{
    [SerializeField] private int _point = 1;
    [SerializeField] private TMP_Text pointText;
    public bool isMoveable = false;

    public int GetPoint()
    {
        return _point;
    }

   
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
        }

    }

    private void OnDisable()
    {
        SetPoint(0);
    }

    public void ReactOnCollide()
    {
        Debug.Log("Destroy Item...");
    }
}

public interface IReacatble
{
    void ReactOnCollide();
}
