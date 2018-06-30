using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelf : MonoBehaviour {

    public int idCountry;
    public int indexPSelf;
    public int indexSelf;
	
    public void OnclickSelf()
    {
        UIManager.Instance.SelfTraining.SetActive(true);
    }

    public void SliderSelfTraining()
    {
        if (indexPSelf == 0) {
            if (indexSelf == 0)
            {
                Word.Instance.lsCountry[idCountry].pROCEDUREPROCESS.rdb.initialInvestmentMoney = 1000 + (int)(UIManager.Instance.sliderTraining.value * 49) * 1000;
                UIManager.Instance.coinSelf.text = Word.Instance.lsCountry[idCountry].pROCEDUREPROCESS.rdb.initialInvestmentMoney.ToString();
            }
        }
    }

    public void Evole()
    {

    }
}
