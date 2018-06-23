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

    public double dollars; //tiền

    public double btc; //bitcoin

    public int isOffAds; //check có tắt quảng cáo hay chưa

    public void SaveDataPlayer(int _modePlay,int _srd, double _dollar, double _btc)
    {
        DataPlayer data = new DataPlayer();
        data.modePlay = _modePlay;
        data.srd = _srd;
        data.dollars = _dollar;
        data.btc = _btc;
        data.isOffAds = PlayerPrefs.GetInt(KeyPlayerPrefs.ISOFFADS,0);
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
            this.modePlay = objJson["modePlay"].AsInt;
            this.srd = objJson["srd"].AsInt;
            this.dollars = objJson["dollars"].AsDouble;
            this.btc = objJson["btc"].AsDouble;
            this.isOffAds = objJson["isOffAds"].AsInt;          
        }            
    }
}
