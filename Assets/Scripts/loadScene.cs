using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    AsyncOperation loadingOperation;
    float loadProgress = 0;
    public Slider progress;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("Main");
        loadingOperation = SceneManager.LoadSceneAsync("Main");
    }

    // Update is called once per frame
    void Update()
    {
        loadProgress = loadingOperation.progress;
        progress.value = Mathf.Clamp01(loadProgress / 0.9f);

    }
}
