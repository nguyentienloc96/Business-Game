using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int SRD = 1;

    public DateTime dateGame;
    public Text txtday1;
    public Text txtday2;
    public Text txtmonth1;
    public Text txtmonth2;
    public Text txtyear1;
    public Text txtyear2;
    public Text txtyear3;
    public Text txtyear4;

    private float time;


    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        dateGame = new DateTime(1996, 10, 27);
        SetDate();
    }


    void SetDate()
    {
        if (dateGame.Day >= 10)
        {
            txtday1.text = (dateGame.Day / 10).ToString();
            txtday2.text = (dateGame.Day - (dateGame.Day / 10) * 10).ToString();
        }
        else
        {
            txtday1.text = "0";
            txtday2.text = dateGame.Day.ToString();
        }
        if (dateGame.Month >= 10)
        {
            txtmonth1.text = (dateGame.Month / 10).ToString();
            txtmonth2.text = (dateGame.Month - (dateGame.Month / 10) * 10).ToString();
        }
        else
        {
            txtmonth1.text = "0";
            txtmonth2.text = dateGame.Month.ToString();
        }
        string yearstring = dateGame.Year.ToString();
        txtyear1.text = yearstring.Substring(0, 1);
        txtyear2.text = yearstring.Substring(1, 1);
        txtyear3.text = yearstring.Substring(2, 1);
        txtyear4.text = yearstring.Substring(3, 1);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 4)
        {
            dateGame = dateGame.AddDays(1f);
            SetDate();
            Debug.Log(dateGame);
            time = 0;
        }
    }
}
