using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUpdate : MonoBehaviour
{
    public static DataUpdate Instance = new DataUpdate();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    [System.Serializable]
    public struct DataItems
    {
        public string name;
        public string content;
    }

    public struct DataNameCountry
    {
        public string name;
        public string code;
    }

    public List<DataItems> lstData_NhanSu = new List<DataItems>();
    public List<DataItems> lstData_TransportChain = new List<DataItems>();
    public List<DataItems> lstData_ProcedureProcess = new List<DataItems>();
    public List<DataItems> lstData_Spreading = new List<DataItems>();
    public List<DataItems> lstData_Ads = new List<DataItems>();
    public List<DataItems> lstData_SalesChain = new List<DataItems>();
    public List<DataItems> lstData_RiskManagement = new List<DataItems>();

    public List<DataNameCountry> lstData_NameCountry = new List<DataNameCountry>();
}
