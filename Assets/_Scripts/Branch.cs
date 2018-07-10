using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branch : MonoBehaviour
{

    public int index = 0;

    public void LoadDataBranch()
    {
        if (GameManager.Instance.main.lsCoutryReady.Count <= 0)
            return;
        StopAllCoroutines();
        UIManager.Instance.SelfTraining.SetActive(false);
        UIManager.Instance.ResetBranch();
        if (index == 0)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_ProcedureProcess));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(true);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (index == 1)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_Ads));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(true);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (index == 2)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_Spreading));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (index == 3)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_TransportChain));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(true);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (index == 4)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_SalesChain));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(true);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (index == 5)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_RiskManagement));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (index == 6)
        {
            StartCoroutine(IELoadBranch(DataUpdate.Instance.lstData_NhanSu));
            UIManager.Instance.btnBRANCH1.transform.GetChild(1).gameObject.SetActive(true);
            UIManager.Instance.btnBRANCH2.transform.GetChild(1).gameObject.SetActive(false);
            UIManager.Instance.btnBRANCH3.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    IEnumerator IELoadBranch(List<DataUpdate.DataItems> lsData)
    {
        UIManager.Instance.ResetBranch();
        for (int i = 0; i < lsData.Count; i++)
        {
            Transform itemSelf = Instantiate(GameManager.Instance.itemSelf, GameManager.Instance.contentSelf).transform;
            Word.Instance.lsItemSelf.Add(itemSelf);
            itemSelf.GetChild(1).GetChild(0).GetComponent<Text>().text = lsData[i].name;
            itemSelf.GetComponent<ItemSelf>().indexPSelf = index;
            itemSelf.GetComponent<ItemSelf>().indexSelf = i;
            itemSelf.GetComponent<ItemSelf>().label = lsData[i].name;
            itemSelf.GetComponent<ItemSelf>().info = lsData[i].content;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
