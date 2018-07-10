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

    public STBigBranch[] bigBranch = new STBigBranch[7];

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
    }

    public void OnClickItemWord()
    {
        Word.Instance.lsCountry[Word.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        Word.Instance.idSelectWord = ID;
        if (UIManager.Instance.indexScene == 0)
        {
            UIManager.Instance.txtCodeCountry.text = "Ma Nuoc : " + Mn.ToString() + "%";
            UIManager.Instance.txtGDPCountry.text = "GDP : " + ConvertNumber.convertNumber_DatDz(GDP) + " <size=38>$</size>";
            UIManager.Instance.PieChart1.SetActive(true);
            if (Word.Instance.maxSlider > Word.Instance.minSlider && L == 0)
            {
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnClickYes());
            }
            else
            {
                UIManager.Instance.POSITIONSELECT.SetActive(false);
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            }
            Word.Instance.seltTraining.value = 0;
            Word.Instance.LSlider = 10000;
            Word.Instance.seltCoin.text = Word.Instance.LSlider.ToString();
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L - LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
        }
        else if (UIManager.Instance.indexScene == 1)
        {
            if (I0 != 0)
            {
                Word.Instance.maxSlider = (long)(GameManager.Instance.main.coin * 0.95f);
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
                UIManager.Instance.PieChart2.SetActive(false);
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
            Word.Instance.sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
            Word.Instance.seltCoin2.text = 10000.ToString();
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
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text =
                "Ban dau tu thanh cong " + ConvertNumber.convertNumber_DatDz(L) + "$ vào " + nameCountry;
            UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L - LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
        }
        else
        {
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).gameObject.SetActive(true);
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban khong du so tien dau tu";
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
                        SP0 += 1000000;
                        if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
                            SP0DT += 1000000;
                        bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
                    }
                }
            }
            else if (indexSelf == 1)//Factory/workshop
            {
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 100000)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                    bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                }
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame -
                    DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD))).TotalDays < 365)
                {
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD >= 100000 && (long)((TimeSpan)(GameManager.Instance.dateGame -
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
                SP0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                SP0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 1.75f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 3)//Buying other factory/workshop
            {
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 200000)
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
                        SP0 += (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 50f;
                        SP0DT += UnityEngine.Random.Range(100f, (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 50f * 2f);
                    }
                }
                if (bigBranch[indexPSelf].smallBranch[1].moneyDTS > 0)
                {
                    if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayS))).TotalDays - 30) > 0)
                    {
                        SP0 += (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 100f;
                        SP0DT += UnityEngine.Random.Range(100f, (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 100f * 2f);

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
                    MKT0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                    MKT0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f);
                    bigBranch[indexPSelf].smallBranch[indexSelf].isRunning = true;
                }
               
            }
            else if (indexSelf == 1)//Social network ads
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                MKT0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                MKT0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f);
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
            bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
            bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
            if (indexSelf == 0)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 3)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 4)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 5)
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 3) //TRANSPORTCHAIN
        {
            if (indexSelf == 0)//Transport agent
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = moneyDT;
                L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.TC_tax;
                L0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_tax * 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)//Warehouse Storage
            {
                bigBranch[indexPSelf].smallBranch[indexSelf].investmentDayBD = GameManager.Instance.dateGame.ToString();
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD += moneyDT;
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS = moneyDT;
                if (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD < 100000)
                {
                    L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * GameConfig.Instance.TC_wx;
                    L0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_wx * 2f);
                }
                else
                {
                    L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS;
                    L0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * UnityEngine.Random.Range(0.25f, GameConfig.Instance.TC_wx * 3f);
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
                    L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS;
                    L0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 2f);

                }
                else
                {
                    L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 0.7f;
                    L0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTS * 0.7f * 2f);
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
                L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.SC_ax;
                L0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * GameConfig.Instance.SC_ax * 2f);
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
                bigBranch[4].smallBranch[0].moneyDTBD += (long)((bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 0.05f * bigBranch[4].smallBranch[0].moneyDTBD);
                bigBranch[4].smallBranch[2].moneyDTBD += (long)((bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000) * 0.05f * bigBranch[4].smallBranch[2].moneyDTBD);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 5)//RISKMANAGEMENT
        {
            if (indexSelf == 0)
            {
                KH0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                KH0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)
            {
                KH0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                KH0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)
            {
                KH0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                KH0DT += UnityEngine.Random.Range(1000f, bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }
        else if (indexPSelf == 6)//EMPLOYEES
        {
            if (indexSelf == 0)//Self training
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 1)//Self training 2
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                int randomB = UnityEngine.Random.Range(0, 7);
                if (randomB == 0)
                {
                    SP0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 1)
                {
                    MKT0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 2)
                {
                    MAKRET0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 3)
                {
                    L0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 4)
                {
                    KH0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 5)
                {
                    NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                else if (randomB == 6)
                {
                    ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f;
                }
                ST0DT += (bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 2f) * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 2)//Human resource
            {
                if (Mn < 150)
                {
                    int addMN = (int)(bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD / 1000);
                    Mn += addMN;
                    if (Mn > 150)
                        Mn = 150;
                }
            }
            else if (indexSelf == 3)//People hiring
            {
                NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.5f;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 4)
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 5)
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 6)
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
            else if (indexSelf == 7)
            {
                ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * 0.7f;
                ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].moneyDTBD = 0;
            }
        }

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
    }

    public void FactoryWorkshopLoop()
    {
        if (bigBranch[0].smallBranch[1].moneyDTBD > 100000 && bigBranch[0].smallBranch[1].moneyDTS == 0 && (long)((TimeSpan)(GameManager.Instance.dateGame -
           DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayBD))).TotalDays >= 365)
        {
            bigBranch[0].smallBranch[1].isRunning = false;
        }
        if (bigBranch[0].smallBranch[1].moneyDTS > 0 && (long)((TimeSpan)(GameManager.Instance.dateGame -
           DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayBD))).TotalDays >= 365)
        {
            if (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayS))).TotalDays) % 30 == 0)
            {
                float money = bigBranch[0].smallBranch[1].moneyDTS * 0.08f - 50 *
                    (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[1].investmentDayS))).TotalDays) / 30 - 1);
                if (money <= 0)
                {
                    bigBranch[0].smallBranch[1].moneyDTS = 0;
                    bigBranch[0].smallBranch[1].isRunning = false;
                }
                else
                {
                    SP0 += money;
                    SP0DT += UnityEngine.Random.Range(1000f, money * 2f);
                }
            }
        }
    }

    public void BuyingOtherFactoryWorkshop()
    {
        if (bigBranch[0].smallBranch[3].moneyDTS > 0 && ((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[3].investmentDayBD))).TotalDays) % 30 == 0)
        {
            float money = (bigBranch[0].smallBranch[3].moneyDTS - 100000) * 0.08f - 50
                * (((long)((TimeSpan)(GameManager.Instance.dateGame - DateTime.Parse(bigBranch[0].smallBranch[3].investmentDayBD))).TotalDays) / 30 - 1);
            if (money <= 0)
            {
                bigBranch[0].smallBranch[3].moneyDTS = 0;
                bigBranch[0].smallBranch[3].isRunning = false;
            }
            else
            {
                SP0 += money;
                SP0DT += UnityEngine.Random.Range(1000f, money * 2f);
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
                MKT0 += bigBranch[1].smallBranch[0].moneyDTS * 0.1f;
                MKT0DT += UnityEngine.Random.Range(0f, bigBranch[1].smallBranch[0].moneyDTS * 0.1f * 2f);
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
                    MKT0 += bigBranch[1].smallBranch[2].moneyDTBD * 0.1f;
                    MKT0DT += UnityEngine.Random.Range(0f, bigBranch[1].smallBranch[2].moneyDTBD * 0.1f * 2f);
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
                    L0 += bigBranch[4].smallBranch[0].moneyDTBD * GameConfig.Instance.SC_bx;
                    L0DT += UnityEngine.Random.Range(1000f, bigBranch[4].smallBranch[0].moneyDTBD * GameConfig.Instance.SC_bx * 2f);
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
                    L0 += bigBranch[4].smallBranch[2].moneyDTBD * GameConfig.Instance.SC_bx;
                    L0DT += UnityEngine.Random.Range(1000f, bigBranch[4].smallBranch[2].moneyDTBD * GameConfig.Instance.SC_bx * 2f);
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


}
