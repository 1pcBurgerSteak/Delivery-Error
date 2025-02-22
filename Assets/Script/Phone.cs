using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public RectTransform uiTransform;
    public static Phone instance;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void Open()
    {
        audioManager.PlaySFX(audioManager.click);
        SetUIPosition(-240f);
    }

    public void Close()
    {
        audioManager.PlaySFX(audioManager.click);
        SetUIPosition(-680f);
    }

    private void SetUIPosition(float targetPosY)
    {
        uiTransform.anchoredPosition = new Vector2(uiTransform.anchoredPosition.x, targetPosY);
    }
}
