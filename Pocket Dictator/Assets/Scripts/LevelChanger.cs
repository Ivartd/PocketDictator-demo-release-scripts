using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int sceneToLoad;
    public int loadDelay;

    public void Start()
    {
        Invoke("LoadScene", loadDelay);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
