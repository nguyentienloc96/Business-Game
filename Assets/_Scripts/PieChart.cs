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

    public void LoadData()
    {
        StartCoroutine(IELoadData());
    }

    IEnumerator IELoadData()
    {
        float sumValue = 0;
        for (int i = 0; i < dataPei.Count; i++)
        {
            Destroy(peiParent.GetChild(dataPei.Count - i - 1).gameObject);
            Destroy(noteParent.GetChild(dataPei.Count - i - 1).gameObject);
        }
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
            noteObj.transform.GetChild(0).GetComponent<RawImage>().texture = textureFromSprite(dataPei[i].spPei);
            noteObj.transform.GetChild(1).GetComponent<Text>().text = dataPei[i].namePei;
            sumValue += dataPei[i].valuePei;
            yield return new WaitForSeconds(1f);
        }
    }

    public Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        return sprite.texture;
    }
}
