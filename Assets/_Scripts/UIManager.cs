using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [Header("MenuGame")]
    public GameObject menuGame;

    [Header("SelectCountry")]
    public GameObject MAP;
    public GameObject PieChart1;

    [Header("ColumnChart")]
    public GameObject COLCHART;
    public GameObject PieChart2;

    [Header("SelfTraining")]
    public GameObject SELFTRAINING;
    public GameObject SelfTraining;

    [Header("DateTime")]
    #region DateTime  
    public Text txtday1;
    public Text txtday2;
    public Text txtmonth1;
    public Text txtmonth2;
    public Text txtyear1;
    public Text txtyear2;
    public Text txtyear3;
    public Text txtyear4;
    #endregion

    [Header("UIWord")]
    public GameObject POSITIONSELECT;

    [Header("InfoMain")]
    public Text txtGold;
    public Text txtBitCoin;

    [Header("ButtomMenu")]
    public Button btnTHONGSO;
    public Button btnNHOM1;
    public Button btnNHOM2;

    [Header("Branch")]
    public Button branch1;


    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public void OnclickTHONGSO()
    {
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(true);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(true);
        PieChart1.SetActive(true);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(false);
        SelfTraining.SetActive(false);
        StartCoroutine(Word.Instance.OnEnableWord(true));
    }

    public void OnclickNHOM1()
    {
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(true);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(true);
        PieChart2.SetActive(true);
        SELFTRAINING.SetActive(false);
        SelfTraining.SetActive(false);
        StartCoroutine(Word.Instance.OnEnableWord(false));
    }

    public void OnclickNHOM2()
    {
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(true);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(true);
        SelfTraining.SetActive(true);
        StartCoroutine(Word.Instance.OnEnableWord(false));
    }

    public void PlayGame(int SRD)
    {
        GameManager.Instance.SRD = SRD;
        menuGame.SetActive(false);
        GameManager.Instance.main.bitCoin = 1000 * SRD;
        GameManager.Instance.main.gold = 50000 * SRD;
        OnclickTHONGSO();
    }

    public void Update()
    {
        txtGold.text = GameManager.Instance.main.gold.ToString();
        txtBitCoin.text = GameManager.Instance.main.bitCoin.ToString();
    }
}
