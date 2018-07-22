using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

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
    public GameObject panelInfoCapital;
    public GameObject panelFindACoFounder;
    public bool isLoadItemBranch = false;

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
    public GameObject info5Years;

    [Header("Continue")]
    public Button btnContinue;

    [Header("ConvertDollars")]
    public GameObject panelDollars;
    public GameObject panelBitCoin;

    [Header("New and Setting")]
    public GameObject panelNew;
    public GameObject panelSetting;

    [Header("Loading")]
    public GameObject panelLoading;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
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
        WorldManager.Instance.OnEnableWord(true);
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
        ResetBranch();
        isLoadItemBranch = false;
    }

    public void OnclickTHONGSO()
    {
        AudioManager.Instance.Play("Click");
        if (indexScene == 0)
        {
            WorldManager.Instance.OnEnableWord(false);
        }
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
        panelNew.SetActive(false);
        panelSetting.SetActive(false);
        ResetBranch();
        if (GameManager.Instance.main.lsCoutryReady.Count > 0)
            GameManager.Instance.main.lsCoutryReady[0].OnClickCountry();
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            Destroy(mainTutorial);
            panelTutorial.SetActive(true);
            handTutorial.SetActive(false);
            infoTutorial.SetActive(true);
            WorldManager.Instance.panelInfo.SetActive(false);
        }
        isLoadItemBranch = false;
        Ads.Instance.RequestAd();
        Ads.Instance.ShowInterstitialAd();
    }

    public void OnclickNHOM1()
    {
        AudioManager.Instance.Play("Click");
        if(indexScene == 0)
        {
            WorldManager.Instance.OnEnableWord(false);
        }
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
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            Turorial(btnBRANCH2.gameObject, new Vector3(-33f, 308f, 0), Vector3.zero);
        }

        Ads.Instance.RequestAd();
        Ads.Instance.ShowInterstitialAd();
    }

    public void OnclickNHOM2()
    {
        AudioManager.Instance.Play("Click");
        if (indexScene == 0)
        {
            WorldManager.Instance.OnEnableWord(false);
        }
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

        Ads.Instance.RequestAd();
        Ads.Instance.ShowInterstitialAd();

    }

    public void OnclickNHOM3()
    {
        AudioManager.Instance.Play("Click");
        if (indexScene == 0)
        {
            WorldManager.Instance.OnEnableWord(false);
        }
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

        Ads.Instance.RequestAd();
        Ads.Instance.ShowInterstitialAd();
    }

    public void PlayGameOnclick()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("GamePlay");
        PlayerPrefs.SetFloat("X4TimeGame", 4f);
        GameManager.Instance.DeltaTimeGame = 4f;
        GameManager.Instance.isTutorial = false;
        ResetGame();
        btnX4.image.sprite = spX1;
        menuGame.SetActive(false);
        Loading(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = GameConfig.Instance.bitcoinStartGame;
        GameManager.Instance.main.dollars = GameConfig.Instance.dollarStartGame;
        OnclickWORD();
        if (GameManager.Instance.modePlay == 1)
        {
            info5Years.SetActive(true);
            info5Years.transform.GetChild(0).GetComponent<Text>().text = GameConfig.Instance.stringStart;
            Invoke("HidePanelInfo", 5f);

        }
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            Turorial(WorldManager.Instance.lsCountry[1].gameObject, new Vector3(-795f, 217f, 0), Vector3.zero);
        }
    }

    public void TutorialOnclick()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("GamePlay");
        PlayerPrefs.SetFloat("X4TimeGame", 4f);
        GameManager.Instance.isTutorial = true;
        ResetGame();
        btnX4.image.sprite = spX1;
        menuGame.SetActive(false);
        Loading(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = GameConfig.Instance.bitcoinStartGame;
        GameManager.Instance.main.dollars = GameConfig.Instance.dollarStartGame;
        OnclickWORD();
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            Turorial(WorldManager.Instance.lsCountry[1].gameObject, new Vector3(-795f, 217f, 0), Vector3.zero);
        }
    }

    public void Turorial(GameObject main, Vector3 posHand, Vector3 angleHnad)
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

    public void setSRDOnclick(int SRD)
    {
        AudioManager.Instance.Play("Click");

        if (SRD == 1)
        {
            GameManager.Instance.SRD = GameConfig.Instance.Srd_easy;
            Debug.Log(GameConfig.Instance.Srd_easy);
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

    public void ModeGameOnclick(int mode)
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

    public void ContinueOnclick()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("GamePlay");
        GameManager.Instance.isTutorial = false;
        DataPlayer.Instance.LoadDataPlayer();
        GameManager.Instance.SetDate();
        Loading(false);
        isPlay = true;
        OnclickWORD();
    }

    public void RePlayOnclick()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.Stop("OverWin");
        AudioManager.Instance.Play("GamePlay");
        PlayerPrefs.SetFloat("X4TimeGame", 4f);
        ResetGame();
        btnX4.image.sprite = spX1;
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
        Loading(false);
        isPlay = true;
        GameManager.Instance.LoadDate();
        GameManager.Instance.main.bitCoin = 10 * GameManager.Instance.SRD;
        GameManager.Instance.main.dollars = 50000 * GameManager.Instance.SRD;
        OnclickWORD();
        if(GameManager.Instance.modePlay == 1)
        {
            info5Years.SetActive(true);
            info5Years.transform.GetChild(0).GetComponent<Text>().text = GameConfig.Instance.stringStart;
            Invoke("HidePanelInfo", 5f);
        }
    }

    public void BackToMenuOnclick()
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
        if (indexScene == 2)
        {
            btnBRANCH1.interactable = !isLoadItemBranch;
            btnBRANCH2.interactable = !isLoadItemBranch;
            btnBRANCH3.interactable = !isLoadItemBranch;
        }
        btnNHOM1.interactable = !isLoadItemBranch;
        btnNHOM2.interactable = !isLoadItemBranch;
        btnNHOM3.interactable = !isLoadItemBranch;
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

        WorldManager.Instance.lsItemSelf.Clear();
    }

    public void HideEror()
    {
        AudioManager.Instance.Play("Click");

        panelEror.SetActive(false);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            Turorial(btnNHOM1.gameObject, new Vector3(-219f, -429f, 0), new Vector3(0, 0, 180f));
        }
    }

    public void DoneTutorial()
    {
        AudioManager.Instance.Play("Click");
        infoTutorial.SetActive(false);
        handTutorial.SetActive(true);
        panelTutorial.SetActive(false);
        if (!GameManager.Instance.isTutorial)
        {
            DataPlayer.Instance.SaveDataPlayer();
            PlayerPrefs.SetInt("isDoneTutorial", 1);
        }
        else
        {
            ResetGame();
            if (WorldManager.Instance.idSelectWord != -1)
                WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            for (int i = 0; i < WorldManager.Instance.lsCountry.Count; i++)
            {               
                WorldManager.Instance.lsCountry[i].gameObject.SetActive(true);
            }
            BackToMenuOnclick();
            GameManager.Instance.isTutorial = false;
        }
    }

    public void BtnShare()
    {
        AudioManager.Instance.Play("Click");
        ShareManager.Instance.ShareScreenshotWithText("Become an Unicorn");
    }

    public void BtnRate()
    {
        AudioManager.Instance.Play("Click");
#if UNITY_ANDROID
        if (GameConfig.Instance.linkGame_android != null)
        {
            Application.OpenURL(GameConfig.Instance.linkGame_android);
        }
#elif UNITY_IOS
        if (GameConfig.Instance.linkGame_ios != null)
        {
            Application.OpenURL(GameConfig.Instance.linkGame_ios);
        }
#endif
    }

    public void BtnShowNew()
    {
        AudioManager.Instance.Play("Click");
        if (panelNew.activeSelf)
        {
            panelNew.SetActive(false);
        }
        else
        {
            panelNew.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                if (i < WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord].lstNew.Count)
                {
                    panelNew.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    panelNew.transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<Text>().text
                        = GameManager.Instance.main.lsCoutryReady[WorldManager.Instance.idSelectWord].lstNew[i];
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
        AudioManager.Instance.Play("Click");
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
        AudioManager.Instance.Play("Click");
        DataPlayer.Instance.SaveDataPlayer();
        BackToMenuOnclick();
    }

    public void BtnRestore()
    {
        AudioManager.Instance.Play("Click");
        ResetGame();
        PlayGameOnclick();
        panelSetting.SetActive(false);
    }

    public void ExitGame()
    {
        AudioManager.Instance.Play("Click");
        Application.Quit();
    }

    public void AddMoney(Slider slider)
    {
        if (slider.value < 1)
            slider.value += 0.1f;
    }

    public void AbstractMoney(Slider slider)
    {
        if (slider.value > 0)
            slider.value -= 0.1f;
    }

    IEnumerator IELoading(bool isLoad)
    {
        panelLoading.SetActive(true);
        yield return new WaitForSeconds(1f);
        panelLoading.SetActive(false);
        menuGame.SetActive(false);
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
    }

    public void Loading(bool isLoad)
    {
        StartCoroutine(IELoading(isLoad));
    }

    public void ResetGame()
    {
        for(int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
        {
            GameManager.Instance.main.lsCoutryReady[i].L = 0;
            GameManager.Instance.main.lsCoutryReady[i].LDT = 0;
            GameManager.Instance.main.lsCoutryReady[i].lstNew.Clear();
        }
        GameManager.Instance.main.lsCoutryReady.Clear();
    }

    public void HidePanelInfo()
    {
        info5Years.SetActive(false);
    }
}
