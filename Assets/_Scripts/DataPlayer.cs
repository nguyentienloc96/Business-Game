using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class DataPlayer : MonoBehaviour
{
    public static DataPlayer Instance = new DataPlayer();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public int modePlay; //Chế độ chơi

    public int srd; //độ khó

    public double dollars; //tiền

    public double btc; //bitcoin

    public int isOffAds; //check có tắt quảng cáo hay chưa

    public List<CountryCurrent> lstCountry_Data = new List<CountryCurrent>();

    public string abc;

    public void SaveDataPlayer()
    {
        DataPlayer data = new DataPlayer();
        data.modePlay = GameManager.Instance.modePlay;
        data.srd = GameManager.Instance.SRD;
        data.dollars = GameManager.Instance.main.coin;
        data.btc = GameManager.Instance.main.bitCoin;
        Debug.Log(GameManager.Instance.main.lsCoutryReady.Count);
        data.lstCountry_Data = new List<CountryCurrent>();
        for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
        {
            CountryCurrent ct = new CountryCurrent();
            ct.ID = GameManager.Instance.main.lsCoutryReady[i].ID;
            ct.nameCountry = GameManager.Instance.main.lsCoutryReady[i].nameCountry;
            ct.GDP = GameManager.Instance.main.lsCoutryReady[i].GDP;
            ct.L = GameManager.Instance.main.lsCoutryReady[i].L;
            ct.LDT = GameManager.Instance.main.lsCoutryReady[i].LDT;
            ct.Mn = GameManager.Instance.main.lsCoutryReady[i].Mn;

            ct.I0 = GameManager.Instance.main.lsCoutryReady[i].I0;
            ct.SP0 = GameManager.Instance.main.lsCoutryReady[i].SP0;
            ct.MKT0 = GameManager.Instance.main.lsCoutryReady[i].MKT0;
            ct.MAKRET0 = GameManager.Instance.main.lsCoutryReady[i].MAKRET0;
            ct.L0 = GameManager.Instance.main.lsCoutryReady[i].L0;
            ct.KH0 = GameManager.Instance.main.lsCoutryReady[i].KH0;
            ct.NS0 = GameManager.Instance.main.lsCoutryReady[i].NS0;
            ct.ST0 = GameManager.Instance.main.lsCoutryReady[i].ST0;

            ct.I0DT = GameManager.Instance.main.lsCoutryReady[i].I0DT;
            ct.SP0DT = GameManager.Instance.main.lsCoutryReady[i].SP0DT;
            ct.MKT0DT = GameManager.Instance.main.lsCoutryReady[i].MKT0DT;
            ct.MAKRET0DT = GameManager.Instance.main.lsCoutryReady[i].MAKRET0DT;
            ct.L0DT = GameManager.Instance.main.lsCoutryReady[i].L0DT;
            ct.KH0DT = GameManager.Instance.main.lsCoutryReady[i].KH0DT;
            ct.NS0DT = GameManager.Instance.main.lsCoutryReady[i].NS0DT;
            ct.ST0DT = GameManager.Instance.main.lsCoutryReady[i].ST0DT;

            //for (int k = 0; k < ct.bigBranch.Length; k++)
            //{
            //    if (k == 0)
            //    {
            //        for (int l = 0; l < 5; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 1)
            //    {
            //        for (int l = 0; l < 3; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 2)
            //    {
            //        for (int l = 0; l < 5; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 3)
            //    {
            //        for (int l = 0; l < 3; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 4)
            //    {
            //        for (int l = 0; l < 4; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 5)
            //    {
            //        for (int l = 0; l < 3; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //    if (k == 6)
            //    {
            //        for (int l = 0; l < 9; l++)
            //        {
            //            string[] arrString = new string[5];
            //            ct.bigBranch[k].Add(arrString);
            //        }
            //    }
            //}

            //for (int k = 0; k < ct.bigBranch.Length; k++)
            //{
            //    for (int l = 0; l < ct.bigBranch[k].Count; l++)
            //    {
            //        ct.bigBranch[k][l][0] =
            //            GameManager.Instance.main.lsCoutryReady[i].bigBranch[k].smallBranch[l].nameSmallBranch;
            //        ct.bigBranch[k][l][1] =
            //            GameManager.Instance.main.lsCoutryReady[i].bigBranch[k].smallBranch[l].initialInvestmentMoney.ToString();
            //        ct.bigBranch[k][l][2] =
            //            GameManager.Instance.main.lsCoutryReady[i].bigBranch[k].smallBranch[l].investmentMoneyLater.ToString();
            //        ct.bigBranch[k][l][3] =
            //            GameManager.Instance.main.lsCoutryReady[i].bigBranch[k].smallBranch[l].startDate.ToString();
            //        ct.bigBranch[k][l][4] =
            //            GameManager.Instance.main.lsCoutryReady[i].bigBranch[k].smallBranch[l].isRunning.ToString();
            //    }
            //}

            //for (int k = 0; k < 12; k++)
            //{
            //    int[] arrInt = new int[7];
            //    ct.dataColChartMain.Add(arrInt);
            //    ct.dataColChartCompetitors.Add(arrInt);
            //}

            //for(int k = 0; k < 12; k++)
            //{
            //    for(int l = 0; l < 7; l++)
            //    {
            //        ct.dataColChartMain[k][l] = GameManager.Instance.main.lsCoutryReady[i].dataColChartMain[k].valueCol[l];
            //        ct.dataColChartCompetitors[k][l] = GameManager.Instance.main.lsCoutryReady[i].dataColChartCompetitors[k].valueCol[l];
            //    }
            //}
            //data.abc = ct.ToString();
            //PlayerPrefs.SetString("testData", ct.ToString());
            data.lstCountry_Data.Add(ct);
        }
        
        
        data.isOffAds = PlayerPrefs.GetInt(KeyPlayerPrefs.ISOFFADS, 0);
        string _path = Path.Combine(Application.persistentDataPath, "DataPlayer.json");
        File.WriteAllText(_path, JsonUtility.ToJson(data, true));
        File.ReadAllText(_path);
    }

    public void LoadDataPlayer()
    {
        string _path = Path.Combine(Application.persistentDataPath, "DataPlayer.json");
        string dataAsJson = File.ReadAllText(_path);
        //Debug.Log(dataAsJson);
        var objJson = SimpleJSON.JSON.Parse(dataAsJson);
        Debug.Log(objJson);
        //if (objJson != null)
        //{
        //    this.modePlay = objJson["modePlay"].AsInt;
        //    this.srd = objJson["srd"].AsInt;
        //    this.dollars = objJson["dollars"].AsDouble;
        //    this.btc = objJson["btc"].AsDouble;
        //    this.isOffAds = objJson["isOffAds"].AsInt;
        //}
    }
}
