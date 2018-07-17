﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct STBranch
{
    public string nameSmallBranch;
    public long moneyDTBD;
    public long moneyDTS;
    public string investmentDayBD;
    public string investmentDayS;
    public bool isRunning;
}

[System.Serializable]
public struct STBigBranch
{
    public string nameBigBranch;
    public STBranch[] smallBranch;
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

    public STBigBranch[] bigBranch = new STBigBranch[8];

    public DataColChart[] dataColChartMain = new DataColChart[12];
    public DataColChart[] dataColChartCompetitors = new DataColChart[12];

    private float convertPercent = 0.01f;

    public void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            dataColChartMain[i].nameCol = (i + 1).ToString();
            dataColChartMain[i].valueCol = new int[7];
            dataColChartCompetitors[i].nameCol = (i + 1).ToString();
            dataColChartCompetitors[i].valueCol = new int[7];
        }

        for (int i = 0; i < bigBranch.Length; i++)
        {
            if (i == 0)
            {
                bigBranch[i].nameBigBranch = "Procedure process";
                bigBranch[i].smallBranch = new STBranch[5];
                bigBranch[i].smallBranch[0].nameSmallBranch = "R&D";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Factory/workshop";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Outsource";
                bigBranch[i].smallBranch[3].nameSmallBranch = "Buying other factory/workshop";
                bigBranch[i].smallBranch[4].nameSmallBranch = "Service";
            }
            if (i == 1)
            {
                bigBranch[i].nameBigBranch = "Ads";
                bigBranch[i].smallBranch = new STBranch[3];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Traditional ads";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Social network ads";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Website & affiliate";
            }
            if (i == 2)
            {
                bigBranch[i].nameBigBranch = "Spreading";
                bigBranch[i].smallBranch = new STBranch[5];
                bigBranch[i].smallBranch[0].nameSmallBranch = "User behaviour research";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Policy and law";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Competitor research";
                bigBranch[i].smallBranch[3].nameSmallBranch = "Buy a competitor";
                bigBranch[i].smallBranch[4].nameSmallBranch = "Local Economy research";
            }
            if (i == 3)
            {
                bigBranch[i].nameBigBranch = "Transport chain";
                bigBranch[i].smallBranch = new STBranch[3];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Transport agent";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Warehouse Storage";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Vehicles: self transport";
            }
            if (i == 4)
            {
                bigBranch[i].nameBigBranch = "Sales chain";
                bigBranch[i].smallBranch = new STBranch[4];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Build a shop ";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Link with agencies shop";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Online shop";
                bigBranch[i].smallBranch[3].nameSmallBranch = "Sales culture";
            }
            if (i == 5)
            {
                bigBranch[i].nameBigBranch = "Risk management";
                bigBranch[i].smallBranch = new STBranch[3];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Media crisis";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Law crisis";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Employee crisis";
            }
            if (i == 6)
            {
                bigBranch[i].nameBigBranch = "Employees";
                bigBranch[i].smallBranch = new STBranch[9];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Self training";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Self training 2";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Human resource";
                bigBranch[i].smallBranch[3].nameSmallBranch = "People hiring";
                bigBranch[i].smallBranch[4].nameSmallBranch = "Company culture";
                bigBranch[i].smallBranch[5].nameSmallBranch = "Annually event";
                bigBranch[i].smallBranch[6].nameSmallBranch = "Internal company fund";
                bigBranch[i].smallBranch[7].nameSmallBranch = "Employee training";
                bigBranch[i].smallBranch[8].nameSmallBranch = "Curriculum for employee training";
            }
            if (i == 7)
            {
                bigBranch[i].nameBigBranch = "Funding";
                bigBranch[i].smallBranch = new STBranch[9];
                bigBranch[i].smallBranch[0].nameSmallBranch = "Find a co-founder";
                bigBranch[i].smallBranch[1].nameSmallBranch = "Borrow money";
                bigBranch[i].smallBranch[2].nameSmallBranch = "Capital";
                bigBranch[i].smallBranch[3].nameSmallBranch = "Bank loan";
            }
        }
    }

    public void PullData()
    {
        int month = GameManager.Instance.dateGame.Month - 1;
        dataColChartMain[month].valueCol[0] = (int)(SP);
        dataColChartMain[month].valueCol[1] = (int)(MKT);
        dataColChartMain[month].valueCol[2] = (int)(MARKET);
        dataColChartMain[month].valueCol[3] = (int)(LC);
        dataColChartMain[month].valueCol[4] = (int)(KH);
        dataColChartMain[month].valueCol[5] = (int)(NS);
        dataColChartMain[month].valueCol[6] = (int)(ST);

        dataColChartCompetitors[month].valueCol[0] = (int)(SPDT);
        dataColChartCompetitors[month].valueCol[1] = (int)(MKTDT);
        dataColChartCompetitors[month].valueCol[2] = (int)(MARKETDT);
        dataColChartCompetitors[month].valueCol[3] = (int)(LCDT);
        dataColChartCompetitors[month].valueCol[4] = (int)(KHDT);
        dataColChartCompetitors[month].valueCol[5] = (int)(NSDT);
        dataColChartCompetitors[month].valueCol[6] = (int)(STDT);

    }

    public void Interest()
    {
        List<float> minArray = new List<float>();
        float minSP = SP / GameConfig.Instance.TL_sp;
        minArray.Add(minSP);
        float minMKT = MKT / GameConfig.Instance.TL_mkt;
        minArray.Add(minMKT);
        float minMARKET = MARKET / GameConfig.Instance.TL_maket;
        minArray.Add(minMARKET);
        float minL = LC / GameConfig.Instance.TL_lo;
        minArray.Add(minL);
        float minNS = NS / GameConfig.Instance.TL_ns;
        minArray.Add(minNS);
        float minKH = KH / GameConfig.Instance.TL_kh;
        minArray.Add(minKH);
        float minST = ST / GameConfig.Instance.TL_st;
        minArray.Add(minST);
        float min = minArray[0];

        List<float> minArrayDT = new List<float>();
        float minSPDT = SPDT / GameConfig.Instance.TL_sp;
        minArrayDT.Add(minSPDT);
        float minMKTDT = MKTDT / GameConfig.Instance.TL_mkt;
        minArrayDT.Add(minMKTDT);
        float minMARKETDT = MARKETDT / GameConfig.Instance.TL_maket;
        minArrayDT.Add(minMARKETDT);
        float minLDT = LCDT / GameConfig.Instance.TL_lo;
        minArrayDT.Add(minLDT);
        float minNSDT = NSDT / GameConfig.Instance.TL_ns;
        minArrayDT.Add(minNSDT);
        float minKHDT = KHDT / GameConfig.Instance.TL_kh;
        minArrayDT.Add(minKHDT);
        float minSTDT = STDT / GameConfig.Instance.TL_st;
        minArrayDT.Add(minSTDT);
        float minDT = minArray[0];

        for (int i = 1; i < 7; i++)
        {
            if (minArray[i] < min)
            {
                min = minArray[i];
            }
            if (minArrayDT[i] < minDT)
            {
                minDT = minArrayDT[i];
            }
        }

        I0 = min * 100;
        I0DT = minDT * 100;
        GameManager.Instance.main.dollars += (long)(L * GameConfig.Instance.Ipc / 100) + (long)(I0 * GameConfig.Instance.s * GameManager.Instance.SRD * Mn *convertPercent);
    }

    public void OnClickCountry()
    {
        AudioManager.Instance.Play("Click");
        if (WorldManager.Instance.idSelectWord != -1)
        {
            WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        }
        transform.GetChild(3).gameObject.SetActive(true);
        WorldManager.Instance.idSelectWord = ID;
        if (UIManager.Instance.indexScene == 0)
        {
            UIManager.Instance.txtGDPCountry.text = "GDP : " + ConvertNumber.convertNumber_DatDz(GDP) + " <size=38>$</size>";
            UIManager.Instance.PieChart1.SetActive(true);
            if (WorldManager.Instance.maxSlider > WorldManager.Instance.minSlider && L == 0)
            {
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
            }
            else
            {
                UIManager.Instance.POSITIONSELECT.SetActive(false);
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            }
            WorldManager.Instance.seltTraining.value = 0;
            WorldManager.Instance.LSlider = 10000;
            WorldManager.Instance.seltCoin.text = WorldManager.Instance.LSlider.ToString();
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L - LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
            if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
            {
                UIManager.Instance.Turorial(UIManager.Instance.PieChart1.transform.GetChild(2).GetChild(0).GetChild(2).gameObject, new Vector3(744f, -244f, 0), new Vector3(0, 0, 180f));
            }
        }
        else if (UIManager.Instance.indexScene == 1)
        {
            if (I0 != 0)
            {
                WorldManager.Instance.maxSlider = (long)(GameManager.Instance.main.dollars * 0.95f);
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
            else
            {
                UIManager.Instance.PieChart2.SetActive(true);
                UIManager.Instance.PieChart2.GetComponent<PieChart>().LoadNote();
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
            WorldManager.Instance.sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
            WorldManager.Instance.seltCoin2.text = 10000.ToString();
        }
    }

    public void SetSmallBranch(int indexPSelf, int indexSelf, long moneyDT)
    {

        if (indexPSelf == 0) //PROCEDUREPROCESS
        {
            if (indexSelf == 0)//R&D
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD > 10000)
                {
                    if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
                    {
                        SP += GameConfig.Instance.PP_rdb * HSP * convertPercent;
                        if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
                            SPDT += GameConfig.Instance.PP_rdb * HSP * convertPercent;
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
                    }
                }
            }
            else if (indexSelf == 1)//Factory/workshop
            {
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < GameConfig.Instance.PP_f_Min)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                }
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= GameConfig.Instance.PP_f_Min && (long)((TimeSpan)(GameManager.Instance.dateGame -
                    DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD))).TotalDays < 365)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= GameConfig.Instance.PP_f_Min && (long)((TimeSpan)(GameManager.Instance.dateGame -
                    DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD))).TotalDays >= 365)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayS = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += moneyDT;
                }
            }
            else if (indexSelf == 2)//Outsource
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                SP += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.PP_o * HSP * convertPercent;
                SPDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 1.75f) * HSP * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 3)//Buying other factory/workshop
            {
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < GameConfig.Instance.PP_b_Min)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                }
                else
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayS = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += moneyDT;
                    bigBranch[0].smallBranch[3].isRunning = true;
                }
            }
            else if (indexSelf == 4)//Service
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                if (bigBranch[indexPSelf].smallBranch[1].moneyDTS > 0)
                {
                    if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayS))).TotalDays - 30) > 0)
                    {
                        SP += (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 50f * HSP * convertPercent;
                        SPDT += UnityEngine.Random.Range(100f, (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 50f * 2f) * HSP * convertPercent;
                    }
                }
                if (bigBranch[indexPSelf].smallBranch[1].moneyDTS > 0)
                {
                    if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayS))).TotalDays - 30) > 0)
                    {
                        SP += (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 100f * HSP * convertPercent;
                        SPDT += UnityEngine.Random.Range(100f, (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 100f * 2f) * HSP * convertPercent;

                    }
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 1) //ADS
        {
            if (indexSelf == 0)//Traditional ads
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                if (!bigBranch[indexPSelf].smallBranch[indexSelf].isRunning)
                {
                    MKT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * HMKT * convertPercent;
                    MKTDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f) * HMKT * convertPercent;
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }

            }
            else if (indexSelf == 1)//Social network ads
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                MKT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * HMKT * convertPercent;
                MKTDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f) * HMKT * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)//Website & affiliate
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
            }
        }
        else if (indexPSelf == 2) //SPREADING
        {
            if (indexSelf == 0)//User behaviour research
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS > 0)
                {
                    if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS >= bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD)
                    {
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS -= bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                    }
                    else
                    {
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD -= bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS;
                    }
                }

            }
            else if (indexSelf == 1)//Policy and law
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
            }
            else if (indexSelf == 2)//Competitor research
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD == 0)
                {
                    if (moneyDT >= 10000)
                    {
                        if (UnityEngine.Random.Range(0f, 1f) <= 0.05f)
                        {
                            MKT += 20 * moneyDT * HMKT * convertPercent;
                        }
                    }
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
            }
            else if (indexSelf == 3)//Buy a competitor
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                long size = bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000;
                long T = 10;
                if (T + size > 100)
                {
                    T = 100;
                }
                else
                {
                    T += size;
                }

                if (UnityEngine.Random.Range(0, 100) <= T)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 400;
                }
            }
            else if (indexSelf == 4)//Local Economy research
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= 1000)
                {
                    long size = bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000;
                    bigBranch[2].smallBranch[0].moneyDTS += size * 10000;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 3) //TRANSPORTCHAIN
        {
            if (indexSelf == 0)//Transport agent
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.TC_tax * HL * convertPercent;
                LCDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_tax * 2f) * HL * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)//Warehouse Storage
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 100000)
                {
                    LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * GameConfig.Instance.TC_wx * HL * convertPercent;
                    LCDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_wx * 2f) * HL * convertPercent;
                }
                else
                {
                    LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * (GameConfig.Instance.TC_wx + 0.3f) * HL * convertPercent;
                    LCDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_wx * 3f) * HL * convertPercent;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
            }
            else if (indexSelf == 2)//Vehicles: self transport
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 100000)
                {
                    LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * GameConfig.Instance.TC_vx * HL * convertPercent;
                    LCDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 2f) * HL * convertPercent;

                }
                else
                {
                    LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * (GameConfig.Instance.TC_vx - 0.3f) * HL * convertPercent;
                    LCDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * (GameConfig.Instance.TC_vx - 0.3f) * 2f) * HL * convertPercent;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
            }
        }
        else if (indexPSelf == 4)//SALESCHAIN
        {
            if (indexSelf == 0)//Build a shop
            {
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 10000)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                }
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= 10000)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }
            }
            else if (indexSelf == 1)//Link with agencies shop
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                LC += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.SC_ax * HL * convertPercent;
                LCDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.SC_ax * 2f) * HL * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)//Online shop
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
            }
            else if (indexSelf == 3)//Sales culture
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                bigBranch[4].smallBranch[0].moneyDTBD += (long)((bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 0.05f * bigBranch[4].smallBranch[0].moneyDTBD);
                bigBranch[4].smallBranch[2].moneyDTBD += (long)((bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 0.05f * bigBranch[4].smallBranch[2].moneyDTBD);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 5)//RISKMANAGEMENT
        {
            if (indexSelf == 0)//Media crisis
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                KH += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * HKH * convertPercent;
                KHDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 2f) * HKH * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
            }
            else if (indexSelf == 1)//Law crisis
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                SP += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * HSP * convertPercent;
                SPDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 2f) * HSP * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
            }
            else if (indexSelf == 2)//Employee crisis
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                NS += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * HNS * convertPercent;
                NSDT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 2f) * HNS * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = 0;
            }
        }
        else if (indexPSelf == 6)//EMPLOYEES
        {
            if (indexSelf == 0)//Self training
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                ST += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * HST * convertPercent;
                STDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f) * HST * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)//Self training 2
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                ST += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HST * convertPercent;
                STDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * UnityEngine.Random.Range(0.25f, 2f) * HST * convertPercent;

                int randomB = UnityEngine.Random.Range(0, 7);
                if (randomB == 0)
                {
                    SP += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HSP * convertPercent;
                    SPDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HSP * convertPercent;

                }
                else if (randomB == 1)
                {
                    MKT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HMKT * convertPercent;
                    MKTDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HMKT * convertPercent;
                }
                else if (randomB == 2)
                {
                    MARKET += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HMARKET * convertPercent;
                    MARKETDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HMARKET * convertPercent;
                }
                else if (randomB == 3)
                {
                    LC += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HL * convertPercent;
                    LCDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HL * convertPercent;
                }
                else if (randomB == 4)
                {
                    KH += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HKH * convertPercent;
                    KHDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HKH * convertPercent;
                }
                else if (randomB == 5)
                {
                    NS += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HNS * convertPercent;
                    NSDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HNS * convertPercent;
                }
                else if (randomB == 6)
                {
                    ST += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HST * convertPercent;
                    STDT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * HST * convertPercent;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)//Human resource
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                if (Mn < 150)
                {
                    int addMN = (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000);
                    Mn += addMN;
                    if (Mn > 150)
                        Mn = 150;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 3)//People hiring : 50
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += (long)(moneyDT * 0.5f);
                NS += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.5f * HNS * convertPercent;
                NSDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f) * HNS * convertPercent;
                CheckRatio();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 4)//Company culture : 15
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += moneyDT;
                CheckRatio();
            }
            else if (indexSelf == 5)//Annually event : 20
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += moneyDT;
                CheckRatio();
            }
            else if (indexSelf == 6)//Internal company fund : 10
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS += moneyDT;
                CheckRatio();
            }
            else if (indexSelf == 7)//Employee training
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                int size = (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000);
                if (Mn < 150)
                {
                    Mn += size * 0.5f;
                    if (Mn > 150)
                        Mn = 150;
                }
                for (int i = 0; i < size; i++)
                {
                    NS += GameConfig.Instance.HP_ext * HNS * convertPercent;
                }
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 8)//Curriculum for employee training
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                if (GameConfig.Instance.HP_ext < 250)
                {
                    long size = bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000;
                    float add = size * (1000 - GameConfig.Instance.HP_ext) / 10;
                    if (add > (250 - GameConfig.Instance.HP_ext))
                        add = 50;
                    GameConfig.Instance.HP_ext += add;
                }
            }
        }
        else if (indexPSelf == 7)//Funding
        {
            if (indexSelf == 0)//Find a co-founder
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                ST += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * HST * convertPercent;
                STDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f) * HST * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            if (indexSelf == 1)//Borrow money
            {
                int count = PlayerPrefs.GetInt("Count Borrow money", 0);
                PlayerPrefs.SetInt("Count Borrow money", count++);
                int IndexRandom = UnityEngine.Random.Range(1, 5);
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT * IndexRandom;
                GameManager.Instance.main.dollars += moneyDT * IndexRandom;
                if (PlayerPrefs.GetInt("Count Borrow money") == 5)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }

            }
            if (indexSelf == 2)//Capital
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                ST += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * HST * convertPercent;
                STDT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f) * HST * convertPercent;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            if (indexSelf == 3)//bank Loan
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                GameManager.Instance.main.dollars += moneyDT;
            }
        }

    }

    public void CheckRatio()
    {
        List<long> minArray = new List<long>();
        long minPeopleHiring = bigBranch[6].smallBranch[3].moneyDTS / GameConfig.Instance.HR_ph;
        minArray.Add(minPeopleHiring);
        long minCompanyCulture = bigBranch[6].smallBranch[4].moneyDTS / GameConfig.Instance.HR_cc;
        minArray.Add(minCompanyCulture);
        long minAnnuallyEvent = bigBranch[6].smallBranch[5].moneyDTS / GameConfig.Instance.HR_ae;
        minArray.Add(minAnnuallyEvent);
        long minInternalCompanyFund = bigBranch[6].smallBranch[6].moneyDTS / GameConfig.Instance.HR_ic;
        minArray.Add(minInternalCompanyFund);
        long min = minPeopleHiring;
        for (int i = 1; i < 4; i++)
        {
            if (minArray[i] < min)
            {
                min = minArray[i];
            }
        }

        NS = (min * (GameConfig.Instance.HR_ph + GameConfig.Instance.HR_cc + GameConfig.Instance.HR_ae + GameConfig.Instance.HR_ic)) * GameManager.Instance.SRD * HNS * convertPercent;
        bigBranch[6].smallBranch[3].moneyDTS -= min * GameConfig.Instance.HR_ph;
        bigBranch[6].smallBranch[4].moneyDTS -= min * GameConfig.Instance.HR_cc;
        bigBranch[6].smallBranch[5].moneyDTS -= min * GameConfig.Instance.HR_ae;
        bigBranch[6].smallBranch[6].moneyDTS -= min * GameConfig.Instance.HR_ic;

    }

    public void UpdateDay()
    {
        FactoryWorkshopLoop();
        BuyingOtherFactoryWorkshop();
        Service();
        TraditionalAds();
        Website_Affiliate();
        BuildAShop();
        OnlineShop();
        SalesCulture();
        BuyACompetitor();
        BankLoan();
        BorrowMoney();
    }

    public void FactoryWorkshopLoop()
    {
        if (bigBranch[0].smallBranch[1].moneyDTBD > GameConfig.Instance.PP_f_Min && bigBranch[0].smallBranch[1].moneyDTS == 0 && (long)((TimeSpan)(GameManager.Instance.dateGame -
           DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayBD))).TotalDays >= 365)
        {
            bigBranch[0].smallBranch[1].isRunning = false;
        }
        if (bigBranch[0].smallBranch[1].moneyDTS > 0 && (long)((TimeSpan)(GameManager.Instance.dateGame -
           DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayBD))).TotalDays >= 365)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayS))).TotalDays) % 30 == 0)
            {
                float money = bigBranch[0].smallBranch[1].moneyDTS * GameConfig.Instance.PP_fxi - 50 *
                    (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayS))).TotalDays) / 30 - 1);
                if (money <= 0)
                {
                    bigBranch[0].smallBranch[1].moneyDTS = 0;
                    bigBranch[0].smallBranch[1].isRunning = false;
                }
                else
                {
                    SP += money * HSP * convertPercent;
                    SPDT += UnityEngine.Random.Range(1000f, money * 2f) * HSP * convertPercent;
                }
            }
        }
    }

    public void BuyingOtherFactoryWorkshop()
    {
        if (bigBranch[0].smallBranch[3].moneyDTS > 0 && ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[3].investmentDayBD))).TotalDays) % 30 == 0)
        {
            float money = (bigBranch[0].smallBranch[3].moneyDTS) * GameConfig.Instance.PP_bxi - 50
                * (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[3].investmentDayBD))).TotalDays) / 30 - 1);
            if (money <= 0)
            {
                bigBranch[0].smallBranch[3].moneyDTS = 0;
                bigBranch[0].smallBranch[3].isRunning = false;
            }
            else
            {
                SP += money * HSP * convertPercent;
                SPDT += UnityEngine.Random.Range(1000f, money * 2f) * HSP * convertPercent;
            }
        }
    }

    public void Service()
    {
        if (bigBranch[0].smallBranch[1].moneyDTS > 0 || bigBranch[0].smallBranch[3].moneyDTS > 0)
        {
            bigBranch[0].smallBranch[4].isRunning = false;
        }
        else
        {
            bigBranch[0].smallBranch[4].isRunning = true;
        }
    }

    public void TraditionalAds()
    {
        if (bigBranch[1].smallBranch[0].moneyDTBD > 0 && (long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[1].smallBranch[0].investmentDayBD))).TotalDays
            == 30)
        {
            if (UnityEngine.Random.Range(0f, 1f) <= 0.1f)
            {
                MKT += bigBranch[1].smallBranch[0].moneyDTS * GameConfig.Instance.Ads_t * HMKT * convertPercent;
                MKTDT += UnityEngine.Random.Range(0f, bigBranch[1].smallBranch[0].moneyDTS * GameConfig.Instance.Ads_t * 2f) * HMKT * convertPercent;
            }
            bigBranch[1].smallBranch[0].moneyDTBD = 0;
            bigBranch[1].smallBranch[0].isRunning = false;
        }
    }

    public void Website_Affiliate()
    {
        if (bigBranch[1].smallBranch[2].moneyDTBD > 0)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[1].smallBranch[2].investmentDayBD))).TotalDays <= 365 * 2)
            {
                if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[1].smallBranch[2].investmentDayBD))).TotalDays) % 30 == 0)
                {
                    MKT += bigBranch[1].smallBranch[2].moneyDTBD * GameConfig.Instance.Ads_w * HMKT * convertPercent;
                    MKTDT += UnityEngine.Random.Range(0f, bigBranch[1].smallBranch[2].moneyDTBD * GameConfig.Instance.Ads_w * 2f) * HMKT * convertPercent;
                }
            }
            else
            {
                bigBranch[1].smallBranch[2].moneyDTBD = 0;
                bigBranch[1].smallBranch[2].isRunning = false;
            }
        }
    }

    public void BuildAShop()
    {
        if (bigBranch[4].smallBranch[0].moneyDTBD >= 10000)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[4].smallBranch[0].investmentDayBD))).TotalDays <= 365 * 3)
            {
                if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[4].smallBranch[0].investmentDayBD))).TotalDays) % 30 == 0)
                {
                    LC += bigBranch[4].smallBranch[0].moneyDTBD * GameConfig.Instance.SC_bx * HL * convertPercent;
                    LCDT += UnityEngine.Random.Range(1000f, bigBranch[4].smallBranch[0].moneyDTBD * GameConfig.Instance.SC_bx * 2f) * HL * convertPercent;
                }
            }
            else
            {
                bigBranch[4].smallBranch[0].moneyDTBD = 0;
                bigBranch[4].smallBranch[0].isRunning = false;
            }
        }
    }

    public void OnlineShop()
    {
        if (bigBranch[4].smallBranch[2].moneyDTBD > 0)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[4].smallBranch[2].investmentDayBD))).TotalDays <= 365 * 3)
            {
                if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[4].smallBranch[2].investmentDayBD))).TotalDays) % 30 == 0)
                {
                    LC += bigBranch[4].smallBranch[2].moneyDTBD * GameConfig.Instance.SC_ox * HL * convertPercent;
                    LCDT += UnityEngine.Random.Range(1000f, bigBranch[4].smallBranch[2].moneyDTBD * GameConfig.Instance.SC_ox * 2f) * HL * convertPercent;
                }
            }
            else
            {
                bigBranch[4].smallBranch[2].moneyDTBD = 0;
                bigBranch[4].smallBranch[2].isRunning = false;
            }
        }
    }

    public void SalesCulture()
    {
        if (bigBranch[4].smallBranch[0].moneyDTBD > 0 || bigBranch[4].smallBranch[2].moneyDTBD > 0)
        {
            bigBranch[4].smallBranch[3].isRunning = false;
        }
        else
        {
            bigBranch[4].smallBranch[3].isRunning = true;
        }
    }

    public void BuyACompetitor()
    {

        if (bigBranch[2].smallBranch[3].moneyDTBD > 0)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame
                - DateTime.Parse(bigBranch[2].smallBranch[3].investmentDayBD))).TotalDays) % 30 == 0)
            {
                if (bigBranch[2].smallBranch[3].moneyDTS > 0)
                {
                    UIManager.Instance.panelBuyCompetitor.SetActive(true);
                    UIManager.Instance.panelBuyCompetitor.transform.GetChild(0).GetComponent<Text>().text
                        = "You've successfully purchased a competitor in " + nameCountry;
                    I0 += bigBranch[2].smallBranch[3].moneyDTBD * GameConfig.Instance.SR_bp;
                }
                else
                {
                    GameManager.Instance.main.dollars += bigBranch[2].smallBranch[3].moneyDTBD;
                    bigBranch[2].smallBranch[3].moneyDTBD = bigBranch[2].smallBranch[3].moneyDTS = 0;
                }
            }
        }
    }

    public void BankLoan()
    {
        if (bigBranch[7].smallBranch[3].moneyDTBD > 0)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[7].smallBranch[3].investmentDayBD))).TotalDays == 365)
            {
                string info = "";
                if (GameManager.Instance.main.dollars < bigBranch[7].smallBranch[3].moneyDTBD / 2)
                {
                    long moneyVay = bigBranch[7].smallBranch[3].moneyDTBD / 2 - GameManager.Instance.main.dollars;
                    if (L > (long)(moneyVay * GameConfig.Instance.Bx))
                    {
                        GameManager.Instance.main.dollars = 0;
                        L -= (long)(moneyVay * GameConfig.Instance.Bx);
                        bigBranch[7].smallBranch[3].moneyDTBD -= bigBranch[7].smallBranch[3].moneyDTBD / 2;
                        info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[3].moneyDTBD / 2) + " in " + nameCountry;
                    }
                    else
                    {
                        GameManager.Instance.main.dollars = 0;
                        bigBranch[7].smallBranch[3].moneyDTBD = 0;
                        GameManager.Instance.main.lsCoutryReady.Remove(this);
                        info = "You do not have enough money to pay the debt and your company in " + nameCountry + " has lost ";
                        bigBranch[7].smallBranch[3].isRunning = false;
                    }
                }
                else
                {
                    GameManager.Instance.main.dollars -= bigBranch[7].smallBranch[3].moneyDTBD / 2;
                    bigBranch[7].smallBranch[3].moneyDTBD -= bigBranch[7].smallBranch[3].moneyDTBD / 2;
                    info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[3].moneyDTBD / 2) + " in " + nameCountry;
                }
                UIManager.Instance.panelBankLoan.SetActive(true);
                UIManager.Instance.panelBankLoan.transform.GetChild(0).GetComponent<Text>().text = info;

            }
            else if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[7].smallBranch[3].investmentDayBD))).TotalDays == 365 * 2)
            {
                string info = "";
                if (GameManager.Instance.main.dollars < bigBranch[7].smallBranch[3].moneyDTBD)
                {
                    long moneyVay = bigBranch[7].smallBranch[3].moneyDTBD - GameManager.Instance.main.dollars;
                    if (L > (long)(moneyVay * GameConfig.Instance.Bx))
                    {
                        GameManager.Instance.main.dollars = 0;
                        L -= (long)(moneyVay * GameConfig.Instance.Bx);
                        bigBranch[7].smallBranch[3].moneyDTBD = 0;
                        info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[3].moneyDTBD) + " in " + nameCountry;
                        bigBranch[7].smallBranch[3].isRunning = false;
                    }
                    else
                    {
                        GameManager.Instance.main.dollars = 0;
                        bigBranch[7].smallBranch[3].moneyDTBD = 0;
                        GameManager.Instance.main.lsCoutryReady.Remove(this);
                        info = "You do not have enough money to pay the debt and your company in " + nameCountry + " has lost ";
                        bigBranch[7].smallBranch[3].isRunning = false;
                    }
                }
                else
                {
                    GameManager.Instance.main.dollars -= bigBranch[7].smallBranch[3].moneyDTBD;
                    bigBranch[7].smallBranch[3].moneyDTBD = 0;
                    info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[3].moneyDTBD) + " in " + nameCountry;
                    bigBranch[7].smallBranch[3].isRunning = false;
                }
                UIManager.Instance.panelBankLoan.SetActive(true);
                UIManager.Instance.panelBankLoan.transform.GetChild(0).GetComponent<Text>().text = info;
            }
        }
    }

    public void BorrowMoney()
    {
        if (bigBranch[7].smallBranch[1].moneyDTBD > 0)
        {
            if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[7].smallBranch[1].investmentDayBD))).TotalDays == 365)
            {
                string info = "";
                if (GameManager.Instance.main.dollars < bigBranch[7].smallBranch[1].moneyDTBD / 2)
                {
                    GameManager.Instance.main.dollars = 0;
                    info = "You do not have enough money to pay the debt and your company in " + nameCountry + " has lost ";
                    bigBranch[7].smallBranch[1].isRunning = false;
                }
                else
                {
                    GameManager.Instance.main.dollars -= bigBranch[7].smallBranch[1].moneyDTBD / 2;
                    bigBranch[7].smallBranch[1].moneyDTBD -= bigBranch[7].smallBranch[1].moneyDTBD / 2;
                    info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[1].moneyDTBD / 2) + " in " + nameCountry;
                }
                UIManager.Instance.panelBankLoan.SetActive(true);
                UIManager.Instance.panelBankLoan.transform.GetChild(0).GetComponent<Text>().text = info;

            }
            else if ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[7].smallBranch[1].investmentDayBD))).TotalDays == 365 * 2)
            {
                string info = "";
                if (GameManager.Instance.main.dollars < bigBranch[7].smallBranch[1].moneyDTBD)
                {
                    GameManager.Instance.main.dollars = 0;
                    bigBranch[7].smallBranch[1].moneyDTBD = 0;
                    info = "You do not have enough money to pay the debt and your company in " + nameCountry + " has lost ";
                    bigBranch[7].smallBranch[1].isRunning = false;
                }
                else
                {
                    GameManager.Instance.main.dollars -= bigBranch[7].smallBranch[1].moneyDTBD;
                    bigBranch[7].smallBranch[1].moneyDTBD -= bigBranch[7].smallBranch[1].moneyDTBD;
                    info = "You have just successfully repayment " + ConvertNumber.convertNumber_DatDz(bigBranch[7].smallBranch[3].moneyDTBD) + " in " + nameCountry;
                    bigBranch[7].smallBranch[1].isRunning = false;
                }
                UIManager.Instance.panelBankLoan.SetActive(true);
                UIManager.Instance.panelBankLoan.transform.GetChild(0).GetComponent<Text>().text = info;
            }
        }
    }

    public void ResetDataCol()
    {
        for (int j = 1; j < 12; j++)
        {
            for (int k = 0; k < 7; k++)
            {
                dataColChartMain[j].valueCol[k] = 0;
                dataColChartCompetitors[j].valueCol[k] = 0;
            }
        }
    }
}
