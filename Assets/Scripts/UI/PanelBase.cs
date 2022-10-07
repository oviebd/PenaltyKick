using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}
