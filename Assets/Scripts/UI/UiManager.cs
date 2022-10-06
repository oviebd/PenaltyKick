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

    public void UpdateScore(int score)
    {
        inGameUI.UpdateScoreCount(score);
    }

    public void UpdateKickCountUi(int kickNumber, KickCountUiItem.ITEM_TYPE type)
    {
        inGameUI.UpdateKickCountUI(kickNumber,type);
    }

}
