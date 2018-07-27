using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : MonoBehaviour
{

    public int ID;
    public string nameCountry;
    public long L = 0;
    public long LDT = 0;

    public double I0 = 0f;
    public double SP = 0f;
    public double MKT = 0f;
    public double MARKET = 0f;
    public double LC = 0f;
    public double KH = 0f;
    public double NS = 0f;
    public double ST = 0f;

    public double I0DT = 0f;
    public double SPDT = 0f;
    public double MKTDT = 0f;
    public double MARKETDT = 0f;
    public double LCDT = 0f;
    public double KHDT = 0f;
    public double NSDT = 0f;
    public double STDT = 0f;

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
                for (int k = 0; k < 7; k++)
                {
                    dataColChartMain[j].valueCol[k]
                        += GameManager.Instance.main.lsCoutryReady[i].dataColChartMain[j].valueCol[k];
                    dataColChartCompetitors[j].valueCol[k]
                        += GameManager.Instance.main.lsCoutryReady[i].dataColChartCompetitors[j].valueCol[k];
                }
            }

        }
    }

    public void PullData()
    {
        PushWord();
        int month = GameManager.Instance.dateGame.Month - 1;
        dataColChartMain[month].valueCol[0] = (long)(SP);
        dataColChartMain[month].valueCol[1] = (long)(MKT);
        dataColChartMain[month].valueCol[2] = (long)(MARKET);
        dataColChartMain[month].valueCol[3] = (long)(LC);
        dataColChartMain[month].valueCol[4] = (long)(KH);
        dataColChartMain[month].valueCol[5] = (long)(NS);
        dataColChartMain[month].valueCol[6] = (long)(ST);

        dataColChartCompetitors[month].valueCol[0] = (long)(SPDT);
        dataColChartCompetitors[month].valueCol[1] = (long)(MKTDT);
        dataColChartCompetitors[month].valueCol[2] = (long)(MARKETDT);
        dataColChartCompetitors[month].valueCol[3] = (long)(LCDT);
        dataColChartCompetitors[month].valueCol[4] = (long)(KHDT);
        dataColChartCompetitors[month].valueCol[5] = (long)(NSDT);
        dataColChartCompetitors[month].valueCol[6] = (long)(STDT);

    }

    void ResetInfo()
    {
        L = LDT = 0;

        I0 = SP = MKT = MARKET = LC = KH = NS = ST = 0f;

        I0DT = SPDT = MKTDT = MARKETDT = LCDT = KHDT = NSDT = STDT = 0f;

        for (int j = 0; j < 12; j++)
        {
            for (int k = 0; k < 7; k++)
            {
                dataColChartMain[j].valueCol[k] = 0;
                dataColChartCompetitors[j].valueCol[k] = 0;
            }
        }
    }

    public void OnClickWorld()
    {
        if (UIManager.Instance.indexScene == 1)
        {
            if (WorldManager.Instance.idSelectWord != -1)
            {
                WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            }
            WorldManager.Instance.idSelectWord = ID;
            transform.GetChild(1).gameObject.SetActive(true);
            PushWord();
            if (L != 0)
            {
                WorldManager.Instance.maxSlider = (long)(GameManager.Instance.main.dollars * 0.95f);
                UIManager.Instance.PieChart2.SetActive(true);
                LoadDataChart();
            }
        }
    }

    public void LoadDataChart()
    {
        UIManager.Instance.PieChart2.GetComponent<PieChart>().dataPei[0].valuePei = ((float)(L) / (float)(L + LDT));
        UIManager.Instance.PieChart2.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(LDT) / (float)(L + LDT));
        UIManager.Instance.PieChart2.GetComponent<PieChart>().LoadData();
        UIManager.Instance.COLCHART.transform
        .GetChild(0).GetChild(0).GetChild(0).GetComponent<ColumnChart>().dataCol = dataColChartMain;
        UIManager.Instance.COLCHART.transform
            .GetChild(0).GetChild(0).GetChild(0).GetComponent<ColumnChart>().loadData();

        //UIManager.Instance.COLCHART.transform
        //    .GetChild(1).GetChild(0).GetChild(0).GetComponent<ColumnChart>().dataCol = dataColChartCompetitors;
        //UIManager.Instance.COLCHART.transform
        //    .GetChild(1).GetChild(0).GetChild(0).GetComponent<ColumnChart>().loadData();
    }

    public void Update()
    {
        if (WorldManager.Instance != null)
        {
            transform.GetChild(1).gameObject.SetActive(WorldManager.Instance.idSelectWord == -1 ? true : false);
        }
    }
}
