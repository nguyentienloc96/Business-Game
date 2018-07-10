using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{

    public static Word Instance;
    public int idSelectWord = 0;

    [Header("Word")]
    public GameObject itemWord;
    public Transform contentWord;

    [Header("SliderWord")]
    public Slider seltTraining;
    public Text seltCoin;
    public List<Country> lsCountry = new List<Country>();
    public long LSlider = 10000;
    public long minSlider = 10000;
    public long maxSlider = 47000;


    [Header("SliderSelf")]
    public int indexPSelf;
    public int indexSelf;
    public Slider seltTraining2;
    public Text seltCoin2;
    public Text txtLabel;
    public Text txtInfo;
    public GameObject sliderEvole;
    public GameObject panelInfo;
    public long LSlider2 = 1000;
    public long minSlider2 = 1000;

    [Header("ItemSelf")]
    public List<Transform> lsItemSelf = new List<Transform>();

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < DataUpdate.Instance.lstData_NameCountry.Count; i++)
        {
            Transform item = Instantiate(itemWord, contentWord).transform;
            item.name = DataUpdate.Instance.lstData_NameCountry[i].name;
            
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = string.Format("{0:000}", i);
            item.GetChild(1).GetComponent<Text>().text = DataUpdate.Instance.lstData_NameCountry[i].name;
            lsCountry.Add(item.GetComponent<Country>());
            item.GetComponent<Country>().ID = i;
            item.GetComponent<Country>().GDP = DataUpdate.Instance.lstData_NameCountry[i].gdp;
            item.GetComponent<Country>().nameCountry = DataUpdate.Instance.lstData_NameCountry[i].name;
            item.GetComponent<Country>().Mn = UnityEngine.Random.Range(50, 200);
        }
    }

    public void SliderWord()
    {
        long index = (maxSlider - minSlider) / 1000;
        LSlider = minSlider + (long)(seltTraining.value * index) *1000;
        seltCoin.text = ConvertNumber.convertNumber_DatDz(LSlider);
    }

    public void SliderSelf()
    {
        long index = (maxSlider - minSlider2) / 1000;
        LSlider2 = minSlider2 + (long)(seltTraining2.value * index) * 1000;
        seltCoin2.text = ConvertNumber.convertNumber_DatDz(LSlider2);
    }

    public void Evole()
    {
        lsCountry[idSelectWord].SetSmallBranch(indexPSelf,indexSelf,LSlider2);
        lsCountry[idSelectWord].PullData();
        GameManager.Instance.main.coin -= LSlider2;
        panelInfo.SetActive(true);
        panelInfo.transform.GetChild(0).GetComponent<Text>().text = "Ban dau tu thanh cong " + ConvertNumber.convertNumber_DatDz(LSlider2) + "$";
        sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
        seltCoin2.text = minSlider2.ToString();
        Invoke("HidePanelInfo", 2f);
    }

    public void HidePanelInfo()
    {
        panelInfo.SetActive(false);
    }

    public void OnEnableWord(bool isWord)
    {
        StopAllCoroutines();
        StartCoroutine(IEOnEnableWord(isWord));
    }

    IEnumerator IEOnEnableWord(bool isWord)
    {
        if (isWord)
        {
            for (int i = 0; i < lsCountry.Count; i++)
            {
                lsCountry[i].gameObject.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            lsCountry[0].transform.GetChild(3).gameObject.SetActive(true);
            lsCountry[0].OnClickItemWord();
            idSelectWord = 0;
            UIManager.Instance.POSITIONSELECT.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = lsCountry[0].nameCountry;
            for (int i = 0; i < lsCountry.Count; i++)
            { 
                lsCountry[i].gameObject.SetActive(true);
                if (i <= 8)
                    yield return new WaitForSeconds(0.15f);
            }
        }
        else
        {
            for (int i = 0; i < lsCountry.Count; i++)
            {
                lsCountry[i].gameObject.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
            if (GameManager.Instance.main.lsCoutryReady.Count > 0)
            {
                
                GameManager.Instance.main.lsCoutryReady[0].transform.GetChild(3).gameObject.SetActive(true);
                idSelectWord = GameManager.Instance.main.lsCoutryReady[0].ID;
            }
            for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
            {
                GameManager.Instance.main.lsCoutryReady[i].gameObject.SetActive(true);
                if (i <= 8)
                    yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
