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

    public float srd; //độ khó

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

            ct.HSP = GameManager.Instance.main.lsCoutryReady[i].HSP;
            ct.HMKT = GameManager.Instance.main.lsCoutryReady[i].HMKT;
            ct.HMARKET = GameManager.Instance.main.lsCoutryReady[i].HMARKET;
            ct.HNS = GameManager.Instance.main.lsCoutryReady[i].HNS;
            ct.HL = GameManager.Instance.main.lsCoutryReady[i].HL;
            ct.HKH = GameManager.Instance.main.lsCoutryReady[i].HKH;
            ct.HST = GameManager.Instance.main.lsCoutryReady[i].HST;


            ct.I0 = GameManager.Instance.main.lsCoutryReady[i].I0;
            ct.SP = GameManager.Instance.main.lsCoutryReady[i].SP;
            ct.MKT = GameManager.Instance.main.lsCoutryReady[i].MKT;
            ct.MAKRET = GameManager.Instance.main.lsCoutryReady[i].MARKET;
            ct.LC = GameManager.Instance.main.lsCoutryReady[i].LC;
            ct.KH = GameManager.Instance.main.lsCoutryReady[i].KH;
            ct.NS = GameManager.Instance.main.lsCoutryReady[i].NS;
            ct.ST = GameManager.Instance.main.lsCoutryReady[i].ST;

            ct.I0DT = GameManager.Instance.main.lsCoutryReady[i].I0DT;
            ct.SPDT = GameManager.Instance.main.lsCoutryReady[i].SPDT;
            ct.MKTDT = GameManager.Instance.main.lsCoutryReady[i].MKTDT;
            ct.MAKRETDT = GameManager.Instance.main.lsCoutryReady[i].MARKETDT;
            ct.LCDT = GameManager.Instance.main.lsCoutryReady[i].LCDT;
            ct.KHDT = GameManager.Instance.main.lsCoutryReady[i].KHDT;
            ct.NSDT = GameManager.Instance.main.lsCoutryReady[i].NSDT;
            ct.STDT = GameManager.Instance.main.lsCoutryReady[i].STDT;

            ct.bigBranch = GameManager.Instance.main.lsCoutryReady[i].bigBranch;           
            ct.dataColChartMain = GameManager.Instance.main.lsCoutryReady[i].dataColChartMain;
            ct.dataColChartCompetitors = GameManager.Instance.main.lsCoutryReady[i].dataColChartCompetitors;

            for (int j = 0; j < GameManager.Instance.main.lsCoutryReady[i].lstNew.Count; j++)
            {
                ct.lstNew.Add(GameManager.Instance.main.lsCoutryReady[i].lstNew[j]);
            }

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
                Country ct = WorldManager.Instance.lsCountry[ID];
                ct.L = lsData[i]["L"].AsLong;
                ct.LDT = lsData[i]["LDT"].AsLong;
                ct.Mn = lsData[i]["Mn"].AsFloat;

                ct.HSP = lsData[i]["HSP"].AsFloat;
                ct.HMKT = lsData[i]["HMKT"].AsFloat;
                ct.HMARKET = lsData[i]["HMARKET"].AsFloat;
                ct.HNS = lsData[i]["HNS"].AsFloat;
                ct.HL = lsData[i]["HL"].AsFloat;
                ct.HKH = lsData[i]["HKH"].AsFloat;
                ct.HST = lsData[i]["HST"].AsFloat;

                ct.I0 = lsData[i]["I0"].AsFloat;
                ct.SP = lsData[i]["SP"].AsFloat;
                ct.MKT = lsData[i]["MKT"].AsFloat;
                ct.MARKET = lsData[i]["MAKRET"].AsFloat;
                ct.LC = lsData[i]["LC"].AsFloat;
                ct.KH = lsData[i]["KH"].AsFloat;
                ct.NS = lsData[i]["NS"].AsFloat;
                ct.ST = lsData[i]["ST"].AsFloat;

                ct.I0DT = lsData[i]["I0DT"].AsFloat;
                ct.SPDT = lsData[i]["SPDT"].AsFloat;
                ct.MKTDT = lsData[i]["MKTDT"].AsFloat;
                ct.MARKETDT = lsData[i]["MAKRETDT"].AsFloat;
                ct.LCDT = lsData[i]["LCDT"].AsFloat;
                ct.KHDT = lsData[i]["KHDT"].AsFloat;
                ct.NSDT = lsData[i]["NSDT"].AsFloat;
                ct.STDT = lsData[i]["STDT"].AsFloat;

                ct.lstNew = new List<string>();
                for (int k = 0; k < lsData[i]["lstNew"].Count; k++)
                {
                    ct.lstNew.Add(lsData[i]["lstNew"][k]);
                }

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
