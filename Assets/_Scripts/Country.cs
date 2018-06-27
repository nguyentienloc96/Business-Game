using System;
using UnityEngine;
using UnityEngine.UI;

public struct BASIC
{
    public int postage;
    public DateTime startDate;
    public DateTime dayOfInvestment;
    public bool isReadyed;
}

public struct PROCEDUREPROCESS
{
    public BASIC rdb;   //R&D
    public BASIC f;     //Factory/workshop
    public BASIC o;     //Outsource
    public BASIC b;     //Buying other factory/workshop
    public BASIC s;     //Service

    public void SetRANDD(float SP0) // Setup it with the day
    {
        if (rdb.postage > 10000)
        {
            if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
            {
                if (!rdb.isReadyed)
                {
                    SP0 += 1000000;
                    rdb.isReadyed = true;
                }
            }
        }
    }

    public void SetFactoryWorkshop(float SP0) // Setup it with the Month
    {
        if (f.postage > 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays > 365)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays - 365) % 30 == 0)
            {
                SP0 += (f.postage - 100000) * 0.08f - 50 * (((long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays - 365) / 30 - 1);
            }
        }
    }

    public void Outsource(float SP0)
    {
        if (!o.isReadyed)
        {
            SP0 += o.postage * 0.7f;
            o.isReadyed = true;
        }
    }

    public void BuyingSotherFactoryWorkshop(float SP0)
    {
        if (f.postage > 200000 && !f.isReadyed)
        {
            SP0 += (b.postage - 100000) * 0.05f;
            f.isReadyed = true;
        }
    }


}

public struct ADS
{
    public BASIC t;     //Traditional ads
    public BASIC s;     //Social network ads
    public BASIC w;     //Website & affiliate

    public void TraditionalAds(float MKT0)
    {
        if (!t.isReadyed)
        {
            MKT0 += t.postage;
            t.isReadyed = true;
        }
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - t.dayOfInvestment)).TotalDays >= 30 && UnityEngine.Random.Range(0f, 1f) <= 0.1f)
        {
            MKT0 += t.postage * 0.1f;
            t.dayOfInvestment = GameManager.Instance.dateGame;
        }
    }

    public void SocialNetworkAds(float MKT0)
    {
        if (!s.isReadyed)
        {
            MKT0 += s.postage;
            s.isReadyed = true;
        }
    }

    public void WebsiteAffiliate(float MKT0)
    {
        if ((long)((TimeSpan)(GameManager.Instance.dateGame - w.startDate)).TotalDays <= 365 * 2)
        {
            MKT0 += w.postage * 0.1f;
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
    public int L = 0;
    [Range(50, 200)]
    public float Mn;
    public float I;

    private float I0 = 0f;
    private float SP0 = 20f;
    private float MKT0 = 15f;
    private float MAKRET0 = 15f;
    private float L0 = 10f;
    private float KH0 = 10f;
    private float NS0 = 20f;
    private float ST0 = 10f;

    public void Interest()
    {
        I0 = (SP0 + MKT0 + MAKRET0 + L0 + KH0 + NS0 + ST0);
        I = L * GameConfig.Instance.Ipc + I0 * Mn;
    }

    public void OnClickItemWord()
    {
        UIManager.Instance.PieChart1.SetActive(true);
        Word.Instance.lsCountry[Word.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        Word.Instance.idSelectWord = ID;
        if (L == 0)
        {
            UIManager.Instance.POSITIONSELECT.SetActive(true);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
            UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
            UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(() => OnClickNo());
            UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
            UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnClickYes());
        }
    }

    public void OnClickNo()
    {
        L = 0;
        UIManager.Instance.POSITIONSELECT.SetActive(false);
    }

    public void OnClickYes()
    {
        if (L > 0)
        {
            if (GameManager.Instance.main.gold >= L)
            {

                GameManager.Instance.main.gold -= L;
                GameManager.Instance.main.lsCoutryReady.Add(Word.Instance.lsCountry[Word.Instance.idSelectWord]);
                UIManager.Instance.POSITIONSELECT.SetActive(false);
            }
            else
            {
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban khong du so tien dau tu";
            }
        }
        else
        {
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban chua chon so tien dau tu";
        }

    }
}
