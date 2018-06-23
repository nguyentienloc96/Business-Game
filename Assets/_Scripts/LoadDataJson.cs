﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadDataJson : MonoBehaviour
{
    public static LoadDataJson Instance = new LoadDataJson();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadDataStartGameJson();
        LoadDataUpdateJson();
        //DataPlayer.Instance.SaveDataPlayer(1, 1, 50000, 10);

        DataPlayer.Instance.LoadDataPlayer();
    }

    private string newsJson = "DataNews";
    private string dataUpdateJson = "DataUpdate";
    private string startGameJson = "StartGameEditor";

    public void LoadDataNewsJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(newsJson));
        //Debug.Log(objJson);
        if (objJson != null)
        {
            for (int i = 0; i < objJson.Count; i++)
            {
                News.NewItems tmp = new News.NewItems();
                tmp.content = objJson["New" + i.ToString()][0];
                tmp.isUseful = objJson["New" + i.ToString()][1].AsBool;
                tmp.major = objJson["New" + i.ToString()][2];
                News.Instance.lstNews.Add(tmp);
            }
        }

        News.Instance.GetNews();
    }
    public void LoadDataUpdateJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(dataUpdateJson));
        Debug.Log(objJson);
        if (objJson != null)
        {
            var objNS = objJson["NhanSu"];
            for (int i = 0; i < objNS.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_NhanSu.Add(data);
            }

            var objTC = objJson["TransportChain"];
            for (int i = 0; i < objTC.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_TransportChain.Add(data);
            }

            var objPP = objJson["ProcedureProcess"];
            for (int i = 0; i < objPP.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_ProcedureProcess.Add(data);
            }

            var objSpreading = objJson["Spreading"];
            for (int i = 0; i < objSpreading.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_Spreading.Add(data);
            }

            var objAds = objJson["Ads"];
            for (int i = 0; i < objAds.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_Ads.Add(data);
            }

            var objSC = objJson["SalesChain"];
            for (int i = 0; i < objAds.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_SalesChain.Add(data);
            }

            var objRM = objJson["RiskManagement"];
            for (int i = 0; i < objRM.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objNS[i]["name"];
                data.content = objNS[i]["content"];
                DataUpdate.Instance.lstData_RiskManagement.Add(data);
            }
        }       
    }

    public void LoadDataStartGameJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(startGameJson));
        Debug.Log(objJson);
        if (objJson != null)
        {
            GameConfig.Instance.timeScale = objJson["TimeScale"].AsFloat;
            GameConfig.Instance.dollarStartGame = objJson["DollarStart"].AsDouble;
            GameConfig.Instance.bitcoinStartGame = objJson["BitCoinStart"].AsDouble;
            GameConfig.Instance.timeInterAds = objJson["TimeInterAds"].AsFloat;
            GameConfig.Instance.InMin = objJson["InMin"].AsDouble;
            GameConfig.Instance.InMax = objJson["InMax"].AsDouble;

            GameConfig.Instance.Ipc = objJson["Ipc"].AsFloat;

            GameConfig.Instance.HP_ext = objJson["HP.etx"].AsFloat;
            GameConfig.Instance.TC_tax = objJson["TC.tax"].AsFloat;
            GameConfig.Instance.TC_wx = objJson["TC.wx"].AsFloat;
            GameConfig.Instance.SC_bx = objJson["SC.bx"].AsFloat;
            GameConfig.Instance.SC_ax = objJson["SC.ax"].AsFloat;
            GameConfig.Instance.SC_ox = objJson["SC.ox"].AsFloat;

            GameConfig.Instance.dTime = objJson["Dtime"].AsInt;
        }
    }

    string loadJson(string _nameJson)
    {
        TextAsset _text = Resources.Load(_nameJson) as TextAsset;
        return _text.text;
    }
}
