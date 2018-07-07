using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    public int indexScene = 0;

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
    public Text LabelCountry;
    public Text txtCodeCountry;
    public Text txtGDPCountry;

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

    [Header("SelfTaining")]
    public Slider sliderTraining;
    public Text coinSelf;

    [Header("SRD")]
    public GameObject btnEasy;
    public GameObject btnMedium;
    public GameObject btnHard;
    public GameObject btnCrazy;

    [Header("ModePlay")]
    public GameObject panelMODEPLAY;
    public bool isPlay;

    [Header("GameOver")]
    public GameObject panelGameOver;
    public GameObject panelWin;


    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public void OnclickWORD()
    {
        indexScene = 0;
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
        indexScene = 1;
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
        indexScene = 2;
        for (int i = 0; i < GameManager.Instance.contentSelf.childCount; i++)
        {
            Destroy(GameManager.Instance.contentSelf.GetChild(GameManager.Instance.contentSelf.childCount - i - 1).gameObject);
        }
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
        btnBRANCH2.gameObject.SetActive(true);
        btnBRANCH3.gameObject.SetActive(true);
        btnBRANCH1.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[0].name;
        btnBRANCH1.transform.GetComponent<Branch>().index = 0;
        btnBRANCH2.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[1].name;
        btnBRANCH2.transform.GetComponent<Branch>().index = 1;
        btnBRANCH3.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[2].name;
        btnBRANCH3.transform.GetComponent<Branch>().index = 2;
        btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnclickNHOM2()
    {
        indexScene = 2;
        for (int i = 0; i < GameManager.Instance.contentSelf.childCount; i++)
        {
            Destroy(GameManager.Instance.contentSelf.GetChild(GameManager.Instance.contentSelf.childCount - i - 1).gameObject);
        }
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
        btnBRANCH2.gameObject.SetActive(true);
        btnBRANCH3.gameObject.SetActive(true);
        btnBRANCH1.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[3].name;
        btnBRANCH1.transform.GetComponent<Branch>().index = 3;
        btnBRANCH2.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[4].name;
        btnBRANCH2.transform.GetComponent<Branch>().index = 4;
        btnBRANCH3.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[5].name;
        btnBRANCH3.transform.GetComponent<Branch>().index = 5;
        btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnclickNHOM3()
    {
        indexScene = 2;
        for (int i = 0; i < GameManager.Instance.contentSelf.childCount; i++)
        {
            Destroy(GameManager.Instance.contentSelf.GetChild(GameManager.Instance.contentSelf.childCount - i - 1).gameObject);
        }
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
        btnBRANCH2.gameObject.SetActive(false);
        btnBRANCH3.gameObject.SetActive(false);
        btnBRANCH1.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[6].name;
        btnBRANCH1.transform.GetComponent<Branch>().index = 6;
        btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        panelMODEPLAY.SetActive(true);
    }

    public void setSRD(int SRD)
    {
        GameManager.Instance.SRD = SRD;
        if (SRD == 1)
        {
            btnEasy.transform.GetChild(1).gameObject.SetActive(true);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 2)
        {
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(true);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 3)
        {
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(true);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 4)
        {
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ModeGame(int mode)
    {
        panelMODEPLAY.SetActive(false);
        menuGame.SetActive(false);
        GameManager.Instance.SRD = 1;
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.modePlay = mode;
        GameManager.Instance.main.bitCoin = 10 * GameManager.Instance.SRD;
        GameManager.Instance.main.coin = 50000 * GameManager.Instance.SRD;
        OnclickWORD();
    }

    public void Continue()
    {
        DataPlayer.Instance.LoadDataPlayer();
        panelMODEPLAY.SetActive(false);
        menuGame.SetActive(false);
        isPlay = true;
        OnclickWORD();
    }

    public void RePlay()
    {
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = 10 * GameManager.Instance.SRD;
        GameManager.Instance.main.coin = 50000 * GameManager.Instance.SRD;
        OnclickWORD();
    }

    public void Update()
    {
        txtGold.text = SubstringNumberGoldReplay(GameManager.Instance.main.coin);
        txtBitCoin.text = SubstringNumberGoldReplay(GameManager.Instance.main.bitCoin);
    }

    public string SubstringNumberGoldReplay(long number)
    {
        string smoney = string.Format("{0:n0}", number);
        if (smoney.Length == 5)
        {

            if (smoney[2] == '0')
            {
                smoney = smoney.Substring(0, smoney.Length - 4);
                smoney = smoney + " K";
            }
            else
            {
                smoney = smoney.Substring(0, smoney.Length - 2);
                smoney = smoney + " K";
            }

        }
        else if (smoney.Length > 5 && smoney.Length < 9)
        {
            smoney = smoney.Substring(0, smoney.Length - 4);
            smoney = smoney + " K";
        }
        else if (smoney.Length == 9)
        {
            smoney = smoney.Substring(0, smoney.Length - 6);
            smoney = smoney + " M";
        }
        else if (smoney.Length > 9 && smoney.Length < 13)
        {
            smoney = smoney.Substring(0, smoney.Length - 8);
            smoney = smoney + " M";
        }
        else if (smoney.Length == 13)
        {
            smoney = smoney.Substring(0, smoney.Length - 10);
            smoney = smoney + " B";
        }
        else if (smoney.Length > 13 && smoney.Length < 17)
        {
            smoney = smoney.Substring(0, smoney.Length - 12);
            smoney = smoney + " B";
        }
        else if (smoney.Length == 17)
        {
            smoney = smoney.Substring(0, smoney.Length - 14);
            smoney = smoney + " KB";
        }
        else if (smoney.Length > 17)
        {
            smoney = smoney.Substring(0, smoney.Length - 16);
            smoney = smoney + " KB";
        }
        return smoney;
    }
}
