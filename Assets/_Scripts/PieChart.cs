using System.Collections;
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
    public DataPeiChart[] dataPei;

    public GameObject[] itemNoteCol;

    public long I0You = 0;
    public void LoadData()
    {
        StopAllCoroutines();
        StartCoroutine(IELoadData());
    }

    IEnumerator IELoadData()
    {
        float sumValue = 0;
        if (peiParent.childCount > 0)
        {
            for (int i = peiParent.childCount - 1; i >= 0; i--)
            {
                Destroy(peiParent.GetChild(i).gameObject);
            }
        }
        if (noteParent.childCount > 0)
        {
            for (int i = noteParent.childCount - 1; i >= 0; i--)
            {
                Destroy(noteParent.GetChild(i).gameObject);

            }
        }

        if (itemNoteCol.Length > 0)
        {
            for (int i = 0; i < itemNoteCol.Length; i++)
            {
                itemNoteCol[i].SetActive(false);
            }
        }
        for (int i = 0; i < dataPei.Length; i++)
        {
            GameObject peiObj = Instantiate(peiPrefab, peiParent);
            peiObj.GetComponent<RectTransform>().SetAsFirstSibling();
            Vector3 vectorsizeDelta = peiObj.GetComponent<RectTransform>().sizeDelta;
            peiObj.transform.eulerAngles = new Vector3(0f, 0f, 360f * (1f - sumValue));

            peiObj.GetComponent<Image>().sprite = dataPei[i].spPei;
            peiObj.GetComponent<Image>().SetNativeSize();
            if (dataPei[i].valuePei < 0.01f && dataPei[i].valuePei > 0)
            {
                peiObj.GetComponent<Image>().DOFillAmount(0.01f, 0.5f);
                sumValue += 0.01f;
                peiObj.transform.GetChild(0).localEulerAngles = new Vector3(0f, 0f, -0.01f * 360 / 2);
            }
            else
            {
                if (i != dataPei.Length - 1)
                {
                    peiObj.GetComponent<Image>().DOFillAmount(dataPei[i].valuePei, 0.5f);
                    sumValue += dataPei[i].valuePei;
                    peiObj.transform.GetChild(0).localEulerAngles = new Vector3(0f, 0f, -dataPei[i].valuePei * 360 / 2);
                }
                else
                {
                    peiObj.GetComponent<Image>().DOFillAmount(1f - sumValue, 0.5f);
                    peiObj.transform.GetChild(0).localEulerAngles = new Vector3(0f, 0f, -(1f - sumValue) * 360 / 2);
                }
            }
            GameObject noteObj = Instantiate(notePrefab, noteParent);
            noteObj.transform.GetChild(0).GetComponent<RawImage>().texture = textureFromSprite(dataPei[i].spPei);
            if (i == 0)
            {
                noteObj.transform.GetChild(1).GetComponent<Text>().text = dataPei[i].namePei + " : " + ConvertNumber.convertNumber_DatDz(I0You) + "$";
            }
            else
            {
                noteObj.transform.GetChild(1).GetComponent<Text>().text = dataPei[i].namePei;
            }

            if (dataPei[i].valuePei < 0.05)
            {
                if (dataPei[i].valuePei <= 0)
                {
                    peiObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "";
                }
                else if (dataPei[i].valuePei < 0.01 / 100)
                {
                    peiObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "<0.01%";
                }
                else
                {
                    peiObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = string.Format("{0:0.00}%", dataPei[i].valuePei * 100);
                }
                //peiObj.transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0f, 158f + 35f * (dataPei.Length - i - 1), 0f);
            }
            else
            {
                peiObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = string.Format("{0:0}%", dataPei[i].valuePei * 100);
                peiObj.transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0f, 158f, 0f);
            }
            if (dataPei[i].valuePei > 0)
            {
                yield return new WaitForSeconds(0.5f);
            }

        }
        if (itemNoteCol.Length > 0)
        {
            for (int i = 0; i < itemNoteCol.Length; i++)
            {
                itemNoteCol[i].SetActive(true);
                yield return new WaitForSeconds(0.15f);
            }
        }
    }

    IEnumerator IELoadNote()
    {
        if (itemNoteCol.Length > 0)
        {
            for (int i = 0; i < itemNoteCol.Length; i++)
            {
                itemNoteCol[i].SetActive(false);
            }
        }
        yield return new WaitUntil(() => !itemNoteCol[itemNoteCol.Length - 1].activeInHierarchy);
        if (itemNoteCol.Length > 0)
        {
            for (int i = 0; i < itemNoteCol.Length; i++)
            {
                itemNoteCol[i].SetActive(true);
                yield return new WaitForSeconds(0.15f);
            }
        }
    }

    public void LoadNote()
    {
        StartCoroutine(IELoadNote());
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
