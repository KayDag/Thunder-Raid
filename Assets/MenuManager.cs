using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static int index = 0;
    public GameObject[] character;
    public GameObject[] characterPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        SelectCharactor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneKey.GameScene);
    }
    public void HighScore()
    {
        SceneManager.LoadScene(SceneKey.ScoreScene);
    }
    public void btnPrev()
    {
        index = (index == 0) ? character.Length - 1 : index - 1;
        SelectCharactor();
    }

    public void btnNext()
    {
        index = (index == character.Length - 1) ? 0 : index + 1;
        SelectCharactor();
    }

    public void SelectCharactor()
    {
        for (int i = 0; i < character.Length; i++)
        {
            if (i == index)
            {
                character[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                character[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
