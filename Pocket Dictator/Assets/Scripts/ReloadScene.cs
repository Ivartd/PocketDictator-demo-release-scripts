using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadThisScene()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
        else
            SceneManager.LoadScene(1);
    }
}
