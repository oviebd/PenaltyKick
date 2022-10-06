using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour, IScore,ICollisionEnter
{
    [SerializeField] private int _point = 1;
    public bool isMoveable = false;

    public int GetPoint()
    {
        return _point;
    }

   
    public void SetPoint(int point)
    {
        _point = point;
    }

    public void onCollisionEnter(GameObject collidedObj)
    {
        Debug.Log("Destroy Item...");
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
}
