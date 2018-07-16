using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMain : MonoBehaviour
{

    public int ID;
    public string nameCountry;
    public long L = 0;
    public long LDT = 0;

    public float I0 = 0f;
    public float SP0 = 0f;
    public float MKT0 = 0f;
    public float MARKET0 = 0f;
    public float L0 = 0f;
    public float KH0 = 0f;
    public float NS0 = 0f;
    public float ST0 = 0f;

    public float I0DT = 0f;
    public float SP0DT = 0f;
    public float MKT0DT = 0f;
    public float MARKET0DT = 0f;
    public float L0DT = 0f;
    public float KH0DT = 0f;
    public float NS0DT = 0f;
    public float ST0DT = 0f;

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];

    public void PushWord()
    {
        L = 0;
        LDT = 0;

        I0 = 0f;
        SP0 = 0f;
        MKT0 = 0f;
        MARKET0 = 0f;
        L0 = 0f;
        KH0 = 0f;
        NS0 = 0f;
        ST0 = 0f;

        I0DT = 0f;
        SP0DT = 0f;
        MKT0DT = 0f;
        MARKET0DT = 0f;
        L0DT = 0f;
        KH0DT = 0f;
        NS0DT = 0f;
        ST0DT = 0f;

        for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
        {
            L += GameManager.Instance.main.lsCoutryReady[i].L;
            LDT += GameManager.Instance.main.lsCoutryReady[i].LDT;

            I0 += GameManager.Instance.main.lsCoutryReady[i].I0;
            SP0 += GameManager.Instance.main.lsCoutryReady[i].SP0;
            MKT0 += GameManager.Instance.main.lsCoutryReady[i].MKT0;
            MARKET0 += GameManager.Instance.main.lsCoutryReady[i].MARKET0;
            L0 += GameManager.Instance.main.lsCoutryReady[i].L0;
            KH0 += GameManager.Instance.main.lsCoutryReady[i].KH0;
            NS0 += GameManager.Instance.main.lsCoutryReady[i].NS0;
            ST0 += GameManager.Instance.main.lsCoutryReady[i].ST0;

            I0DT += GameManager.Instance.main.lsCoutryReady[i].I0DT;
            SP0DT += GameManager.Instance.main.lsCoutryReady[i].SP0DT;
            MKT0DT += GameManager.Instance.main.lsCoutryReady[i].MKT0DT;
            MARKET0DT += GameManager.Instance.main.lsCoutryReady[i].MARKET0DT;
            L0DT += GameManager.Instance.main.lsCoutryReady[i].L0DT;
            KH0DT += GameManager.Instance.main.lsCoutryReady[i].KH0DT;
            NS0DT += GameManager.Instance.main.lsCoutryReady[i].NS0DT;
            ST0DT += GameManager.Instance.main.lsCoutryReady[i].ST0DT;
        }
    }

  
}
