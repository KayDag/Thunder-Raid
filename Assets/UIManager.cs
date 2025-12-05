using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Canvas gameui;
    public Canvas pauseui;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameui.gameObject.SetActive(true);
        pauseui.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(SceneKey.MenuScene);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        gameui.gameObject.SetActive(false);
        pauseui.gameObject.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameui.gameObject.SetActive(true);
        pauseui.gameObject.SetActive(false);
    }
}
