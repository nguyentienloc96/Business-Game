using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private bool isOn; //biến check có bật music hay không ?

    public Button buttonMusic;
    public Button buttonMusic_inGamePlayScene; //btn in GamePlay scene
    public Sprite isOnSprite;
    public Sprite isOffSprite;

    [Header("AudioClip")]
    public AudioClip buttonSound;
    public AudioClip coinSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    [Header("AudioSource")]
    public AudioSource musicSource;
    public AudioSource soundSource;

    private void Start()
    {
        if (PlayerPrefs.GetInt(KeyPlayerPrefs.MUSIC) == 0 || !PlayerPrefs.HasKey(KeyPlayerPrefs.MUSIC))
        {
            isOn = true;
        }
        else if (PlayerPrefs.GetInt(KeyPlayerPrefs.MUSIC) == 1)
        {
            isOn = false;
        }
        
        UpdateButtons();
    }

    #region ===MUSIC===
    /// <summary>
    /// Update hình ảnh button
    /// </summary>
    private void UpdateButtons()
    {
        buttonMusic.gameObject.GetComponent<Image>().sprite = isOn ? isOnSprite : isOffSprite;
        buttonMusic_inGamePlayScene.gameObject.GetComponent<Image>().sprite = isOn ? isOnSprite : isOffSprite;
        if(isOn)
        {
            PlayerPrefs.SetInt(KeyPlayerPrefs.MUSIC, 0);
        }
        else
        {
            PlayerPrefs.SetInt(KeyPlayerPrefs.MUSIC, 1);
        }
    }

    /// <summary>
    /// Click button
    /// </summary>
    public void OnClickButton()
    {
        isOn = !isOn;
        if(isOn)
        {
           StartCoroutine( PlayNewMusic());
        }
        else
        {
            musicSource.Stop();
        }
        UpdateButtons();
    }

    /// <summary>
    /// Hàm tắt nhạc cũ, bật nhac mới
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayNewMusic()
    {
        while (musicSource.volume >= 0.1f)
        {
            musicSource.volume -= 0.2f;
            yield return new WaitForSeconds(0.25f);
        }
        musicSource.Stop();
        if (isOn)
        {
            musicSource.Play();
        }
        musicSource.volume = 1;
    }
    #endregion

    #region ===SOUND===
    public void PlayLoseSound()
    {
        if (!isOn)
        {
            return;
        }           
        //StopGameMusic();
        soundSource.clip = loseSound;
        soundSource.Play();
    }

    public void PlayUIClick()
    {
        if (!isOn)
        {
            return;
        }  
        soundSource.clip = buttonSound;
        soundSource.Play();
    }

    public void PlayWinSound()
    {
        if (!isOn)
        {
            return;
        }  
        //StopGameMusic();
        soundSource.clip = winSound;
        soundSource.Play();
    }

    public void PlayCoinSound()
    {
        if (!isOn)
        {
            return;
        }
        soundSource.clip = coinSound;
        soundSource.Play();
    }
    #endregion
}
