using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BASIC
{
    public string name;
    public long initialInvestmentMoney;
    public long investmentMoneyLater;
    public DateTime startDate;
    public bool isRunning;
}


public struct PROCEDUREPROCESS
{
    public BASIC rdb;   //R&D
    public BASIC f;     //Factory/workshop
    public BASIC o;     //Outsource
    public BASIC b;     //Buying other factory/workshop
    public BASIC s;     //Service
}

public struct ADS
{
    public BASIC t;     //Traditional ads
    public BASIC s;     //Social network ads
    public BASIC w;     //Website & affiliate
}

public struct SPREADING
{
    public BASIC ubr;   //Local Economy research
    public BASIC pal;   //Local Economy research
    public BASIC cr;    //Local Economy research
    public BASIC bc;    //Local Economy research
    public BASIC ler;   //Local Economy research
}

public struct TRANSPORTCHAIN
{
    public BASIC ta;   //Transport agent
    public BASIC ws;     //Warehouse Storage
    public BASIC vs;    //Vehicles: self transport
}

public struct SALESCHAIN
{
    public BASIC bas;     //Build a shop
    public BASIC lwas;     //Link with agencies shop
    public BASIC os;     //Online shop
    public BASIC sc;    //Sales culture 
}

public struct RISKMANAGEMENT
{
    public BASIC mc;     //Media crisis
    public BASIC lc;     //Law crisis
    public BASIC ec;     //Employee crisis
}

public struct EMPLOYEES
{
    public BASIC st1;   //Self training 1
    public BASIC st2;   //Self training 2
    public BASIC hr;    //Human resource
    public BASIC ph;    //People hiring
    public BASIC cc;    //Company culture i : 15
    public BASIC ae;    //Annually event i : 20
    public BASIC ic;    //Internal company fund i : 10
    public BASIC et;    //Employee training
    public BASIC cf;    //Curriculum for employee training
}

public class Country : MonoBehaviour
{
    public int ID;
    public string nameCountry;
    public long GDP;
    public long L = 0;
    public long LDT = 0;
    [Range(50, 200)]
    public float Mn;

    public float I0 = 0f;
    public float SP0 = 0f;
    public float MKT0 = 0f;
    public float MAKRET0 = 0f;
    public float L0 = 0f;
    public float KH0 = 0f;
    public float NS0 = 0f;
    public float ST0 = 0f;

    public float I0DT = 0f;
    public float SP0DT = 0f;
    public float MKT0DT = 0f;
    public float MAKRET0DT = 0f;
    public float L0DT = 0f;
    public float KH0DT = 0f;
    public float NS0DT = 0f;
    public float ST0DT = 0f;

    public PROCEDUREPROCESS pROCEDUREPROCESS;
    public ADS aDS;
    public SPREADING sPREADING;
    public TRANSPORTCHAIN tRANSPORTCHAIN;
    public SALESCHAIN sALESCHAIN;
    public RISKMANAGEMENT rISKMANAGEMENT;
    public EMPLOYEES eMPLOYEES;

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];

    public void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            dataColChartMain[i].nameCol = (i + 1).ToString();
            dataColChartMain[i].valueCol = new int[7];
            dataColChartCompetitors[i].nameCol = (i + 1).ToString();
            dataColChartCompetitors[i].valueCol = new int[7];
        }
    }

    public void PullData()
    {
        int month = GameManager.Instance.dateGame.Month - 1;
        dataColChartMain[month].valueCol[0] = (int)(SP0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[1] = (int)(MKT0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[2] = (int)(MAKRET0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[3] = (int)(L0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[4] = (int)(KH0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[5] = (int)(NS0 * Mn * 0.01f);
        dataColChartMain[month].valueCol[6] = (int)(ST0 * Mn * 0.01f);

        dataColChartCompetitors[month].valueCol[0] = (int)(SP0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[1] = (int)(MKT0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[2] = (int)(MAKRET0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[3] = (int)(L0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[4] = (int)(KH0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[5] = (int)(NS0DT * Mn * 0.01f);
        dataColChartCompetitors[month].valueCol[6] = (int)(ST0DT * Mn * 0.01f);

    }


    public void Interest()
    {
        I0 = (SP0 + MKT0 + MAKRET0 + L0 + KH0 + NS0 + ST0);
        I0DT = (SP0DT + MKT0DT + MAKRET0DT + L0DT + KH0DT + NS0DT + ST0DT);
        GameManager.Instance.main.coin += (int)(L * GameConfig.Instance.Ipc / 100) + (int)(I0 * Mn / 100);
        GameManager.Instance.competitors.coin += (int)(LDT * GameConfig.Instance.Ipc / 100) + (int)(I0DT * Mn / 100);
    }

    public void OnClickItemWord()
    {
        Word.Instance.lsCountry[Word.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        Word.Instance.idSelectWord = ID;
        if (UIManager.Instance.indexScene == 0)
        {
            UIManager.Instance.txtCodeCountry.text = "Ma Nuoc : " + Mn.ToString() + "%";
            UIManager.Instance.txtGDPCountry.text = "GDP : " + ConvertNumber.convertNumber_DatDz(GDP) + "$";
            UIManager.Instance.PieChart1.SetActive(true);
            Word.Instance.maxSlider = (long)(GameManager.Instance.main.coin * 0.95f);
            if (Word.Instance.maxSlider > 10000 && L == 0)
            {
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnClickYes());
            }
            else
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            Word.Instance.seltTraining.value = 0;
            Word.Instance.LSlider = 10000;
            Word.Instance.seltCoin.text = Word.Instance.LSlider.ToString();
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
        }
        else if (UIManager.Instance.indexScene == 1)
        { 
            if (I0 != 0)
            {
                Word.Instance.maxSlider2 = (long)(GameManager.Instance.main.coin * 0.95f);
                UIManager.Instance.PieChart2.SetActive(true);
                UIManager.Instance.PieChart2.GetComponent<PieChart>().dataPei[0].valuePei = ((float)(I0) / (float)(I0 + I0DT));
                UIManager.Instance.PieChart2.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(I0DT) / (float)(I0 + I0DT));
                UIManager.Instance.PieChart2.GetComponent<PieChart>().LoadData();
                UIManager.Instance.COLCHART.transform
                .GetChild(0).GetChild(0).GetChild(0).GetComponent<ColumnChart>().dataCol = dataColChartMain;
                UIManager.Instance.COLCHART.transform
                    .GetChild(0).GetChild(0).GetChild(0).GetComponent<ColumnChart>().loadData();

                UIManager.Instance.COLCHART.transform
                    .GetChild(1).GetChild(0).GetChild(0).GetComponent<ColumnChart>().dataCol = dataColChartCompetitors;
                UIManager.Instance.COLCHART.transform
                    .GetChild(1).GetChild(0).GetChild(0).GetComponent<ColumnChart>().loadData();
            }
        }
        else if (UIManager.Instance.indexScene == 2)
        {
            UIManager.Instance.LabelCountry.text = string.Format("{0:000}", ID);
        }
    }

    public void OnClickNo()
    {
        UIManager.Instance.POSITIONSELECT.SetActive(false);
    }

    public void OnClickYes()
    {
        if (GameManager.Instance.main.coin >= Word.Instance.LSlider)
        {

            GameManager.Instance.main.coin -= Word.Instance.LSlider;
            L = Word.Instance.LSlider;
            LDT = (long)(UnityEngine.Random.Range(10000, (GDP - L)) / 1000) * 1000;
            GameManager.Instance.main.lsCoutryReady.Add(Word.Instance.lsCountry[Word.Instance.idSelectWord]);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban dau tu thanh cong " + L.ToString() + "$ vào " + nameCountry;
            UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L -LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
        }
        else
        {
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban khong du so tien dau tu";
        }
    }

    #region PROCEDUREPROCESS
    public void SetRAndD()
    {
        if (pROCEDUREPROCESS.rdb.initialInvestmentMoney > 10000)
        {
            if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
            {
                SP0 += 1000000;
                if(UnityEngine.Random.Range(0f,1f) <= 0.2f * GameManager.Instance.SRD)
                    SP0DT += 1000000;
                pROCEDUREPROCESS.rdb.initialInvestmentMoney = 0;
            }
        }
    }

    public void SetFactoryWorkshop() // loop
    {
        if (pROCEDUREPROCESS.f.initialInvestmentMoney > 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.f.startDate)).TotalDays > 365)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.f.startDate)).TotalDays - 365) % 30 == 0)
            {
                float money = (pROCEDUREPROCESS.f.investmentMoneyLater - 100000) * 0.08f - 50 * (((long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.f.startDate)).TotalDays - 365) / 30 - 1);
                if (money <= 0)
                {
                    pROCEDUREPROCESS.f.investmentMoneyLater = 0;
                }
                else
                {
                    SP0 += money;
                }
            }
        }
    }

    public void SetOutsource()
    {
        SP0 += pROCEDUREPROCESS.o.initialInvestmentMoney * 0.7f;
        SP0DT += pROCEDUREPROCESS.o.initialInvestmentMoney * UnityEngine.Random.Range(0.25f,1.75f);
        pROCEDUREPROCESS.o.initialInvestmentMoney = 0;            
    }

    public void SetBuyingSotherFactoryWorkshop() // loop
    {
        if (pROCEDUREPROCESS.b.initialInvestmentMoney > 200000)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.b.startDate)).TotalDays) % 30 == 0)
            {
                float money = (pROCEDUREPROCESS.b.investmentMoneyLater - 100000) * 0.08f - 50 * (((long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.b.startDate)).TotalDays) / 30 - 1);
                if (money <= 0)
                {
                    pROCEDUREPROCESS.b.investmentMoneyLater = 0;
                    pROCEDUREPROCESS.b.isRunning = false;
                }
                else
                {
                    SP0 += money;
                }
            }
        }
    }

    public void SetService()
    {
        if (((long)((TimeSpan)(GameManager.Instance.dateGame - pROCEDUREPROCESS.f.startDate)).TotalDays - 365) > 0)
        {
            SP0 += (int)(pROCEDUREPROCESS.s.initialInvestmentMoney / 1000) * 50f;
        }

        SP0 += (int)(pROCEDUREPROCESS.s.initialInvestmentMoney / 1000) * 100f;

        pROCEDUREPROCESS.s.initialInvestmentMoney = 0;
    }

    #endregion

    #region ADS
    public void setTraditionalAds()
    {
        if (!aDS.t.isRunning)
        {
            MKT0 += aDS.t.initialInvestmentMoney;
            aDS.t.isRunning = true;
        }
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - aDS.t.startDate)).TotalDays == 30 && UnityEngine.Random.Range(0f, 1f) <= 0.1f)
        {
            MKT0 += aDS.t.initialInvestmentMoney * 0.1f;
            aDS.t.initialInvestmentMoney = 0;
            aDS.t.isRunning = false;
        }
    }

    public void setSocialNetworkAds()
    {
        MKT0 += aDS.s.initialInvestmentMoney;
        aDS.s.initialInvestmentMoney = 0;
    }

    public void setWebsiteAffiliate()
    {
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - aDS.w.startDate)).TotalDays <= 365 * 2)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - aDS.w.startDate)).TotalDays) % 30 == 0)
            {
                MKT0 += aDS.w.initialInvestmentMoney * 0.1f;
            }
        }
        else
        {
            aDS.w.initialInvestmentMoney = 0;
            aDS.w.isRunning = false;
        }
    }
    #endregion

    #region SPREADING

    public void setUserBehaviourResearch()
    {

    }

    public void setPolicyAndLaw()
    {

    }

    public void setCompetitorResearch()
    {

    }

    public void setBuyACompetitor()
    {

    }

    public void setLocalEconomyResearch()
    {

    }

    #endregion

    #region TRANSPORTCHAIN
    public void setTransportAgent()
    {
        L0 += tRANSPORTCHAIN.ta.initialInvestmentMoney * GameConfig.Instance.TC_tax;
        tRANSPORTCHAIN.ta.initialInvestmentMoney = 0;
    }

    public void setWarehouseStorage()
    {
        if (tRANSPORTCHAIN.ws.initialInvestmentMoney < 100000)
        {
            L0 += tRANSPORTCHAIN.ws.initialInvestmentMoney * GameConfig.Instance.TC_wx;
        }
        else
        {
            L0 += tRANSPORTCHAIN.ws.initialInvestmentMoney * (GameConfig.Instance.TC_wx + 0.3f);
        }
        tRANSPORTCHAIN.ws.initialInvestmentMoney = 0;
    }

    public void setVehicles()
    {
        if (tRANSPORTCHAIN.vs.initialInvestmentMoney < 100000)
        {
            L0 += tRANSPORTCHAIN.vs.initialInvestmentMoney;
        }
        else
        {
            L0 += tRANSPORTCHAIN.vs.initialInvestmentMoney * 0.7f;
        }
        tRANSPORTCHAIN.vs.initialInvestmentMoney = 0;
    }
    #endregion

    #region SALESCHAIN
    public void setBuildAShop()
    {
        if (sALESCHAIN.bas.initialInvestmentMoney >= 10000 &&
            (long)((TimeSpan)(GameManager.Instance.dateGame - sALESCHAIN.bas.startDate)).TotalDays <= 365 * 3)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - sALESCHAIN.bas.startDate)).TotalDays) % 30 == 0)
            {
                L0 += sALESCHAIN.bas.initialInvestmentMoney * GameConfig.Instance.SC_bx;
            }
        }
        else
        {
            sALESCHAIN.bas.initialInvestmentMoney = 0;
            sALESCHAIN.bas.isRunning = false;
        }
    }

    public void setLinkWithAgenciesShop()
    {
        L0 += sALESCHAIN.lwas.initialInvestmentMoney * GameConfig.Instance.SC_ax;
        sALESCHAIN.lwas.initialInvestmentMoney = 0;
    }

    public void setOnlineShop()
    {
        if (sALESCHAIN.os.initialInvestmentMoney >= 10000 &&
            (long)((TimeSpan)(GameManager.Instance.dateGame - sALESCHAIN.os.startDate)).TotalDays <= 365 * 3)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - sALESCHAIN.os.startDate)).TotalDays) % 30 == 0)
            {
                L0 += sALESCHAIN.os.initialInvestmentMoney * GameConfig.Instance.SC_bx;
            }
        }
        else
        {
            sALESCHAIN.os.initialInvestmentMoney = 0;
            sALESCHAIN.os.isRunning = false;
        }
    }

    public void setSalesCulture()
    {

        L0 += (int)(sALESCHAIN.sc.initialInvestmentMoney / 1000) * 0.05f *
            (sALESCHAIN.sc.initialInvestmentMoney * GameConfig.Instance.SC_bx);
        L0 += (int)(sALESCHAIN.sc.initialInvestmentMoney / 1000) * 0.05f *
            (sALESCHAIN.sc.initialInvestmentMoney * GameConfig.Instance.SC_bx);

        sALESCHAIN.sc.initialInvestmentMoney = 0;
    }
    #endregion

    #region RISKMANAGEMENT
    public void setMediaCrisis()
    {
        KH0 += rISKMANAGEMENT.mc.initialInvestmentMoney;
        rISKMANAGEMENT.mc.initialInvestmentMoney = 0;
    }

    public void setLawCrisis()
    {

    }

    public void setEmployeeCrisis()
    {

    }
    #endregion

    #region EMPLOYEES

    public void setSelfTraining()
    {

    }
    public void setSelfTraining2()
    {

    }

    public void setHumanResource()
    {

    }

    public void setPeopleHiring()
    {

    }
    public void setCompanyCulture()
    {

    }
    public void setAnnuallyEvent()
    {

    }
    public void setInternalCompanyFund()
    {

    }
    public void setEmployeeTraining()
    {

    }
    public void setCurriculumForEmployeeTraining()
    {

    }
    #endregion
}
