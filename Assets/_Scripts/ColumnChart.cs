using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public struct DataColChart
{
    public string namePei;
    [Range(0, 1f)]
    public float[] valuePei;
}
public class ColumnChart : MonoBehaviour
{
    public GameObject itemChart;
    public Transform posChart;
    public DataColChart[] dataCol;
    IEnumerator Start()
    {
        Vector3 posItemChart = Vector3.zero;
        for (int i = 0; i < dataCol.Length; i++)
        {
            GameObject item = Instantiate(itemChart, posChart);
            item.transform.localPosition = posItemChart;
            for (int j = 0; j < dataCol[i].valuePei.Length; j++)
            {
                item.transform.GetChild(j).GetComponent<Image>().DOFillAmount(dataCol[i].valuePei[j], 0.25f);
                yield return new WaitForSeconds(0.25f);
            }
            posItemChart += new Vector3(80f, 0f, 0f);
        }
    }

}
