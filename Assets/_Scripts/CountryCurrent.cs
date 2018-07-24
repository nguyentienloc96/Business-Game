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

    public double I0 = 0f;
    public double SP = 0f;
    public double MKT = 0f;
    public double MAKRET = 0f;
    public double LC = 0f;
    public double KH = 0f;
    public double NS = 0f;
    public double ST = 0f;

    public double I0DT = 0f;
    public double SPDT = 0f;
    public double MKTDT = 0f;
    public double MAKRETDT = 0f;
    public double LCDT = 0f;
    public double KHDT = 0f;
    public double NSDT = 0f;
    public double STDT = 0f;

    public STBigBranch[] bigBranch = new STBigBranch[7];

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];
}
