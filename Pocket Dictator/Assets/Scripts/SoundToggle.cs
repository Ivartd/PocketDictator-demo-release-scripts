using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;

    public Toggle toggle;

    Vector2 handlePosition;

    void Awake()
    {
        //toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);

    }

    void OnSwitch(bool on)
    {
        if (on)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            AudioListener.pause = false;
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            AudioListener.pause = true;
        }
        //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }

}

