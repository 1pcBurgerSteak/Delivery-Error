using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public RectTransform targetObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Vector3 newPosition = targetObject.anchoredPosition;
        newPosition.y = -250;
        targetObject.anchoredPosition = newPosition;
    }

    public void Close()
    {
        Vector3 newPosition = targetObject.anchoredPosition;
        newPosition.y = -680;
        targetObject.anchoredPosition = newPosition;
    }
}
