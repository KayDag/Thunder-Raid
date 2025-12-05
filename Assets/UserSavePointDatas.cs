using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//muốn chuyển class qua json
//1.đầu class có [System.Serializable]
//2. xóa : MonoBehaviour
[System.Serializable]
public class UserSavePointDatas
{
    public string user;
    //lưu ds điểm qua các lần chơi
    public List<int> points;
    public List<string> characters;
    public List<string> times;

    public UserSavePointDatas()
    {
        points = new List<int>();
        characters = new List<string>();
        times = new List<string>();
    }
        //đầu game
    public void StartGame(){
        points.Add(0);
        characters.Add("");
        times.Add("");
    }
        //sửa điểm hiện tại
    public void UpdatePoints(int point, string nameChar, string time){
            //points.Last()
        if(points.Count > 0){
            points[points.Count-1] = point;
        }
        if (characters.Count > 0)
        {
            characters[characters.Count - 1] = nameChar;
        }
        if (times.Count > 0)
        {
            times[times.Count - 1] = time;
        }
    }
}
