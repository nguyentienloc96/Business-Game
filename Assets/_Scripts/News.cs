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

    private void Update()
    {
        
    }

    public struct NewItems
    {
        public string content;
        public bool isUseful;
        public string major;
    }

    public List<NewItems> lstNews = new List<NewItems>();
    public NewItems NewChoosed;
    //List<int> lstPercent = new List<int> { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };
    public int valueNews = 0;

    public void GetNews()
    {
        int r = Random.Range(0, lstNews.Count);
        valueNews = GameConfig.Instance.Srd * Random.Range(1, 10);
        NewChoosed = lstNews[r];
        Debug.Log("<color=yellow>News: </color>" + NewChoosed.content + valueNews + "%");
    }

    public void SetResultNew(int ID)
    {
        int set = NewChoosed.isUseful == true ? 1 : -1;
        if (NewChoosed.major == "SP1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].SP0 += set * GameManager.Instance.main.lsCoutryReady[ID].SP0;
        }
        else if(NewChoosed.major == "Mkt1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].MKT0 += set * GameManager.Instance.main.lsCoutryReady[ID].MKT0;

        }
        else if (NewChoosed.major == "Market1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].MAKRET0 += set * GameManager.Instance.main.lsCoutryReady[ID].MAKRET0;

        }
        else if (NewChoosed.major == "Lo1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].L0 += set * GameManager.Instance.main.lsCoutryReady[ID].L0;

        }
        else if (NewChoosed.major == "Kh1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].KH0 += set * GameManager.Instance.main.lsCoutryReady[ID].KH0;

        }
        else if (NewChoosed.major == "NS1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].NS0 += set * GameManager.Instance.main.lsCoutryReady[ID].NS0;

        }
        else if (NewChoosed.major == "St1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].ST0 += set * GameManager.Instance.main.lsCoutryReady[ID].ST0;

        }
    }
}
