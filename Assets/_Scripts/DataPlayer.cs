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

    public string dateStartPlay;

    public string dateGame;

    public void SaveDataPlayer()
    {
        DataPlayer data = new DataPlayer();
        data.modePlay = GameManager.Instance.modePlay;
        data.srd = GameManager.Instance.SRD;
        data.dollars = GameManager.Instance.main.dollars;
        data.btc = GameManager.Instance.main.bitCoin;
        data.dateStartPlay = GameManager.Instance.dateStartPlay.ToString();
        data.dateGame = GameManager.Instance.dateGame.ToString();
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
            ct.MAKRET0 = GameManager.Instance.main.lsCoutryReady[i].MARKET0;
            ct.L0 = GameManager.Instance.main.lsCoutryReady[i].L0;
            ct.KH0 = GameManager.Instance.main.lsCoutryReady[i].KH0;
            ct.NS0 = GameManager.Instance.main.lsCoutryReady[i].NS0;
            ct.ST0 = GameManager.Instance.main.lsCoutryReady[i].ST0;

            ct.I0DT = GameManager.Instance.main.lsCoutryReady[i].I0DT;
            ct.SP0DT = GameManager.Instance.main.lsCoutryReady[i].SP0DT;
            ct.MKT0DT = GameManager.Instance.main.lsCoutryReady[i].MKT0DT;
            ct.MAKRET0DT = GameManager.Instance.main.lsCoutryReady[i].MARKET0DT;
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
        Debug.Log(objJson);
        if (objJson != null)
        {
            GameManager.Instance.modePlay = objJson["modePlay"].AsInt;
            GameManager.Instance.SRD = objJson["srd"].AsInt;
            GameManager.Instance.main.dollars = objJson["dollars"].AsLong;
            GameManager.Instance.main.bitCoin = objJson["btc"].AsLong;
            PlayerPrefs.SetInt(KeyPlayerPrefs.ISOFFADS, objJson["isOffAds"].AsInt);
            GameManager.Instance.dateStartPlay = DateTime.Parse(objJson["dateStartPlay"]);
            GameManager.Instance.dateGame = DateTime.Parse(objJson["dateGame"]);
            var lsData = objJson["lstCountry_Data"].AsArray;
            lstCountry_Data = new List<CountryCurrent>();
            GameManager.Instance.main.lsCoutryReady = new List<Country>();
            for (int i = 0; i < lsData.Count; i++)
            {
                int ID = lsData[i]["ID"].AsInt;
                Country ct = Word.Instance.lsCountry[ID];
                ct.L = lsData[i]["L"].AsLong;
                ct.LDT = lsData[i]["LDT"].AsLong;
                ct.Mn = lsData[i]["Mn"].AsFloat;

                ct.I0 = lsData[i]["I0"].AsFloat;
                ct.SP0 = lsData[i]["SP0"].AsFloat;
                ct.MKT0 = lsData[i]["MKT0"].AsFloat;
                ct.MARKET0 = lsData[i]["MAKRET0"].AsFloat;
                ct.L0 = lsData[i]["L0"].AsFloat;
                ct.KH0 = lsData[i]["KH0"].AsFloat;
                ct.NS0 = lsData[i]["NS0"].AsFloat;
                ct.ST0 = lsData[i]["ST0"].AsFloat;

                ct.I0DT = lsData[i]["I0DT"].AsFloat;
                ct.SP0DT = lsData[i]["SP0DT"].AsFloat;
                ct.MKT0DT = lsData[i]["MKT0DT"].AsFloat;
                ct.MARKET0DT = lsData[i]["MAKRET0DT"].AsFloat;
                ct.L0DT = lsData[i]["L0DT"].AsFloat;
                ct.KH0DT = lsData[i]["KH0DT"].AsFloat;
                ct.NS0DT = lsData[i]["NS0DT"].AsFloat;
                ct.ST0DT = lsData[i]["ST0DT"].AsFloat;

                var bigBranch = lsData[i]["bigBranch"];
                ct.bigBranch = new STBigBranch[bigBranch.Count];
                for (int j = 0; j < bigBranch.Count; j++)
                {
                    ct.bigBranch[j].nameBigBranch = bigBranch[j]["nameBigBranch"];
                    var smallBranch = bigBranch[j]["smallBranch"];
                    ct.bigBranch[j].smallBranch = new STBranch[smallBranch.Count];
                    for (int k = 0; k < smallBranch.Count; k++)
                    {
                        ct.bigBranch[j].smallBranch[k].nameSmallBranch = smallBranch[k]["nameSmallBranch"];
                        ct.bigBranch[j].smallBranch[k].moneyDTBD = smallBranch[k]["moneyDTBD"].AsLong;
                        ct.bigBranch[j].smallBranch[k].moneyDTS = smallBranch[k]["moneyDTS"].AsLong;
                        ct.bigBranch[j].smallBranch[k].investmentDayBD = smallBranch[k]["investmentDayBD"];
                        ct.bigBranch[j].smallBranch[k].investmentDayS = smallBranch[k]["investmentDayS"];
                        ct.bigBranch[j].smallBranch[k].isRunning = smallBranch[k]["isRunning"].AsBool;
                    }

                }

                var dataColChartMain = lsData[i]["dataColChartMain"];
                ct.dataColChartMain = new DataColChart[dataColChartMain.Count];
                for (int j = 0; j < dataColChartMain.Count; j++)
                {
                    ct.dataColChartMain[j].nameCol = dataColChartMain[j]["nameCol"];
                    ct.dataColChartMain[j].valueCol = new int[dataColChartMain[j]["valueCol"].Count];
                    for (int k = 0; k < dataColChartMain[j]["valueCol"].Count; k++)
                    {
                        ct.dataColChartMain[j].valueCol[k] = dataColChartMain[j]["valueCol"][k].AsInt;
                    }
                    
                }

                var dataColChartCompetitors = lsData[i]["dataColChartCompetitors"];
                ct.dataColChartCompetitors = new DataColChart[dataColChartCompetitors.Count];
                for (int j = 0; j < dataColChartCompetitors.Count; j++)
                {
                    ct.dataColChartCompetitors[j].nameCol = dataColChartCompetitors[j]["nameCol"];
                    ct.dataColChartCompetitors[j].valueCol = new int[dataColChartCompetitors[j]["valueCol"].Count];
                    for (int k = 0; k < dataColChartCompetitors[j]["valueCol"].Count; k++)
                    {
                        ct.dataColChartCompetitors[j].valueCol[k] = dataColChartCompetitors[j]["valueCol"][k].AsInt;
                    }

                }
                GameManager.Instance.main.lsCoutryReady.Add(ct);
            }
        }

    }
}
