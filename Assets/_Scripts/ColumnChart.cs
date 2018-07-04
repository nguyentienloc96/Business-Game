using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public struct DataColChart
{
    public string nameCol;
    public int[] valueCol;
}
public class ColumnChart : MonoBehaviour
{
    public Text[] arrayX;
    public DataColChart[] dataCol;
    public GameObject[] lsItem = new GameObject[12];
    public void loadData()
    {
        int maxX = 0;
        for (int i = 0; i < lsItem.Length; i++)
        {
            for (int j = 0; j < lsItem[i].transform.childCount; j++)
            {
                lsItem[i].transform.GetChild(j).GetComponent<Image>().fillAmount = 0;
            }
        }

        for (int i = 0; i < dataCol.Length; i++)
        {

            for (int j = 0; j < dataCol[i].valueCol.Length; j++)
            {
                if (maxX < dataCol[i].valueCol[j])
                {
                    maxX = dataCol[i].valueCol[j];
                }
            }
        }

        if (maxX > 10000 && maxX % 10000 != 0)
        {
            maxX = ((int)(maxX / 10000)) * 10000 + 10000;
        }
        else if (maxX <= 10000)
        {
            maxX = 10000;
        }

        for (int i = 0; i <= 10; i++)
        {
            arrayX[i].text = ((maxX / 10) * i).ToString();
        }

        for (int i = 0; i < dataCol.Length; i++)
        {
            StartCoroutine(ColChart(dataCol[i], lsItem[i], maxX));
        }
    }

    IEnumerator ColChart(DataColChart datacol, GameObject item, int maxX)
    {
        for (int j = 0; j < datacol.valueCol.Length; j++)
        {
            item.transform.GetChild(j).GetComponent<Image>().DOFillAmount((float)datacol.valueCol[j] / (float)maxX, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
