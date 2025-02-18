using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public RectTransform uiTransform;
    public void Open()
    {
        SetUIPosition(-240f);
    }

    public void Close()
    {
        SetUIPosition(-680f);
    }

    private void SetUIPosition(float targetPosY)
    {
        uiTransform.anchoredPosition = new Vector2(uiTransform.anchoredPosition.x, targetPosY);
    }
}
