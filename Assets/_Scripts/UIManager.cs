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
    public Button btnWORD;
    public Button btnTHONGSO;
    public Button btnNHOM1;
    public Button btnNHOM2;
    public Button btnNHOM3;

    [Header("Branch")]
    public Button btnBRANCH1;
    public Button btnBRANCH2;
    public Button btnBRANCH3;


    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public void OnclickWORD()
    {
        btnWORD.transform.GetChild(1).gameObject.SetActive(true);
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM3.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(true);
        PieChart1.SetActive(false);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(false);
        SelfTraining.SetActive(false);
        Word.Instance.OnEnableWord(true);
    }

    public void OnclickTHONGSO()
    {
        btnWORD.transform.GetChild(1).gameObject.SetActive(false);
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(true);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM3.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(true);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(false);
        SelfTraining.SetActive(false);
        Word.Instance.OnEnableWord(false);
    }

    public void OnclickNHOM1()
    {
        btnWORD.transform.GetChild(1).gameObject.SetActive(false);
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(true);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM3.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(true);
        SelfTraining.SetActive(false);
        Word.Instance.OnEnableWord(false);
    }

    public void OnclickNHOM2()
    {
        btnWORD.transform.GetChild(1).gameObject.SetActive(false);
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(true);
        btnNHOM3.transform.GetChild(1).gameObject.SetActive(false);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(true);
        SelfTraining.SetActive(false);
        Word.Instance.OnEnableWord(false);
    }

    public void OnclickNHOM3()
    {
        btnWORD.transform.GetChild(1).gameObject.SetActive(false);
        btnTHONGSO.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM1.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM2.transform.GetChild(1).gameObject.SetActive(false);
        btnNHOM3.transform.GetChild(1).gameObject.SetActive(true);
        MAP.SetActive(false);
        PieChart1.SetActive(false);
        COLCHART.SetActive(false);
        PieChart2.SetActive(false);
        SELFTRAINING.SetActive(true);
        SelfTraining.SetActive(false);
        Word.Instance.OnEnableWord(false);
    }

    public void PlayGame(int SRD)
    {
        GameManager.Instance.SRD = SRD;
        menuGame.SetActive(false);
        GameManager.Instance.main.bitCoin = 1000 * SRD;
        GameManager.Instance.main.gold = 50000 * SRD;
        OnclickWORD();
    }

    public void Update()
    {
        txtGold.text = GameManager.Instance.main.gold.ToString();
        txtBitCoin.text = GameManager.Instance.main.bitCoin.ToString();
    }
}
