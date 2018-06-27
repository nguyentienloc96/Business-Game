using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CountryJSON
{
    public string name;
    public string code;
}

[Serializable]
public class WordJSON
{
    public CountryJSON[] world;
}

public class Word : MonoBehaviour
{

    public static Word Instance;
    public int idSelectWord;

    [Header("Word")]
    public GameObject itemWord;
    public Transform contentWord;
    public Slider seltTraining;
    public Text seltGold;
    public List<Country> lsCountry = new List<Country>();

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    void Start()
    {
        TextAsset asset = Resources.Load<TextAsset>("ListNameCountry");
        WordJSON info = JsonUtility.FromJson<WordJSON>(asset.text);
        for (int i = 0; i < info.world.Length; i++)
        {
            Transform item = Instantiate(itemWord, contentWord).transform;
            item.name = info.world[i].name;
            if (i == 0)
            {
                idSelectWord = 0;
                item.GetChild(3).gameObject.SetActive(true);
            }
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = string.Format("{0:000}", i);
            item.GetChild(1).GetComponent<Text>().text = info.world[i].name;
            lsCountry.Add(item.GetComponent<Country>());
            item.GetComponent<Country>().ID = i;
            item.GetComponent<Country>().nameCountry = info.world[i].name;
            item.GetComponent<Country>().Mn = UnityEngine.Random.Range(50, 200);
        }
    }

    public void SliderSeltTraining()
    {
        lsCountry[idSelectWord].L =1000 + (int)(seltTraining.value * 49)*1000;
        seltGold.text = lsCountry[idSelectWord].L.ToString();
    }

    public IEnumerator OnEnableWord(bool isWord)
    {
        if (isWord)
        {
            for (int i = 0; i < lsCountry.Count; i++)
            {
                lsCountry[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < lsCountry.Count; i++)
            {
                if (i == 0)
                {
                    lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
                    lsCountry[i].transform.GetChild(3).gameObject.SetActive(true);
                    idSelectWord = 0;
                }
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
            for (int i = 0; i < GameManager.Instance.main.lsCoutryReady.Count; i++)
            {
                if (i == 0)
                {
                    lsCountry[idSelectWord].transform.GetChild(3).gameObject.SetActive(false);
                    idSelectWord = GameManager.Instance.main.lsCoutryReady[i].ID;
                    GameManager.Instance.main.lsCoutryReady[i].transform.GetChild(3).gameObject.SetActive(true);
                }
                GameManager.Instance.main.lsCoutryReady[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
