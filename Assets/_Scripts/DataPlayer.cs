using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

    public long dollars; //tiền

    public long btc; //bitcoin

    public int isOffAds; //check có tắt quảng cáo hay chưa

    public List<CountryCurrent> lstCountry_Data = new List<CountryCurrent>();

    public string abc;

    public DateTime dateStartPlay;

    public DateTime dateGame;

    public void SaveDataPlayer()
    {
        DataPlayer data = new DataPlayer();
        data.modePlay = GameManager.Instance.modePlay;
        data.srd = GameManager.Instance.SRD;
        data.dollars = GameManager.Instance.main.coin;
        data.btc = GameManager.Instance.main.bitCoin;
        data.dateStartPlay = GameManager.Instance.dateStartPlay;
        data.dateGame = GameManager.Instance.dateGame;
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

            ct.bigBranch = GameManager.Instance.main.lsCoutryReady[i].bigBranch;
            ct.dataColChartMain = GameManager.Instance.main.lsCoutryReady[i].dataColChartMain;
            ct.dataColChartCompetitors = GameManager.Instance.main.lsCoutryReady[i].dataColChartCompetitors;

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
        var objJson = SimpleJSON.JSON.Parse(dataAsJson);
        if (objJson != null)
        {
            this.modePlay = objJson["modePlay"].AsInt;
            this.srd = objJson["srd"].AsInt;
            this.dollars = objJson["dollars"].AsLong;
            this.btc = objJson["btc"].AsLong;
            this.isOffAds = objJson["isOffAds"].AsInt;
            //this.dateStartPlay = 
            //this.dateGame =
            var lsData = objJson["lstCountry_Data"].AsArray;
            lstCountry_Data = new List<CountryCurrent>();
            for (int i = 0; i < lsData.Count; i++)
            {
                CountryCurrent ct = new CountryCurrent();
                //ct.ID = lsData.;
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

                ct.bigBranch = GameManager.Instance.main.lsCoutryReady[i].bigBranch;
                ct.dataColChartMain = GameManager.Instance.main.lsCoutryReady[i].dataColChartMain;
                ct.dataColChartCompetitors = GameManager.Instance.main.lsCoutryReady[i].dataColChartCompetitors;

                lstCountry_Data.Add(ct);
            }
        }
    }

    public void LoadPlayer()
    {
        GameManager.Instance.modePlay = modePlay;
        GameManager.Instance.SRD = srd;
        GameManager.Instance.main.coin = dollars;
        GameManager.Instance.main.bitCoin = btc;
        GameManager.Instance.dateStartPlay = dateStartPlay;
        GameManager.Instance.dateGame = dateGame;
        for(int i = 0; i < lstCountry_Data.Count; i++)
        {
            
        }
    }
}
