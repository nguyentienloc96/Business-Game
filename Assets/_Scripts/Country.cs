using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct STBranch
{
    public string nameSmallBranch;
    public long initialInvestmentMoney;
    public long investmentMoneyLater;
    public DateTime startDate;
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
        GameManager.Instance.competitors.coin += (int)(LDT * GameConfig.Instance.Ipc / 100) + (int)(I0DT * Mn / 100);
    }

    public void OnClickItemWord()
    {
        Word.Instance.lsCountry[Word.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        Word.Instance.idSelectWord = ID;
        if (UIManager.Instance.indexScene == 0)
        {
            UIManager.Instance.txtCodeCountry.text = "Ma Nuoc : " + Mn.ToString() + "%";
            UIManager.Instance.txtGDPCountry.text = "GDP : " + UIManager.Instance.SubstringNumberGoldReplay(GDP) + " <size=38>$</size>";
            UIManager.Instance.PieChart1.SetActive(true);
            Word.Instance.maxSlider = (long)(GameManager.Instance.main.coin * 0.95f);
            if (Word.Instance.maxSlider > 10000 && L == 0)
            {
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(true);
                UIManager.Instance.POSITIONSELECT.SetActive(true);
                UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = nameCountry;
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
                UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnClickYes());
            }
            else
                UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            Word.Instance.seltTraining.value = 0;
            Word.Instance.LSlider = 10000;
            Word.Instance.seltCoin.text = Word.Instance.LSlider.ToString();
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)L / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(GDP - L) / (float)GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
        }
        else if (UIManager.Instance.indexScene == 1)
        {
            if (I0 != 0)
            {
                Word.Instance.maxSlider2 = (long)(GameManager.Instance.main.coin * 0.95f);
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
        }
        else if (UIManager.Instance.indexScene == 2)
        {
            UIManager.Instance.LabelCountry.text = string.Format("{0:000}", ID);
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
            UIManager.Instance.POSITIONSELECT.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Ban dau tu thanh cong " + L.ToString() + "$ vào " + nameCountry;
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

    public void SetSmallBranch(int indexPSelf, int indexSelf)
    {
        if (indexPSelf == 0)
        {
            if (indexSelf == 0) {
                if (bigBranch[0].smallBranch[0].initialInvestmentMoney > 10000)
                {
                    if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
                    {
                        SP0 += 1000000;
                        if (UnityEngine.Random.Range(0f, 1f) <= 0.2f * GameManager.Instance.SRD)
                            SP0DT += 1000000;
                        bigBranch[0].smallBranch[0].initialInvestmentMoney = 0;
                    }
                }
            }
            else
            {
                SP0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
                SP0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
                bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
            }
        }
        else if(indexPSelf == 1)
        {
            MKT0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            MKT0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
        else if (indexPSelf == 2)
        {
            NS0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            NS0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
        else if (indexPSelf == 3)
        {
            L0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            L0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
        else if (indexPSelf == 4)
        {
            MAKRET0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            MAKRET0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
        else if (indexPSelf == 5)
        {
            KH0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            KH0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
        else if (indexPSelf == 6)
        {
            ST0 += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * 0.7f;
            ST0DT += bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney * UnityEngine.Random.Range(0.25f, 2f);
            bigBranch[indexPSelf].smallBranch[indexSelf].initialInvestmentMoney = 0;
        }
    }

}
