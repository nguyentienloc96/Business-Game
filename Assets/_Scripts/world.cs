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
            WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            WorldManager.Instance.idSelectWord = ID;
            transform.GetChild(1).gameObject.SetActive(true);
            PushWord();
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
    }

    public void Update()
    {
        if (WorldManager.Instance != null)
        {
            transform.GetChild(1).gameObject.SetActive(WorldManager.Instance.idSelectWord == -1 ? true : false);
        }
    }
}
