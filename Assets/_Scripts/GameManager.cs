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
    public world world_main;

    [Header("EconomicSegment")]
    public EconomicSegment[] arreconomicSegments;

    [Header("SelfTraining")]
    public GameObject itemSelf;
    public Transform contentSelf;

    private float DeltaTimeGame = 4;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (!PlayerPrefs.HasKey("isDoneTutorial"))
        {
            PlayerPrefs.SetInt("isDoneTutorial", 0);
        }

    }

    void Start()
    {

        if (PlayerPrefs.HasKey("X4TimeGame"))
        {
            if (PlayerPrefs.GetFloat("X4TimeGame") != 4f)
            {
                DeltaTimeGame = 0.25f;
                UIManager.Instance.btnX4.image.sprite = UIManager.Instance.spX4;
            }
            else
            {
                DeltaTimeGame = 4f;
                UIManager.Instance.btnX4.image.sprite = UIManager.Instance.spX1;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("X4TimeGame", 4f);
            UIManager.Instance.btnX4.image.sprite = UIManager.Instance.spX1;
        }


        if (!PlayerPrefs.HasKey("isData"))
        {
            PlayerPrefs.SetInt("isData", 0);
            UIManager.Instance.btnContinue.interactable = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("isData") == 0)
            {
                UIManager.Instance.btnContinue.interactable = false;
            }
            else
            {
                UIManager.Instance.btnContinue.interactable = true;
            }
        }
    }

    public void LoadDate()
    {
        dateGame = DateTime.Now;
        dateStartPlay = dateGame;
        SetDate();
    }

    public void SetDate()
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

    int checkMonth = 0;
    float sumTime = 0;
    void Update()
    {
        if (UIManager.Instance.isPlay)
        {
            time += Time.deltaTime;
            if (time >= DeltaTimeGame)
            {
                sumTime += DeltaTimeGame;
                int month = dateGame.Month;
                int year = dateGame.Year;
                dateGame = dateGame.AddDays(1f);
                SetDate();
                UpdateDataUser(main);
                if (dateGame.Month == 1)
                {
                    for (int i = 0; i < main.lsCoutryReady.Count; i++)
                    {
                        main.lsCoutryReady[i].ResetDataCol();
                    }
                }
                if (dateGame.Month != month)
                {
                    world_main.PullData();
                    for (int i = 0; i < main.lsCoutryReady.Count; i++)
                    {
                        main.lsCoutryReady[i].PullData();
                    }
                    checkMonth++;
                    if (checkMonth >= GameConfig.Instance.dTime)
                    {
                        NewsGame();
                        checkMonth = 0;
                    }
                }
                if (modePlay == 1)
                {
                    if (year - dateStartPlay.Year >= 5)
                    {
                        Time.timeScale = 0;
                        UIManager.Instance.isPlay = false;
                        if (main.dollars > 1000000000)
                        {
                            AudioManager.Instance.Stop("GamePlay");
                            AudioManager.Instance.Play("OverWin");

                            UIManager.Instance.panelWin.SetActive(true);
                            UIManager.Instance.isPlay = false;
                        }
                        else
                        {
                            AudioManager.Instance.Stop("GamePlay");
                            AudioManager.Instance.Play("OverWin");

                            UIManager.Instance.panelGameOver.SetActive(true);
                            UIManager.Instance.isPlay = false;
                        }
                    }
                }
                if (sumTime >= 8f)
                {
                    DataPlayer.Instance.SaveDataPlayer();
                    sumTime = 0;
                }
                PlayerPrefs.SetInt("isData", 1);
                UpdateUI();
                time = 0;
            }
        }

    }

    void UpdateDataUser(BusinessMan man)
    {
        for (int i = 0; i < main.lsCoutryReady.Count; i++)
        {
            main.lsCoutryReady[i].Interest();
            main.lsCoutryReady[i].UpdateDay();
        }
    }

    void UpdateUI()
    {
        WorldManager.Instance.maxSlider = (long)(main.dollars * 0.95f);
        if (contentSelf.childCount > 0)
        {
            if (WorldManager.Instance.lsItemSelf.Count > WorldManager.Instance.indexSelf)
            {
                if (WorldManager.Instance.lsItemSelf[WorldManager.Instance.indexSelf].gameObject.activeInHierarchy)
                    WorldManager.Instance.lsItemSelf[WorldManager.Instance.indexSelf].GetComponent<ItemSelf>().UpdateShow();
            }
        }
    }
    
    public void HidePanelInfo()
    {       
        WorldManager.Instance.panelInfo.SetActive(false);
    }

    public void NewsGame()
    {
        int ID = UnityEngine.Random.Range(0, main.lsCoutryReady.Count);
        News.Instance.GetNews();
        WorldManager.Instance.panelInfo.SetActive(true);
        string info = main.lsCoutryReady[ID].nameCountry + "\n"
            + News.Instance.NewChoosed.content + +News.Instance.valueNews + "%";
        WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = info;
        main.lsCoutryReady[ID].lstNew.Add(info);
        if (main.lsCoutryReady[ID].lstNew.Count > 10)
            main.lsCoutryReady[ID].lstNew.RemoveAt(0);
        News.Instance.SetResultNew(ID);
        main.lsCoutryReady[ID].PullData();
        Invoke("HidePanelInfo", 5f);
    }

    public void X4TimeGame()
    {
        if (PlayerPrefs.GetFloat("X4TimeGame") != 4f)
        {
            DeltaTimeGame = 4f;
            UIManager.Instance.btnX4.image.sprite = UIManager.Instance.spX1;
            PlayerPrefs.SetFloat("X4TimeGame", 4f);
        }
        else
        {
            DeltaTimeGame = 0.25f;
            UIManager.Instance.btnX4.image.sprite = UIManager.Instance.spX4;
            PlayerPrefs.SetFloat("X4TimeGame", 0.25f);
        }
    }

    public void ConvertBitcoinToDollars(int bitcoin)
    {
        if (main.bitCoin >= bitcoin)
        {
            main.bitCoin -= bitcoin;
            main.dollars += bitcoin * 10000;
            WorldManager.Instance.panelInfo.SetActive(true);
            WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "You've successfully changed "
                + ConvertNumber.convertNumber_DatDz(bitcoin) + "btc into " + ConvertNumber.convertNumber_DatDz(bitcoin * 10000) + "$ ";
        }
        else
        {
            WorldManager.Instance.panelInfo.SetActive(true);
            WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "You don't have enough bitcoins ";
        }
        UIManager.Instance.panelDollars.SetActive(false);
        Invoke("HidePanelInfo", 2f);
    }

    public void AddDollars()
    {
        Ads.Instance.ShowAdsUnity();
        //main.dollars += dollars;
        //WorldManager.Instance.panelInfo.SetActive(true);
        //WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "You just received " + ConvertNumber.convertNumber_DatDz(GameConfig.Instance.dollarVideoUnityAds) + "$ ";
        //UIManager.Instance.panelDollars.SetActive(false);
        //Invoke("HidePanelInfo", 5f);
    }
}
