using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News : MonoBehaviour
{
    public static News Instance = new News();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        
    }

    public struct NewItems
    {
        public string content;
        public bool isUseful;
    }

    public List<NewItems> lstNews = new List<NewItems>();
    public NewItems NewChoosed;
    //List<int> lstPercent = new List<int> { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };
    public int valueNews;

    public void GetNews()
    {
        int r = Random.Range(0, lstNews.Count);
        valueNews = GameConfig.Instance.Srd * Random.Range(1, 10);

        NewChoosed = lstNews[r];
        Debug.Log("<color=yellow> News: </color>" + NewChoosed.content + valueNews + "%");
    }
}
