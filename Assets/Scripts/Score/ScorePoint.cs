using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour,IScore
{
    [SerializeField] private int _point = 1;

    public int GetPoint()
    {
        return _point;
    }

    public void SetPoint(int point)
    {
        _point = point;
    }
}

public interface IScore
{
    void SetPoint(int point);
    int GetPoint();
}

