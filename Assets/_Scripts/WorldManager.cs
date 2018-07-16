using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{

    public static WorldManager Instance;
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
            item.GetComponent<Country>().GDP = DataUpdate.Instance.lstData_NameCountry[i].gdp / UnityEngine.Random.Range(90, 110);
            item.GetComponent<Country>().nameCountry = DataUpdate.Instance.lstData_NameCountry[i].name;
            item.GetComponent<Country>().Mn = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HSP = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HMKT = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HMARKET = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HNS = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HKH = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HL = UnityEngine.Random.Range(50, 200);
            item.GetComponent<Country>().HST = UnityEngine.Random.Range(50, 200);
        }
        minSlider = GameConfig.Instance.InMin;
    }

    public void SliderWord()
    {
        long index = (maxSlider - minSlider) / 1000;
        LSlider = minSlider + (long)(seltTraining.value * index) *1000;
        seltCoin.text = ConvertNumber.convertNumber_DatDz(LSlider);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            UIManager.Instance.Turorial(UIManager.Instance.POSITIONSELECT.transform.GetChild(1).GetChild(2).gameObject, new Vector3(88, -286f, 0), new Vector3(0, 0, 0f));
        }
    }

    public void SliderSelf()
    {
        long index = (maxSlider - minSlider2) / 1000;
        LSlider2 = minSlider2 + (long)(seltTraining2.value * index) * 1000;
        seltCoin2.text = ConvertNumber.convertNumber_DatDz(LSlider2);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            UIManager.Instance.Turorial(UIManager.Instance.SelfTraining.transform.GetChild(2).GetChild(2).gameObject, new Vector3(744f, -419f, 0), new Vector3(0, 0, 180f));
        }
    }

    public void Evole()
    {
        AudioManager.Instance.Play("Click");

        lsCountry[idSelectWord].SetSmallBranch(indexPSelf,indexSelf,LSlider2);
        lsCountry[idSelectWord].PullData();
        GameManager.Instance.main.dollars -= LSlider2;
        panelInfo.SetActive(true);
        if (indexPSelf == 7 && (indexSelf == 3 || indexSelf == 1))
        {
            panelInfo.transform.GetChild(0).GetComponent<Text>().text
                = "You have successfully borrowed " + ConvertNumber.convertNumber_DatDz(LSlider2) + "$ ";
        }
        else
        {
            panelInfo.transform.GetChild(0).GetComponent<Text>().text
                = "You have successfully invested " + ConvertNumber.convertNumber_DatDz(LSlider2) + "$ ";
        }
        sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
        seltCoin2.text = minSlider2.ToString();
        Invoke("HidePanelInfo", 2f);
        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            UIManager.Instance.Turorial(UIManager.Instance.btnTHONGSO.gameObject, new Vector3(-500f, -431f, 0), new Vector3(0, 0, 180f));
        }
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
            if (PlayerPrefs.GetInt("isDoneTutorial") != 0)
            {
                lsCountry[0].OnClickItemWord();
            }
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

    public void OnClickNo()
    {
        AudioManager.Instance.Play("Click");

        UIManager.Instance.POSITIONSELECT.SetActive(false);
    }

    public void OnClickYes()
    {
        AudioManager.Instance.Play("Click");

        if (GameManager.Instance.main.dollars >= LSlider)
        {

            GameManager.Instance.main.dollars -= LSlider;
            lsCountry[idSelectWord].L = LSlider;
            lsCountry[idSelectWord].LDT = (long)(UnityEngine.Random.Range(1000, (lsCountry[idSelectWord].GDP - lsCountry[idSelectWord].L)) / 1000) * 1000;
            GameManager.Instance.main.lsCoutryReady.Add(lsCountry[idSelectWord]);
            UIManager.Instance.POSITIONSELECT.SetActive(false);
            UIManager.Instance.panelEror.SetActive(true);
            UIManager.Instance.panelEror.transform.GetChild(0).GetComponent<Text>().text =
                "You have successfully invested " + ConvertNumber.convertNumber_DatDz(lsCountry[idSelectWord].L) + "$ in " + lsCountry[idSelectWord].nameCountry;
            UIManager.Instance.PieChart1.transform.GetChild(2).gameObject.SetActive(false);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[0].valuePei = ((float)lsCountry[idSelectWord].L / (float)lsCountry[idSelectWord].GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[1].valuePei = ((float)(lsCountry[idSelectWord].LDT) / (float)lsCountry[idSelectWord].GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().dataPei[2].valuePei = ((float)(lsCountry[idSelectWord].GDP - lsCountry[idSelectWord].L - lsCountry[idSelectWord].LDT) / (float)lsCountry[idSelectWord].GDP);
            UIManager.Instance.PieChart1.GetComponent<PieChart>().LoadData();
            if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
            {
                UIManager.Instance.Turorial(UIManager.Instance.panelEror.transform.GetChild(1).gameObject, new Vector3(-31f, -242f, 0), new Vector3(0, 0, 0));
            }
        }
        else
        {
            UIManager.Instance.POSITIONSELECT.SetActive(false);
            UIManager.Instance.panelEror.SetActive(true);
            UIManager.Instance.panelEror.transform.GetChild(0).GetComponent<Text>().text =
                "You do not have enough money ";
        }
    }
}
