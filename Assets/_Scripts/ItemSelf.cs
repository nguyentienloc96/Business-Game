using UnityEngine;
using UnityEngine.UI;

public class ItemSelf : MonoBehaviour
{
    public int indexPSelf;
    public int indexSelf;
    public string label;
    public string info;

    public void OnclickSelf()
    {
        if (WorldManager.Instance.lsItemSelf.Count - 1 > WorldManager.Instance.indexSelf)
        {
            WorldManager.Instance.lsItemSelf[WorldManager.Instance.indexSelf].GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        WorldManager.Instance.indexPSelf = indexPSelf;
        WorldManager.Instance.indexSelf = indexSelf;
        WorldManager.Instance.txtLabel.text = label;
        WorldManager.Instance.txtInfo.text = info;
        WorldManager.Instance.sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
        if (indexPSelf == 2 && indexSelf == 3)
        {
            WorldManager.Instance.minSlider2 = GameConfig.Instance.SR_b_Min;
        }
        else if (indexPSelf == 0 && indexSelf == 1)
        {
            WorldManager.Instance.minSlider2 = GameConfig.Instance.PP_f_Min;
        }
        else if (indexPSelf == 0 && indexSelf == 3)
        {
            WorldManager.Instance.minSlider2 = GameConfig.Instance.PP_b_Min;
        }
        else if (indexPSelf == 4 && indexSelf == 0)
        {
            WorldManager.Instance.minSlider2 = 10000;
        }
        else
        {
            WorldManager.Instance.minSlider2 = 1000;
        }
        WorldManager.Instance.seltCoin2.text = ConvertNumber.convertNumber_DatDz(WorldManager.Instance.minSlider2);
        if (indexPSelf == 7 && (indexSelf == 2 || indexSelf == 0))
        {
            WorldManager.Instance.sliderEvole.SetActive(true);
            WorldManager.Instance.sliderEvole.transform.GetChild(0).gameObject.SetActive(false);
            WorldManager.Instance.sliderEvole.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            if (WorldManager.Instance.maxSlider > WorldManager.Instance.minSlider2)
            {
                WorldManager.Instance.sliderEvole.SetActive(true);
                WorldManager.Instance.sliderEvole.transform.GetChild(0).gameObject.SetActive(true);
                WorldManager.Instance.sliderEvole.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                WorldManager.Instance.sliderEvole.SetActive(false);
            }
        }

        UIManager.Instance.SelfTraining.SetActive(true);

        if (PlayerPrefs.GetInt("isDoneTutorial") == 0 || GameManager.Instance.isTutorial)
        {
            UIManager.Instance.Turorial(UIManager.Instance.SelfTraining.transform.GetChild(2).GetChild(0).gameObject, new Vector3(744f, -177f, 0), new Vector3(0, 0, 180f));
        }
    }

    public void UpdateShow()
    {
        if (WorldManager.Instance.maxSlider > WorldManager.Instance.minSlider2)
        {
            WorldManager.Instance.sliderEvole.SetActive(!WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord]
            .bigBranch[indexPSelf].smallBranch[indexSelf].isRunning);
        }
        else
        {
            WorldManager.Instance.sliderEvole.SetActive(false);
        }
    }

    public void Update()
    {
        if (GameManager.Instance.contentSelf.childCount > 0)
        {
            if (WorldManager.Instance.lsItemSelf.Count > indexSelf)
            {
                transform.GetChild(1).GetComponent<Button>().interactable = !WorldManager.Instance.lsCountry[WorldManager.Instance.idSelectWord]
                .bigBranch[indexPSelf].smallBranch[indexSelf].isRunning;
            }
        }
    }
}
