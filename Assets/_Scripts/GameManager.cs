using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct EconomicSegment
{
    public string name;
    public string code;
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public DateTime dateStartPlay;
    public int modePlay;
    public int SRD;

    [Header("DateTime")]
    public DateTime dateGame;
    private float time;

    [Header("BusinessMan")]
    public BusinessMan main;

    [Header("EconomicSegment")]
    public EconomicSegment[] arreconomicSegments;

    [Header("SelfTraining")]
    public GameObject itemSelf;
    public Transform contentSelf;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public void LoadDate()
    {
        dateGame = new DateTime(1996, 1, 1);
        dateStartPlay = dateGame;
        SetDate();
    }

    void SetDate()
    {
        if (dateGame.Day >= 10)
        {
            UIManager.Instance.txtday1.text = (dateGame.Day / 10).ToString();
            UIManager.Instance.txtday2.text = (dateGame.Day - (dateGame.Day / 10) * 10).ToString();
        }
        else
        {
            UIManager.Instance.txtday1.text = "0";
            UIManager.Instance.txtday2.text = dateGame.Day.ToString();
        }
        if (dateGame.Month >= 10)
        {
            UIManager.Instance.txtmonth1.text = (dateGame.Month / 10).ToString();
            UIManager.Instance.txtmonth2.text = (dateGame.Month - (dateGame.Month / 10) * 10).ToString();
        }
        else
        {
            UIManager.Instance.txtmonth1.text = "0";
            UIManager.Instance.txtmonth2.text = dateGame.Month.ToString();
        }
        string yearstring = dateGame.Year.ToString();
        UIManager.Instance.txtyear1.text = yearstring.Substring(0, 1);
        UIManager.Instance.txtyear2.text = yearstring.Substring(1, 1);
        UIManager.Instance.txtyear3.text = yearstring.Substring(2, 1);
        UIManager.Instance.txtyear4.text = yearstring.Substring(3, 1);
    }

    void Update()
    {
        if (UIManager.Instance.isPlay)
        {
            time += Time.deltaTime;
            if (time >= 4)
            {
                UpdateDataUser(main);
                int month = dateGame.Month;
                int year = dateGame.Year;
                dateGame = dateGame.AddDays(1f);
                SetDate();
                if (dateGame.Month > month)
                {
                    for (int i = 0; i < main.lsCoutryReady.Count; i++)
                    {
                        main.lsCoutryReady[i].PullData();
                    }
                }
                if (modePlay == 1)
                {
                    if (year - dateStartPlay.Year >= 5)
                    {
                        Time.timeScale = 0;
                        UIManager.Instance.isPlay = false;
                        if (main.coin > 1000000000)
                        {
                            UIManager.Instance.panelWin.SetActive(true);
                        }
                        else
                        {
                            UIManager.Instance.panelGameOver.SetActive(true);
                        }
                    }
                }
                DataPlayer.Instance.SaveDataPlayer();
                time = 0;
            }
        }

    }

    void UpdateDataUser(BusinessMan man)
    {
        for(int i = 0; i < main.lsCoutryReady.Count; i++)
        {
            main.lsCoutryReady[i].Interest();
        }
    }

}
