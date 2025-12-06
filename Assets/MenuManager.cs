using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static int index = 0;
    public GameObject[] character;
    public GameObject[] characterPrefab;
    public List<string> nameCharacter = new List<string>() { "Blue", "Purple", "Green" };
    public string userID;
    public TextMeshProUGUI user;
    public TMP_InputField usernameInput;

    public Canvas menuCanvas;
    public Canvas highscoreCanvas;
    public HighScoreUI highScoreUI;
    public Canvas firstGame;
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
        if (PlayerPrefs.HasKey(UserDataKey.USER_KEY))
        {
            userID = PlayerPrefs.GetString(UserDataKey.USER_KEY);
            user.text = userID;
        }
        FirstGame();
        usernameInput.onEndEdit.AddListener(SignUp);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(userID))
        {
            SceneManager.LoadScene(SceneKey.GameScene);
        }
        else return;
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
    public UserSavePointDatas GetUserData()
    {
        if (PlayerPrefs.HasKey(UserDataKey.POINT_KEY))
        {
            string jsonData = PlayerPrefs.GetString(UserDataKey.POINT_KEY);
            UserSavePointDatas userData = JsonUtility.FromJson<UserSavePointDatas>(jsonData);
            if (userData.points == null || userData.points.Count == 0)
                userData.points = null;

            return userData;
        }
        else
        {
            return new UserSavePointDatas { points = null };
        }
    }

    public void FirstGame()
    {
        UserSavePointDatas userData = GetUserData();
        if (userData.points == null && string.IsNullOrEmpty(userID))
        {
            firstGame.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }
        else
        {
            firstGame.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
    }
    public void SignUp(string input)
    {
        input = usernameInput.text.Trim();
        if (string.IsNullOrEmpty(input))
        {
            Debug.Log("Please enter a username!");
            return;
        }

        userID = input;
        user.text = userID;
        PlayerPrefs.SetString(UserDataKey.USER_KEY, userID);
        PlayerPrefs.Save();
    }

    public void ShowHighscore()
    {
        menuCanvas.gameObject.SetActive(false);
        highscoreCanvas.gameObject.SetActive(true);
        UserSavePointDatas userData = GetUserData();
        highScoreUI.ShowScores(userData.points);
    }

    public void ShowMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        highscoreCanvas.gameObject.SetActive(false);
    }
}
