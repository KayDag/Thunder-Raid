using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level;
    public int score;
    private UserSavePointDatas userSavePointDatas;
    public string nameCharacter;
    public string time;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        nameCharacter = MenuManager.Instance.nameCharacter[MenuManager.index];
        time = DateTime.Now.ToString();
        if (PlayerPrefs.HasKey(UserDataKey.POINT_KEY))
        {
            string jsonData = PlayerPrefs.GetString(UserDataKey.POINT_KEY);
            userSavePointDatas = JsonUtility.FromJson<UserSavePointDatas>(jsonData);

            if (userSavePointDatas == null)
            {
                userSavePointDatas = new UserSavePointDatas();
            }
        }
        else
        {
            userSavePointDatas = new UserSavePointDatas();
        }

        userSavePointDatas.StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddStar(int amount)
    {
        score += amount;

        //update điểm vào data scheme
        userSavePointDatas.UpdatePoints(score, nameCharacter, time);
        //lưu data vào player prefs
        //chuyển user save point datas sang string
        string jsonData = JsonUtility.ToJson(userSavePointDatas);
        Debug.Log("jsonData: " + jsonData);
        PlayerPrefs.SetString(UserDataKey.POINT_KEY, jsonData);
        PlayerPrefs.Save();
        Debug.Log($"Score: {score}, Character: {nameCharacter}, Time: {time}");
    }
}
