using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
    public GameObject panelEror;

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
    public GameObject panelBuyCompetitor;
    public GameObject panelBankLoan;

    [Header("SRD")]
    public GameObject btnEasy;
    public GameObject btnMedium;
    public GameObject btnHard;
    public GameObject btnCrazy;

    [Header("ModePlay")]
    public GameObject btnMode1;
    public GameObject btnMode2;
    public bool isPlay;

    [Header("GameOver")]
    public GameObject panelGameOver;
    public GameObject panelWin;

    [Header("ButtomX4")]
    public Button btnX4;
    public Sprite spX4;
    public Sprite spX1;

    [Header("Tutorial")]
    public GameObject panelTutorial;
    public GameObject handTutorial;
    public GameObject mainTutorial;
    public GameObject infoTutorial;

    [Header("Continue")]
    public Button btnContinue;

    [Header("ConvertDollars")]
    public GameObject panelDollars;
    public GameObject panelBitCoin;

    [Header("New and Setting")]
    public GameObject panelNew;
    public GameObject panelSetting;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    void Start()
    {
        setSRD(1);
        ModeGame(0);
    }

    public void OnclickWORD()
    {
        AudioManager.Instance.Play("Click");
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
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
        ResetBranch();
    }

    public void OnclickTHONGSO()
    {
        AudioManager.Instance.Play("Click");
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
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
        ResetBranch();
        if (GameManager.Instance.main.lsCoutryReady.Count > 0)
            GameManager.Instance.main.lsCoutryReady[0].OnClickItemWord();
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            Destroy(mainTutorial);
            panelTutorial.SetActive(true);
            handTutorial.SetActive(false);
            infoTutorial.SetActive(true);
        }
    }

    public void OnclickNHOM1()
    {
        AudioManager.Instance.Play("Click");

        indexScene = 2;
        ResetBranch();
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
        btnBRANCH1.transform.GetComponent<Branch>().LoadDataBranch();
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            Turorial(btnBRANCH2.gameObject, new Vector3(-33f, 308f, 0), Vector3.zero);
        }

    }

    public void OnclickNHOM2()
    {
        AudioManager.Instance.Play("Click");

        indexScene = 2;
        ResetBranch();
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
        btnBRANCH1.transform.GetComponent<Branch>().LoadDataBranch();
        panelNew.SetActive(false);
        panelSetting.SetActive(false);

    }

    public void OnclickNHOM3()
    {
        AudioManager.Instance.Play("Click");

        indexScene = 2;
        ResetBranch();
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
        btnBRANCH3.gameObject.SetActive(false);
        btnBRANCH1.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[6].name;
        btnBRANCH1.transform.GetComponent<Branch>().index = 6;
        btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH2.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.arreconomicSegments[7].name;
        btnBRANCH2.transform.GetComponent<Branch>().index = 7;
        btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        btnBRANCH1.transform.GetComponent<Branch>().LoadDataBranch();
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
    }

    public void PlayGame()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("GamePlay");
        menuGame.SetActive(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = GameConfig.Instance.bitcoinStartGame;
        GameManager.Instance.main.dollars = GameConfig.Instance.dollarStartGame;
        OnclickWORD();
        if(PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            Turorial(Word.Instance.lsCountry[1].gameObject,new Vector3(-795f,217f,0),Vector3.zero);
        }
           
    }

    public void Turorial(GameObject main,Vector3 posHand,Vector3 angleHnad)
    {
        Destroy(mainTutorial);
        panelTutorial.SetActive(true);
        Vector3 pos = main.transform.position;
        mainTutorial = Instantiate(main, panelTutorial.transform);
        mainTutorial.SetActive(true);
        mainTutorial.transform.SetAsFirstSibling();
        mainTutorial.transform.position = pos;
        handTutorial.transform.localPosition = posHand;
        handTutorial.transform.localEulerAngles = angleHnad;
    }

    public void setSRD(int SRD)
    {
        AudioManager.Instance.Play("Click");

        if (SRD == 1)
        {
            GameManager.Instance.SRD = GameConfig.Instance.Srd_easy;
            btnEasy.transform.GetChild(1).gameObject.SetActive(true);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 2)
        {
            GameManager.Instance.SRD = GameConfig.Instance.Srd_medium;
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(true);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 3)
        {
            GameManager.Instance.SRD = GameConfig.Instance.Srd_hard;
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(true);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (SRD == 4)
        {
            GameManager.Instance.SRD = GameConfig.Instance.Srd_crazy;
            btnEasy.transform.GetChild(1).gameObject.SetActive(false);
            btnMedium.transform.GetChild(1).gameObject.SetActive(false);
            btnHard.transform.GetChild(1).gameObject.SetActive(false);
            btnCrazy.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ModeGame(int mode)
    {
        AudioManager.Instance.Play("Click");

        GameManager.Instance.modePlay = mode;
        if (mode == 0)
        {
            btnMode1.transform.GetChild(1).gameObject.SetActive(true);
            btnMode2.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (mode == 1)
        {
            btnMode1.transform.GetChild(1).gameObject.SetActive(false);
            btnMode2.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Continue()
    {

        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("GamePlay");
        DataPlayer.Instance.LoadDataPlayer();
        menuGame.SetActive(false);
        isPlay = true;
        OnclickWORD();
    }

    public void RePlay()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("OverWin");
        AudioManager.Instance.Play("GamePlay");
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = 10 * GameManager.Instance.SRD;
        GameManager.Instance.main.dollars = 50000 * GameManager.Instance.SRD;
        OnclickWORD();
    }

    public void BackToMenu()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("OverWin");
        AudioManager.Instance.Stop("GamePlay");
        AudioManager.Instance.Play("Menu");
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
        menuGame.SetActive(true);
        isPlay = false;
    }

    public void Update()
    {
        txtGold.text = ConvertNumber.convertNumber_DatDz(GameManager.Instance.main.dollars);
        txtBitCoin.text = ConvertNumber.convertNumber_DatDz(GameManager.Instance.main.bitCoin);
    }

    public void ResetBranch()
    {
        if (GameManager.Instance.contentSelf.childCount > 0)
        {
            for (int i = GameManager.Instance.contentSelf.childCount - 1; i >= 0; i--)
            {
                Destroy(GameManager.Instance.contentSelf.GetChild(i).gameObject);
            }
        }

        Word.Instance.lsItemSelf.Clear();
    }

    public void HideEror()
    {
        AudioManager.Instance.Play("Click");

        panelEror.SetActive(false);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            Turorial(btnNHOM1.gameObject, new Vector3(-219f, -429f, 0), new Vector3(0, 0, 180f));
        }
    }

    public void DoneTutorial()
    {
        AudioManager.Instance.Play("Click");

        panelTutorial.SetActive(false);
        DataPlayer.Instance.SaveDataPlayer();
        PlayerPrefs.SetInt("isDoneTutorial", 1);
    }

    public void BtnShare()
    {
        AudioManager.Instance.Play("Click");
        ShareManager.Instance.ShareScreenshotWithText("Become an Unicorn");
    }

    public void BtnRate()
    {
        AudioManager.Instance.Play("Click");
        if (GameConfig.Instance.linkGame != null)
        {
            Application.OpenURL(GameConfig.Instance.linkGame);
        }
    }

    public void BtnShowNew()
    {
        if (panelNew.activeSelf)
        {
            panelNew.SetActive(false);
        }
        else
        {
            panelNew.SetActive(true);
            for(int i = 0; i < 10; i++)
            {
                if (i < Word.Instance.lsCountry[Word.Instance.idSelectWord].lstNew.Count)
                {
                    panelNew.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    panelNew.transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<Text>().text
                        = GameManager.Instance.main.lsCoutryReady[Word.Instance.idSelectWord].lstNew[i];
                }
                else
                {
                    panelNew.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    public void BtnShowSetting()
    {
        if (panelSetting.activeSelf)
        {
            panelSetting.SetActive(false);
        }
        else
        {
            panelSetting.SetActive(true);
        }
    }

    public void BtnSaveAndExit()
    {
        DataPlayer.Instance.SaveDataPlayer();
    }
}
