using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public struct DataColChart
{
    public string nameCol;
    [Range(0, 1f)]
    public float[] valueCol;
}
public class ColumnChart : MonoBehaviour
{
    public GameObject itemChart;
    public Transform posChart;
    public DataColChart[] dataCol;
    void Start()
    {
        Vector3 posItemChart = Vector3.zero;
        for (int i = 0; i < dataCol.Length; i++)
        {
            GameObject item = Instantiate(itemChart, posChart);
            item.transform.localPosition = posItemChart;
            StartCoroutine(ColChart(dataCol[i], item));
            posItemChart += new Vector3(80f, 0f, 0f);
        }
    }

    IEnumerator ColChart(DataColChart datacol, GameObject item)
    {
        for (int j = 0; j < datacol.valueCol.Length; j++)
        {
            item.transform.GetChild(j).GetComponent<Image>().DOFillAmount(datacol.valueCol[j], 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
