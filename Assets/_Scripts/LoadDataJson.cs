using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private string newsJson = "DataNews";
    private string dataUpdateJson = "DataUpdate";
    private string startGameJson = "StartGameEditor";

    public void LoadDataNewsJson()
    {
        var objJson = SimpleJSON.JSON.Parse(loadJson(newsJson));
        Debug.Log(objJson);
        if (objJson != null)
        {

        }
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
