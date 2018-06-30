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

    [Header("Self")]
    public Slider seltTraining;
    public Text seltCoin;
    public List<Country> lsCountry = new List<Country>();

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
            item.GetComponent<Country>().nameCountry = DataUpdate.Instance.lstData_NameCountry[i].name;
            item.GetComponent<Country>().Mn = UnityEngine.Random.Range(50, 200);
        }
    }

    public void SliderWord()
    {
        lsCountry[idSelectWord].L =1000 + (int)(seltTraining.value * 49)*1000;
        seltCoin.text = lsCountry[idSelectWord].L.ToString();
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
            for (int i = 0; i < lsCountry.Count; i++)
            { 
                lsCountry[i].gameObject.SetActive(true);
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
                yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
