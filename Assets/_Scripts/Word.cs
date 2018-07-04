using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{

    public static Word Instance;
    public int idSelectWord = 0;

    [Header("Word")]
    public GameObject itemWord;
    public Transform contentWord;

    [Header("SliderWord")]
    public Slider seltTraining;
    public Text seltCoin;
    public List<Country> lsCountry = new List<Country>();
    public long LSlider = 10000;
    public long minSlider = 10000;
    public long maxSlider = 50000;


    [Header("SliderSelf")]
    public int indexPSelf;
    public int indexSelf;
    public Slider seltTraining2;
    public Text seltCoin2;
    public Text txtLabel;
    public Text txtInfo;
    public GameObject sliderEvole;
    public GameObject panelInfo;
    public long LSlider2 = 10000;
    public long minSlider2 = 10000;
    public long maxSlider2 = 50000;

    [Header("ItemSelf")]
    public List<Transform> lsItemSelf = new List<Transform>();

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < DataUpdate.Instance.lstData_NameCountry.Count; i++)
        {
            Transform item = Instantiate(itemWord, contentWord).transform;
            item.name = DataUpdate.Instance.lstData_NameCountry[i].name;
            
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = string.Format("{0:000}", i);
            item.GetChild(1).GetComponent<Text>().text = DataUpdate.Instance.lstData_NameCountry[i].name;
            lsCountry.Add(item.GetComponent<Country>());
            item.GetComponent<Country>().ID = i;
            item.GetComponent<Country>().GDP = DataUpdate.Instance.lstData_NameCountry[i].gdp;
            item.GetComponent<Country>().nameCountry = DataUpdate.Instance.lstData_NameCountry[i].name;
            item.GetComponent<Country>().Mn = UnityEngine.Random.Range(50, 200);
        }
    }

    public void SliderWord()
    {
        long index = (maxSlider - minSlider) / 1000;
        LSlider = minSlider + (int)(seltTraining.value * index) *1000;
        seltCoin.text = LSlider.ToString();
    }

    public void SliderSelf()
    {
        long index = (maxSlider2 - minSlider2) / 1000;
        LSlider2 = minSlider2 + (int)(seltTraining2.value * index) * 1000;
        seltCoin2.text = LSlider2.ToString();
    }

    public void Evole()
    {
        if (indexPSelf == 0)
        {
            if(indexSelf == 0)
            {
                lsCountry[idSelectWord].pROCEDUREPROCESS.rdb.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].pROCEDUREPROCESS.rdb.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].SetRAndD();

            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].pROCEDUREPROCESS.f.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].pROCEDUREPROCESS.f.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].SetFactoryWorkshop();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].pROCEDUREPROCESS.o.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].pROCEDUREPROCESS.o.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].SetOutsource();
            }
            else if (indexSelf == 3)
            {
                lsCountry[idSelectWord].pROCEDUREPROCESS.b.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].pROCEDUREPROCESS.b.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].SetBuyingSotherFactoryWorkshop();
            }
            else if (indexSelf == 4)
            {
                lsCountry[idSelectWord].pROCEDUREPROCESS.s.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].pROCEDUREPROCESS.s.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].SetService();
            }
        }
        else if (indexPSelf == 1)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].aDS.t.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].aDS.t.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setTraditionalAds();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].aDS.s.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].aDS.s.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setSocialNetworkAds();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].aDS.w.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].aDS.w.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setWebsiteAffiliate();
            }
            
        }
        else if (indexPSelf == 2)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].sPREADING.ubr.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sPREADING.ubr.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setUserBehaviourResearch();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].sPREADING.pal.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sPREADING.pal.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setPolicyAndLaw();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].sPREADING.cr.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sPREADING.cr.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setCompetitorResearch();
            }
            else if (indexSelf == 3)
            {
                lsCountry[idSelectWord].sPREADING.bc.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sPREADING.bc.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setBuyACompetitor();
            }
            else if (indexSelf == 4)
            {
                lsCountry[idSelectWord].sPREADING.ler.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sPREADING.ler.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setLocalEconomyResearch();
            }

        }
        else if(indexPSelf == 3)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].tRANSPORTCHAIN.ta.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].tRANSPORTCHAIN.ta.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setTransportAgent();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].tRANSPORTCHAIN.ws.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].tRANSPORTCHAIN.ws.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setWarehouseStorage();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].tRANSPORTCHAIN.vs.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].tRANSPORTCHAIN.vs.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setVehicles();
            }
           
        }
        else if(indexPSelf == 4)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].sALESCHAIN.bas.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sALESCHAIN.bas.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setBuildAShop();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].sALESCHAIN.lwas.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sALESCHAIN.lwas.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setLinkWithAgenciesShop();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].sALESCHAIN.os.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sALESCHAIN.os.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setOnlineShop();
            }
            else if (indexSelf == 3)
            {
                lsCountry[idSelectWord].sALESCHAIN.sc.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].sALESCHAIN.sc.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setSalesCulture();
            }
           
        }
        else if(indexPSelf == 5)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].rISKMANAGEMENT.mc.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].rISKMANAGEMENT.mc.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setMediaCrisis();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].rISKMANAGEMENT.lc.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].rISKMANAGEMENT.lc.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setLawCrisis();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].rISKMANAGEMENT.ec.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].rISKMANAGEMENT.ec.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setEmployeeCrisis();
            }
           
        }
        else if(indexPSelf == 6)
        {
            if (indexSelf == 0)
            {
                lsCountry[idSelectWord].eMPLOYEES.st1.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.st1.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setSelfTraining();
            }
            else if (indexSelf == 1)
            {
                lsCountry[idSelectWord].eMPLOYEES.st2.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.st2.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setSelfTraining2();
            }
            else if (indexSelf == 2)
            {
                lsCountry[idSelectWord].eMPLOYEES.hr.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.hr.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setHumanResource();
            }
            else if (indexSelf == 3)
            {
                lsCountry[idSelectWord].eMPLOYEES.ph.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.ph.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setPeopleHiring();
            }
            else if (indexSelf == 4)
            {
                lsCountry[idSelectWord].eMPLOYEES.cc.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.cc.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setCompanyCulture();
            }
            else if (indexSelf == 5)
            {
                lsCountry[idSelectWord].eMPLOYEES.ae.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.ae.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setAnnuallyEvent();
            }
            else if (indexSelf == 6)
            {
                lsCountry[idSelectWord].eMPLOYEES.ic.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.ic.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setInternalCompanyFund();
            }
            else if (indexSelf == 7)
            {
                lsCountry[idSelectWord].eMPLOYEES.et.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.et.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setEmployeeTraining();
            }
            else if (indexSelf == 8)
            {
                lsCountry[idSelectWord].eMPLOYEES.cf.initialInvestmentMoney = LSlider2;
                lsCountry[idSelectWord].eMPLOYEES.cf.startDate = GameManager.Instance.dateGame;
                lsCountry[idSelectWord].setCurriculumForEmployeeTraining();
            }
            lsCountry[idSelectWord].PullData();
        }
        GameManager.Instance.main.coin -= LSlider2;
        panelInfo.SetActive(true);
        panelInfo.transform.GetChild(0).GetComponent<Text>().text = "Ban dau tu thanh cong " + LSlider2.ToString() + "$";
    }

    public void OnEnableWord(bool isWord)
    {
        StopAllCoroutines();
        StartCoroutine(IEOnEnableWord(isWord));
    }

    IEnumerator IEOnEnableWord(bool isWord)
    {
        if (isWord)
        {
            for (int i = 0; i < lsCountry.Count; i++)
            {
                lsCountry[i].gameObject.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            lsCountry[0].transform.GetChild(3).gameObject.SetActive(true);
            lsCountry[0].OnClickItemWord();
            idSelectWord = 0;
            for (int i = 0; i < lsCountry.Count; i++)
            { 
                lsCountry[i].gameObject.SetActive(true);
                if (i <= 8)
                    yield return new WaitForSeconds(0.15f);
            }
        }
        else
        {
            for (int i = 0; i < lsCountry.Count; i++)
            {
                lsCountry[i].gameObject.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            if (GameManager.Instance.main.lsCoutryReady.Count > 0)
            {
                
                GameManager.Instance.main.lsCoutryReady[0].transform.GetChild(3).gameObject.SetActive(true);
                idSelectWord = GameManager.Instance.main.lsCoutryReady[0].ID;

                if (UIManager.Instance.indexScene == 2)
                {
                    UIManager.Instance.LabelCountry.text = string.Format("{0:000}", idSelectWord);
                }
            }
            for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
            {
                GameManager.Instance.main.lsCoutryReady[i].gameObject.SetActive(true);
                if (i <= 8)
                    yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
