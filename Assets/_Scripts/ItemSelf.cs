using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelf : MonoBehaviour
{

    public int indexPSelf;
    public int indexSelf;
    public string label;
    public string info;

    public void OnclickSelf()
    {
        Word.Instance.lsItemSelf[Word.Instance.indexSelf].GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        Word.Instance.indexPSelf = indexPSelf;
        Word.Instance.indexSelf = indexSelf;
        Word.Instance.txtLabel.text = label;
        Word.Instance.txtInfo.text = info;
        Word.Instance.maxSlider2 = (long)(GameManager.Instance.main.coin * 0.95f);
        if(Word.Instance.maxSlider2 > 10000)
        {
            Word.Instance.sliderEvole.SetActive(true);
        }
        else
        {
            Word.Instance.sliderEvole.SetActive(false);
        }
        UIManager.Instance.SelfTraining.SetActive(true);
    }

}
