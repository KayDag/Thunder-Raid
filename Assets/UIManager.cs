using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Canvas gameui;
    public Canvas pauseui;
    public Canvas endgameui;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameui.gameObject.SetActive(true);
        pauseui.gameObject.SetActive(false);
        endgameui.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
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
    public void EndGame()
    {
        if (Plane.Instance.IsDie() == true)
        {
            endgameui.gameObject.SetActive(true);
            gameui.gameObject.SetActive(false);

            score.text = GameManager.Instance.score.ToString();
        }
        else return;
    }
}
