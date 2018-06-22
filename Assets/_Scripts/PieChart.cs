using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public struct DataPeiChart
{
    public string namePei;
    [Range(0, 1f)]
    public float valuePei;
    public Sprite spPei;
}

public class PieChart : MonoBehaviour
{
    public Transform peiParent;
    public Transform noteParent;
    public GameObject peiPrefab;
    public GameObject notePrefab;
    public List<DataPeiChart> dataPei = new List<DataPeiChart>();
    IEnumerator Start()
    {
        float sumValue = 0;
        for (int i = 0; i < dataPei.Count; i++)
        {
            GameObject peiObj = Instantiate(peiPrefab, peiParent);
            peiObj.GetComponent<RectTransform>().SetAsLastSibling();
            Vector3 vectorsizeDelta = peiObj.GetComponent<RectTransform>().sizeDelta;
            peiObj.transform.eulerAngles = new Vector3(0f, 0f, 360f * (1 - sumValue));
            if (sumValue > 0.25 && sumValue < 0.75)
            {
                peiObj.transform.GetChild(0).localEulerAngles = new Vector3(0f, 0f, -180f);
            }
            peiObj.transform.GetChild(0).GetComponent<Text>().text = dataPei[i].valuePei * 100 + "%";
            peiObj.GetComponent<Image>().sprite = dataPei[i].spPei;
            peiObj.GetComponent<Image>().SetNativeSize();
            peiObj.GetComponent<Image>().DOFillAmount(dataPei[i].valuePei, 1f);
            GameObject noteObj = Instantiate(notePrefab, noteParent);
            noteObj.GetComponent<Image>().sprite = dataPei[i].spPei;
            noteObj.transform.GetChild(0).GetComponent<Text>().text = dataPei[i].namePei;
            sumValue += dataPei[i].valuePei;
            yield return new WaitForSeconds(1f);
        }
    }

    public Vector2 positionPei(float angle, float R)
    {
        Vector2 kq;
        float angleDelta = 0;
        if (angle > 180)
        {
            angleDelta = angle - 180f;
        }
        float deltaY = R * Mathf.Cos(Mathf.Deg2Rad * angleDelta);
        float deltaX = R * Mathf.Sin(Mathf.Deg2Rad * angleDelta);
        if (angle > 180)
        {
            if (angle > 90 && angle < 270)
            {
                kq = new Vector2(deltaX, deltaY);
            }
            else
            {
                kq = new Vector2(deltaX, -deltaY);
            }
        }
        else
        {
            if (angle > 90 && angle < 270)
            {
                kq = new Vector2(-deltaX, deltaY);
            }
            else
            {
                kq = new Vector2(-deltaX, -deltaY);
            }
        }
        return kq;
    }
}
