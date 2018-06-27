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
    public GameObject itemChart;
    public Transform posChart;
    public Text[] arrayX;
    public DataColChart[] dataCol;
    public void LoadData()
    {
        int maxX = 0;
        Vector3 posItemChart = Vector3.zero;
        for (int i = 0; i < dataCol.Length; i++)
        {
            Destroy(posChart.GetChild(dataCol.Length - i - 1).gameObject);
            for (int j = 0; j < dataCol[i].valueCol.Length; j++)
            {
                if (maxX < dataCol[i].valueCol[j])
                {
                    maxX = dataCol[i].valueCol[j];
                }
            }
        }

        if (maxX % 1000 != 0)
        {
            maxX = ((int)(maxX / 1000)) * 1000 + 1000;
        }

        for (int i = 0; i <= 10; i++)
        {
            arrayX[i].text = ((maxX / 10) * i).ToString();
        }

        for (int i = 0; i < dataCol.Length; i++)
        {
            GameObject item = Instantiate(itemChart, posChart);
            item.transform.localPosition = posItemChart;
            StartCoroutine(ColChart(dataCol[i], item, maxX));
            posItemChart += new Vector3(80f, 0f, 0f);
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
