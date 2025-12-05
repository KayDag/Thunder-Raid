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
    public List<string> nameCharacter = new List<string>() { "Blue", "Purple", "Green" };

    public Canvas menuCanvas;
    public Canvas highscoreCanvas;
    public HighScoreUI highScoreUI;
    public UserSavePointDatas userSavePointDatas;
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
        ShowMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneKey.GameScene);
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
    public void ShowHighscore()
    {
        menuCanvas.gameObject.SetActive(false);
        highscoreCanvas.gameObject.SetActive(true);

        if (PlayerPrefs.HasKey("POINT_KEY"))
        {
            string jsonData = PlayerPrefs.GetString("POINT_KEY");
            UserSavePointDatas userData = JsonUtility.FromJson<UserSavePointDatas>(jsonData);

            if (userData.points == null)
                userData.points = new List<int>();

            highScoreUI.ShowScores(userData.points);
        }
        else
        {
            // chưa có dữ liệu thì hiển thị "-"
            highScoreUI.ShowScores(new List<int>());
        }
    }


    public void ShowMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        highscoreCanvas.gameObject.SetActive(false);
    }
}
