using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public RectTransform uiTransform;
    public void Open()
    {
        SetUIPosition(-60f);
    }

    public void Close()
    {
        SetUIPosition(-265f);
    }

    private void SetUIPosition(float targetPosY)
    {
        uiTransform.anchoredPosition = new Vector2(uiTransform.anchoredPosition.x, targetPosY);
    }
}
