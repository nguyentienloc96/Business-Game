using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : MonoBehaviour
{

    public int ID;
    public string nameCountry;
    public long L = 0;
    public long LDT = 0;

    public float I0 = 0f;
    public float SP = 0f;
    public float MKT = 0f;
    public float MARKET = 0f;
    public float LC = 0f;
    public float KH = 0f;
    public float NS = 0f;
    public float ST = 0f;

    public float I0DT = 0f;
    public float SPDT = 0f;
    public float MKTDT = 0f;
    public float MARKETDT = 0f;
    public float LCDT = 0f;
    public float KHDT = 0f;
    public float NSDT = 0f;
    public float STDT = 0f;

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];

    public void PushWord()
    {
        ResetInfo();
        for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
        {
            L += GameManager.Instance.main.lsCoutryReady[i].L;
            LDT += GameManager.Instance.main.lsCoutryReady[i].LDT;

            I0 += GameManager.Instance.main.lsCoutryReady[i].I0;
            SP += GameManager.Instance.main.lsCoutryReady[i].SP;
            MKT += GameManager.Instance.main.lsCoutryReady[i].MKT;
            MARKET += GameManager.Instance.main.lsCoutryReady[i].MARKET;
            LC += GameManager.Instance.main.lsCoutryReady[i].LC;
            KH += GameManager.Instance.main.lsCoutryReady[i].KH;
            NS += GameManager.Instance.main.lsCoutryReady[i].NS;
            ST += GameManager.Instance.main.lsCoutryReady[i].ST;

            I0DT += GameManager.Instance.main.lsCoutryReady[i].I0DT;
            SPDT += GameManager.Instance.main.lsCoutryReady[i].SPDT;
            MKTDT += GameManager.Instance.main.lsCoutryReady[i].MKTDT;
            MARKETDT += GameManager.Instance.main.lsCoutryReady[i].MARKETDT;
            LCDT += GameManager.Instance.main.lsCoutryReady[i].LCDT;
            KHDT += GameManager.Instance.main.lsCoutryReady[i].KHDT;
            NSDT += GameManager.Instance.main.lsCoutryReady[i].NSDT;
            STDT += GameManager.Instance.main.lsCoutryReady[i].STDT;

            for (int j = 0; j < 12; j++)
            {
                for(int k = 0; k < 7; k++)
                {
                    dataColChartMain[j].valueCol[k] 
                        += GameManager.Instance.main.lsCoutryReady[i].dataColChartMain[j].valueCol[k];
                }
            }

        }
    }

    void ResetInfo()
    {
        L = 0;
        LDT = 0;

        I0 = 0f;
        SP = 0f;
        MKT = 0f;
        MARKET = 0f;
        LC = 0f;
        KH = 0f;
        NS = 0f;
        ST = 0f;

        I0DT = 0f;
        SPDT = 0f;
        MKTDT = 0f;
        MARKETDT = 0f;
        LCDT = 0f;
        KHDT = 0f;
        NSDT = 0f;
        STDT = 0f;

        for (int j = 0; j < 12; j++)
        {
            for (int k = 0; k < 7; k++)
            {
                dataColChartMain[j].valueCol[k] = 0;
            }
        }
    }


}
