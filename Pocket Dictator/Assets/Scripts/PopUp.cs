using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject whatToOpen;
    public GameObject whatToClose;

    public void OpenUIElement()
    {
        whatToOpen.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUIElement()
    {
        whatToClose.SetActive(false);
        Time.timeScale = 1;
    }
}
