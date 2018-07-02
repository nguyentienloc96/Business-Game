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
    public int SRD;

    [Header("DateTime")]
    public DateTime dateGame;
    private float time;

    [Header("BusinessMan")]
    public BusinessMan main;
    public BusinessMan competitors;

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

    void Start()
    {
        dateGame = new DateTime(1996, 10, 27);
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
        time += Time.deltaTime;
        if (time >= 4)
        {
            UpdateDataUser(main);
            dateGame = dateGame.AddDays(1f);
            SetDate();
            time = 0;
        }
    }

    void UpdateDataUser(BusinessMan man)
    {
        for(int i = 0; i < main.lsCoutryReady.Count; i++)
        {
            main.lsCoutryReady[i].SetFactoryWorkshop();
            main.lsCoutryReady[i].SetBuyingSotherFactoryWorkshop();
            main.lsCoutryReady[i].Interest();
        }
    }
}
