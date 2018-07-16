using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CountryCurrent {

    public int ID;
    public string nameCountry;
    public long GDP;
    public long L = 0;
    public long LDT = 0;
    public float Mn;
    public List<string> lstNew = new List<string>();

    public float HSP;
    public float HMKT;
    public float HMARKET;
    public float HL;
    public float HKH;
    public float HNS;
    public float HST;

    public float I0 = 0f;
    public float SP = 0f;
    public float MKT = 0f;
    public float MAKRET = 0f;
    public float LC = 0f;
    public float KH = 0f;
    public float NS = 0f;
    public float ST = 0f;

    public float I0DT = 0f;
    public float SPDT = 0f;
    public float MKTDT = 0f;
    public float MAKRETDT = 0f;
    public float LCDT = 0f;
    public float KHDT = 0f;
    public float NSDT = 0f;
    public float STDT = 0f;

    public STBigBranch[] bigBranch = new STBigBranch[7];

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];
}
