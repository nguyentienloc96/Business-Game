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
    }

    private void Start()
    {
        //LoadDataNewsJson();
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
