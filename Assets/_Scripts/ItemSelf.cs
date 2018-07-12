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
        if (Word.Instance.lsItemSelf.Count - 1 > Word.Instance.indexSelf)
        {
            Word.Instance.lsItemSelf[Word.Instance.indexSelf].GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        Word.Instance.indexPSelf = indexPSelf;
        Word.Instance.indexSelf = indexSelf;
        Word.Instance.txtLabel.text = label;
        Word.Instance.txtInfo.text = info;
        Word.Instance.sliderEvole.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = 0;
        Word.Instance.seltCoin2.text = Word.Instance.minSlider2.ToString();
        if (Word.Instance.maxSlider > Word.Instance.minSlider2)
        {
            Word.Instance.sliderEvole.SetActive(true);
        }
        else
        {
            Word.Instance.sliderEvole.SetActive(false);
        }
        UIManager.Instance.SelfTraining.SetActive(true);

        if (PlayerPrefs.GetInt("isDoneTutorial") == 0)
        {
            UIManager.Instance.Turorial(UIManager.Instance.SelfTraining.transform.GetChild(2).GetChild(0).gameObject, new Vector3(744f, -177f, 0), new Vector3(0, 0, 180f));
        }
    }

    public void UpdateShow()
    {
        if (Word.Instance.maxSlider > Word.Instance.minSlider2)
        {
            Word.Instance.sliderEvole.SetActive(!Word.Instance.lsCountry[Word.Instance.idSelectWord]
            .bigBranch[indexPSelf].smallBranch[indexSelf].isRunning);
        }
        else
        {
            Word.Instance.sliderEvole.SetActive(false);
        }
    }


    public void Update()
    {
        transform.GetChild(1).GetComponent<Button>().interactable = !Word.Instance.lsCountry[Word.Instance.idSelectWord]
            .bigBranch[indexPSelf].smallBranch[indexSelf].isRunning;
    }
}
