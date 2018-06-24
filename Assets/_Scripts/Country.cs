using System;
using UnityEngine;

public struct BASIC
{
    public int postage;
    public DateTime startDate;
    public DateTime dayOfInvestment;
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
                SP0 += 1000000;
            }
        }
    }

    public void SetFactoryWorkshop(float SP0) // Setup it with the Month
    {
        if (f.postage > 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame - f.startDate)).TotalDays >= 365)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - f.dayOfInvestment)).TotalDays >= 30)
            {
                SP0 += (f.postage - 100000) * 0.08f;
                f.postage -= 50;
                f.dayOfInvestment = GameManager.Instance.dateGame;
            }
        }
    }

    public void Outsource(float SP0)
    {
        SP0 += o.postage * 0.7f;
    }

    public void BuyingSotherFactoryWorkshop(float SP0)
    {
        if (f.postage > 200000)
        {
            SP0 += (b.postage - 100000) * 0.05f;
        }
    }

}

public struct ADS
{
    public float t;     //Traditional ads
    public float s;     //Social network ads
    public float w;     //Website & affiliate
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

    public float A;
    [Range(50, 200)]
    public float Mn;
    public float I;

    private const float ipc = 0.001f;
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
        I = A * ipc + I0 * Mn;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
