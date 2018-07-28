using System.Collections;
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
        //string _path = Path.Combine(Application.persistentDataPath, "DataPlayer.json");
        //File.Delete(_path);
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(KeyPlayerPrefs.IS_NEWPLAYER) == 1)
        {
            //DataPlayer.Instance.LoadDataPlayer();
        }
        LoadDataStartGameJson();
        LoadDataUpdateJson();
        LoadDataNameCountry();
        LoadDataNewsJson();
        //DataPlayer.Instance.SaveDataPlayer(1, 1, 50000, 10);

        //DataPlayer.Instance.LoadDataPlayer();
    }

    private string newsJson = "DataNews";
    private string dataUpdateJson = "DataUpdate";
    private string startGameJson = "StartGameEditor";
    private string listNameCountryJson = "ListNameCountry";

    public void LoadDataNewsJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(newsJson));
        //Debug.Log(objJson);
        //Debug.Log("<color=yellow>Done: </color>LoadDataNewsJson !");
        if (objJson != null)
        {
            for (int i = 0; i < objJson.Count; i++)
            {
                News.NewItems tmp = new News.NewItems();
                tmp.content = objJson[i.ToString()][0];
                tmp.isUseful = objJson[i.ToString()][1].AsBool;
                tmp.major = objJson[i.ToString()][2];
                News.Instance.lstNews.Add(tmp);
            }
        }

        //News.Instance.GetNews();
    }

    public void LoadDataUpdateJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(dataUpdateJson));
        //Debug.Log(objJson);
        //Debug.Log("<color=yellow>Done: </color>LoadDataUpdateJson !");
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
                data.name = objTC[i]["name"];
                data.content = objTC[i]["content"];
                DataUpdate.Instance.lstData_TransportChain.Add(data);
            }

            var objPP = objJson["ProcedureProcess"];
            for (int i = 0; i < objPP.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objPP[i]["name"];
                data.content = objPP[i]["content"];
                DataUpdate.Instance.lstData_ProcedureProcess.Add(data);
            }

            var objSpreading = objJson["Spreading"];
            for (int i = 0; i < objSpreading.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objSpreading[i]["name"];
                data.content = objSpreading[i]["content"];
                DataUpdate.Instance.lstData_Spreading.Add(data);
            }

            var objAds = objJson["Ads"];
            for (int i = 0; i < objAds.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objAds[i]["name"];
                data.content = objAds[i]["content"];
                DataUpdate.Instance.lstData_Ads.Add(data);
            }

            var objSC = objJson["SalesChain"];
            for (int i = 0; i < objSC.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objSC[i]["name"];
                data.content = objSC[i]["content"];
                DataUpdate.Instance.lstData_SalesChain.Add(data);
            }

            var objRM = objJson["RiskManagement"];
            for (int i = 0; i < objRM.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objRM[i]["name"];
                data.content = objRM[i]["content"];
                DataUpdate.Instance.lstData_RiskManagement.Add(data);
            }

            var objF = objJson["Funding"];
            for (int i = 0; i < objF.Count; i++)
            {
                DataUpdate.DataItems data = new DataUpdate.DataItems();
                data.name = objF[i]["name"];
                data.content = objF[i]["content"];
                DataUpdate.Instance.lstData_Founding.Add(data);
            }
        }
        //Debug.Log(DataUpdate.Instance.lstData_Founding.Count);
    }

    public void LoadDataStartGameJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(startGameJson));
        //Debug.Log(objJson);
        //Debug.Log("<color=yellow>Done: </color>LoadDataStartGameJson !");
        if (objJson != null)
        {
            GameConfig.Instance.timeScale = objJson["TimeScale"].AsFloat;
            GameConfig.Instance.dollarStartGame = objJson["DollarStart"].AsLong;
            GameConfig.Instance.bitcoinStartGame = objJson["BitCoinStart"].AsLong;
            GameConfig.Instance.stringStart = objJson["StringStart"];
            GameConfig.Instance.timeInterAds = objJson["TimeInterAds"].AsFloat;
            GameConfig.Instance.InMin = objJson["InMin"].AsLong;
            GameConfig.Instance.InMax = objJson["InMax"].AsLong;
            GameConfig.Instance.linkGame_android = objJson["link_android"];
            GameConfig.Instance.linkGame_ios = objJson["link_ios"];
            GameConfig.Instance.Srd_easy = objJson["easy"].AsFloat;
            GameConfig.Instance.Srd_medium = objJson["medium"].AsFloat;
            GameConfig.Instance.Srd_hard = objJson["hard"].AsFloat;
            GameConfig.Instance.Srd_crazy = objJson["crazy"].AsFloat;
            GameConfig.Instance.id_inter_android = objJson["id_inter_android"];
            GameConfig.Instance.id_inter_ios = objJson["id_inter_ios"];
            GameConfig.Instance.id_video_android = objJson["id_video_android"];
            GameConfig.Instance.id_video_ios = objJson["id_video_ios"];
            GameConfig.Instance.nameVideoUnityAds = objJson["nameVideoUnityAds"];
            GameConfig.Instance.dollarVideoUnityAds = objJson["dollarVideoUnityAds"].AsLong;
            GameConfig.Instance.id_video_android_admob = objJson["id_video_android_admob"];
            GameConfig.Instance.id_video_ios_admob = objJson["id_video_ios_admob"];
            GameConfig.Instance.timeVideoAds = objJson["timeVideoAds"].AsFloat;
            IAP.btc50 = objJson["keyIAP_btc50"];
            IAP.btc300 = objJson["keyIAP_btc300"];
            IAP.btc5000 = objJson["keyIAP_btc5000"];

            GameConfig.Instance.Ipc = objJson["Ipc"].AsFloat;

            GameConfig.Instance.HP_ext = objJson["HP_etx"].AsFloat;
            GameConfig.Instance.TC_tax = objJson["TC_tax"].AsFloat;
            GameConfig.Instance.TC_wx = objJson["TC_wx"].AsFloat;
            GameConfig.Instance.TC_vx = objJson["TC_vx"].AsFloat;
            GameConfig.Instance.SC_bx = objJson["SC_bx"].AsFloat;
            GameConfig.Instance.SC_ax = objJson["SC_ax"].AsFloat;
            GameConfig.Instance.SC_ox = objJson["SC_ox"].AsFloat;
            GameConfig.Instance.PP_rdb = objJson["PP_rdb"].AsLong;
            GameConfig.Instance.PP_f_Min = objJson["PP_f_Min"].AsLong;
            GameConfig.Instance.PP_fxi = objJson["PP_fxi"].AsFloat;
            GameConfig.Instance.PP_o = objJson["PP_o"].AsFloat;
            GameConfig.Instance.PP_b_Min = objJson["PP_b_Min"].AsLong;
            GameConfig.Instance.PP_bxi = objJson["PP_bxi"].AsFloat;
            GameConfig.Instance.SR_b_Min = objJson["SR_b_Min"].AsLong;
            GameConfig.Instance.SR_bp = objJson["SR_bp"].AsFloat;
            GameConfig.Instance.Ads_t = objJson["Ads_t"].AsInt;
            GameConfig.Instance.Ads_w = objJson["Ads_w"].AsFloat;
            GameConfig.Instance.Bx = objJson["Bx"].AsFloat;

            GameConfig.Instance.TL_sp = objJson["TL_sp"].AsInt;
            GameConfig.Instance.TL_mkt = objJson["TL_mkt"].AsInt;
            GameConfig.Instance.TL_maket = objJson["TL_market"].AsInt;
            GameConfig.Instance.TL_ns = objJson["TL_Ns"].AsInt;
            GameConfig.Instance.TL_lo = objJson["TL_lo"].AsInt;
            GameConfig.Instance.TL_kh = objJson["TL_kh"].AsInt;
            GameConfig.Instance.TL_st = objJson["TL_st"].AsInt;
            GameConfig.Instance.s = objJson["S"].AsInt;

            GameConfig.Instance.HR_ph = objJson["HR_ph"].AsInt;
            GameConfig.Instance.HR_cc = objJson["HR_cc"].AsInt;
            GameConfig.Instance.HR_ae = objJson["HR_ae"].AsInt;
            GameConfig.Instance.HR_ic = objJson["HR_ic"].AsInt;

            GameConfig.Instance.dTime = objJson["Dtime"].AsInt;
            GameManager.Instance.SRD = GameConfig.Instance.Srd_easy;
        }

        string _path = Path.Combine(Application.persistentDataPath, "DataPlayer.json");
        string dataAsJson = File.ReadAllText(_path);
        var objJsonDollars = SimpleJSON.JSON.Parse(dataAsJson);
        if (objJsonDollars != null)
        {
            GameConfig.Instance.bitCoin = objJson["btc"].AsLong;
        }
    }

    public void LoadDataNameCountry()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(listNameCountryJson));
        //Debug.Log(objJson);
        //Debug.Log("<color=yellow>Done: </color>LoadDataNameCountry !");
        if (objJson != null)
        {
            for (int i = 0; i < objJson.Count; i++)
            {
                DataUpdate.DataNameCountry data = new DataUpdate.DataNameCountry();
                data.name = objJson[i]["name"];
                data.gdp = objJson[i]["gdp"].AsLong * 1000000;
                DataUpdate.Instance.lstData_NameCountry.Add(data);
            }

            SelectionSort(DataUpdate.Instance.lstData_NameCountry);
        }
        //Debug.Log(DataUpdate.Instance.lstData_NameCountry[0].name + " "+ ConvertNumber.convertNumber_DatDz(DataUpdate.Instance.lstData_NameCountry[0].gdp));
    }

    void SelectionSort(List<DataUpdate.DataNameCountry> a)
    {
        int maxValueIndex = 0;
        for (int i = 0; i < a.Count - 1; i++)
        {
            maxValueIndex = i;
            for (int j = i + 1; j < a.Count; j++)
            {
                if (a[j].gdp > a[maxValueIndex].gdp)
                {
                    maxValueIndex = j;
                }
            }

            if (maxValueIndex != i)
            {
                DataUpdate.DataNameCountry temp = a[i];
                a[i] = a[maxValueIndex];
                a[maxValueIndex] = temp;
            }
        }
    }

    string loadJson(string _nameJson)
    {
        TextAsset _text = Resources.Load(_nameJson) as TextAsset;
        return _text.text;
    }
}
