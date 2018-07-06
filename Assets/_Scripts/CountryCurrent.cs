using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryCurrent : MonoBehaviour {

    public int ID;
    public string nameCountry;
    public long GDP;
    public long L = 0;
    public long LDT = 0;
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

    public List<string[]>[] bigBranch = new List<string[]>[7];

    public List<int[]>  dataColChartMain = new List<int[]> ();
    public List<int[]>  dataColChartCompetitors = new List<int[]> ();
}
