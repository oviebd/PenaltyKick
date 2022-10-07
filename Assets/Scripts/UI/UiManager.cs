using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private InGameUI inGameUI;


    public void SetInitialGameUI(int kickNumber)
    {
        inGameUI.setUpIngameUI(kickNumber);
    }


}
