﻿using System.Collections;
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
        valueNews = GameManager.Instance.SRD * Random.Range(1, 10);
        NewChoosed = lstNews[r];
        Debug.Log("<color=yellow>News: </color>" + NewChoosed.content + valueNews + "%");
    }

    public void SetResultNew(int ID)
    {
        int set = NewChoosed.isUseful == true ? 1 : -1;
        if (NewChoosed.major == "SP1")
        {
            if(set < 0 && GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[1].moneyDTBD > 0)
            {
                if ((long)(set * GameManager.Instance.main.lsCoutryReady[ID].SP0)
                    > GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[1].moneyDTBD)
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[1].moneyDTBD = 0;
                    GameManager.Instance.main.lsCoutryReady[ID].SP0 +=
                        set * GameManager.Instance.main.lsCoutryReady[ID].SP0 +
                        GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[1].moneyDTBD;
                }
                else
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[1].moneyDTBD +=
                        (long)(set * GameManager.Instance.main.lsCoutryReady[ID].SP0);
                }
                return;
            }
            GameManager.Instance.main.lsCoutryReady[ID].SP0 += set * GameManager.Instance.main.lsCoutryReady[ID].SP0;
        }
        else if(NewChoosed.major == "Mkt1")
        {
            if (set < 0 && GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[0].moneyDTBD > 0)
            {
                if ((long)(set * GameManager.Instance.main.lsCoutryReady[ID].MKT0)
                     > GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[0].moneyDTBD)
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[0].moneyDTBD = 0;
                    GameManager.Instance.main.lsCoutryReady[ID].MKT0 +=
                        set * GameManager.Instance.main.lsCoutryReady[ID].MKT0 +
                        GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[0].moneyDTBD;
                }
                else
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[0].moneyDTBD +=
                        (long)(set * GameManager.Instance.main.lsCoutryReady[ID].MKT0);
                }
                return;
            }
            GameManager.Instance.main.lsCoutryReady[ID].MKT0 += set * GameManager.Instance.main.lsCoutryReady[ID].MKT0;
        }
        else if (NewChoosed.major == "Market1")
        {
            if (set < 0 && GameManager.Instance.main.lsCoutryReady[ID].bigBranch[2].smallBranch[1].moneyDTBD > 0)
            {
                if ((((long)(set * GameManager.Instance.main.lsCoutryReady[ID].MARKET0)/3)*GameManager.Instance.SRD) > GameManager.Instance.main.lsCoutryReady[ID].bigBranch[2].smallBranch[1].moneyDTBD)
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[2].smallBranch[1].moneyDTBD = 0;
                    GameManager.Instance.main.lsCoutryReady[ID].MARKET0 += (set * GameManager.Instance.main.lsCoutryReady[ID].MARKET0 + (GameManager.Instance.main.lsCoutryReady[ID].bigBranch[2].smallBranch[1].moneyDTBD)*3/ GameManager.Instance.SRD);
                }
                else
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[2].smallBranch[1].moneyDTBD +=
                        (((long)(set * GameManager.Instance.main.lsCoutryReady[ID].MARKET0) / 3) * GameManager.Instance.SRD);
                }
                return;
            }
            GameManager.Instance.main.lsCoutryReady[ID].MARKET0 += set * GameManager.Instance.main.lsCoutryReady[ID].MARKET0;
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
            if (set < 0 && GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[2].moneyDTBD > 0)
            {
                if ((long)(set * GameManager.Instance.main.lsCoutryReady[ID].NS0) 
                    > GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[2].moneyDTBD)
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[2].moneyDTBD = 0;
                    GameManager.Instance.main.lsCoutryReady[ID].NS0 += 
                        set * GameManager.Instance.main.lsCoutryReady[ID].NS0 + 
                        GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[2].moneyDTBD;
                }
                else
                {
                    GameManager.Instance.main.lsCoutryReady[ID].bigBranch[5].smallBranch[2].moneyDTBD +=
                        (long)(set * GameManager.Instance.main.lsCoutryReady[ID].NS0);
                }
                return;
            }
            GameManager.Instance.main.lsCoutryReady[ID].NS0 += set * GameManager.Instance.main.lsCoutryReady[ID].NS0;
        }
        else if (NewChoosed.major == "St1")
        {
            GameManager.Instance.main.lsCoutryReady[ID].ST0 += set * GameManager.Instance.main.lsCoutryReady[ID].ST0;
        }
    }
}
