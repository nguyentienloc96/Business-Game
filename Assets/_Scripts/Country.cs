using System;
using UnityEngine;
using UnityEngine.UI;

public struct BASIC
{
    public string name;
    public int initialInvestmentMoney;
    public int investmentMoneyLater;
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

    void SetRAndD(float SP0) // Setup it with the day
    {
        if (rdb.initialInvestmentMoney > 10000)
        {
            if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
            {
                SP0 += 1000000;
                rdb.initialInvestmentMoney = 0;
            }
        }
    }

    void SetFactoryWorkshop(float SP0) // Setup it with the Month
    {
        if (f.initialInvestmentMoney > 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays > 365)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays - 365) % 30 == 0)
            {
                float money = (f.investmentMoneyLater - 100000) * 0.08f - 50 * (((long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays - 365) / 30 - 1);
                if (money <= 0)
                {
                    f.investmentMoneyLater = 0;
                }
                else
                {
                    SP0 += money;
                }
            }
        }
    }

    void SetOutsource(float SP0)
    {
        SP0 += o.initialInvestmentMoney * 0.7f;
        o.initialInvestmentMoney = 0;
    }

    void SetBuyingSotherFactoryWorkshop(float SP0)
    {
        if (b.initialInvestmentMoney > 200000)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - b.startDate)).TotalDays) % 30 == 0)
            {
                float money = (b.investmentMoneyLater - 100000) * 0.08f - 50 * (((long)((TimeSpan)(GameManager.Instance.dateGame - b.startDate)).TotalDays) / 30 - 1);
                if (money <= 0)
                {
                    b.investmentMoneyLater = 0;
                    b.isRunning = false;
                }
                else
                {
                    SP0 += money;
                }
            }
        }
    }

    void SetService(float SP0)
    {
        if(((long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays - 365) / 30 > 1)
        {
            SP0 += (int)(s.initialInvestmentMoney / 1000) * 50f;
        }

        if (((long)((TimeSpan)(GameManager.Instance.dateGame - b.startDate)).TotalDays) / 30 > 1)
        {
            SP0 += (int)(s.initialInvestmentMoney / 1000) * 100f;
        }
        s.initialInvestmentMoney = 0;
    }

    public void SetLoop(float SP0)
    {
        SetFactoryWorkshop(SP0);
        SetBuyingSotherFactoryWorkshop(SP0);
    }
}

public struct ADS
{
    public BASIC t;     //Traditional ads
    public BASIC s;     //Social network ads
    public BASIC w;     //Website & affiliate

    public void TraditionalAds(float MKT0)
    {
        if (!t.isRunning)
        {
            MKT0 += t.initialInvestmentMoney;
            t.isRunning = true;
        }
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - t.startDate)).TotalDays >= 30 && UnityEngine.Random.Range(0f, 1f) <= 0.1f)
        {
            MKT0 += t.initialInvestmentMoney * 0.1f;
            t.initialInvestmentMoney = 0;
            t.isRunning = false;
        }
    }

    public void SocialNetworkAds(float MKT0)
    {
        MKT0 += s.initialInvestmentMoney;
        s.initialInvestmentMoney = 0;
    }

    public void WebsiteAffiliate(float MKT0)
    {
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - w.startDate)).TotalDays <= 365 * 2)
        {
            MKT0 += w.initialInvestmentMoney * 0.1f;
        }
        else
        {
            w.initialInvestmentMoney = 0;
            w.isRunning = false;
        }
    }
}

public struct SPREADING
{
    public float le;    //Local Economy research
}

public struct TRANSPORTCHAIN
{
    public float tax;   //Transport agent
    public float w;     //Warehouse Storage
    public float vs;    //Vehicles: self transport
}

public struct SALESCHAIN
{
    public float b;     //Build a shop
    public float a;     //Link with agencies shop
    public float o;     //Online shop
    public float sc;    //Sales culture
}

public struct RISKMANAGEMENT
{
    public float m;     //Media crisis
    public float l;     //Law crisis
    public float e;     //Employee crisis
}

public struct EMPLOYEES
{
    public float st1;   //Self training 1
    public float st2;   //Self training 2
    public float hr;    //Human resource
    public float ph;    //People hiring
    public float cc;    //Company culture i : 15
    public float ae;    //Annually event i : 20
    public float ic;    //Internal company fund i : 10
    public float et;    //Employee training
    public float cf;    //Curriculum for employee training
}

public class Country : MonoBehaviour
{
    public int ID;
    public string nameCountry;
    public long GDP;
    public long L = 0;
    [Range(50, 200)]
    public float Mn;

    private float I0 = 0f;
    private float SP0 = 0f;
    private float MKT0 = 0f;
    private float MAKRET0 = 0f;
    private float L0 = 0f;
    private float KH0 = 0f;
    private float NS0 = 0f;
    private float ST0 = 0f;

    public PROCEDUREPROCESS pROCEDUREPROCESS;
    public ADS aDS;
    public SPREADING sPREADING;
    public TRANSPORTCHAIN tRANSPORTCHAIN;
    public SALESCHAIN sALESCHAIN;
    public RISKMANAGEMENT rISKMANAGEMENT;
    public EMPLOYEES eMPLOYEES;

    public void Interest()
    {
        I0 = (SP0 + MKT0 + MAKRET0 + L0 + KH0 + NS0 + ST0);
        GameManager.Instance.main.coin += (int)(L * GameConfig.Instance.Ipc / 100) + (int)(I0 * Mn);
    }

    public void OnClickItemWord()
    {
        if (UIManager.Instance.indexScene == 0)
        {
            UIManager.Instance.PieChart1.SetActive(true);
        }
        else if (UIManager.Instance.indexScene == 1)
        {
            UIManager.Instance.PieChart2.SetActive(true);
        }
        else if (UIManager.Instance.indexScene == 2)
        {
            UIManager.Instance.LabelCountry.text = nameCountry;
        }
        Word.Instance.lsCountry[Word.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        Word.Instance.idSelectWord = ID;
        UIManager.Instance.POSITIONSELECT.SetActive(true);
        UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
        UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
        UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnClickYes());
        UIManager.Instance.txtCodeCountry.text = "Ma Nuoc : " + Mn.ToString() + "%";
        Word.Instance.seltTraining.value = 0;
        L = 1000;
    }

    public void OnClickNo()
    {
        UIManager.Instance.POSITIONSELECT.SetActive(false);
    }

    public void OnClickYes()
    {
        if (L > 0)
        {
            if (GameManager.Instance.main.coin >= L)
            {

                GameManager.Instance.main.coin -= L;
                GameManager.Instance.main.lsCoutryReady.Add(Word.Instance.lsCountry[Word.Instance.idSelectWord]);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban dau tu thanh cong " + L.ToString() + "$ vào "+nameCountry;
            }
            else
            {
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban khong du so tien dau tu";
            }
        }

    }
}
