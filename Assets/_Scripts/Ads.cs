using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;
public class Ads : MonoBehaviour
{
    [Header("Admob")]
    InterstitialAd interstitalAd;

    [Header("UnityAds")]
    bool isLoadAds = false;
    bool isShowAds = false;

    [Header("Time")]
    public float timeAds;
    public float timeVideo;

    public static Ads Instance = new Ads();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    void Start()
    {
        //RequestAd();

#if UNITY_ANDROID
        Advertisement.Initialize(GameConfig.Instance.id_video_android, true);
#elif UNITY_IOS
         Advertisement.Initialize(GameConfig.Instance.id_video_ios, true);
#endif
    }

    void Update()
    {
        timeAds += Time.deltaTime;
        timeVideo += Time.deltaTime;

        //if (timeVideo >= 120)
        //{
        //Hiện nút xem video
        //}
    }

    #region ===ADMOB===


    public void RequestAd()
    {
        if (timeAds >= 5 && timeAds <= GameConfig.Instance.timeInterAds / 2)
        {
#if UNITY_ANDROID
        GameConfig.Instance.id_inter_android = "ca-app-pub-6285794272989840/5632501293"; //test
        if (!isLoadAds && GameConfig.Instance.id_inter_android != null)
        {
            interstitalAd = new InterstitialAd(GameConfig.Instance.id_inter_android);
            AdRequest requestInterAd = new AdRequest.Builder().Build();
            interstitalAd.LoadAd(requestInterAd);           
            isShowAds = false;
            isLoadAds = true;
            Debug.Log("Load Ads - "+ interstitalAd.IsLoaded().ToString());
        }
#elif UNITY_IOS
        if (!isLoadAds && GameConfig.Instance.id_inter_ios != null)
        {
            interstitalAd = new InterstitialAd(GameConfig.Instance.id_inter_ios);
            AdRequest requestInterAd = new AdRequest.Builder().Build();
            interstitalAd.LoadAd(requestInterAd);
            isShowAds = false;
            isLoadAds = true;
            Debug.Log("Load Ads - " + interstitalAd.IsLoaded().ToString());
        }
#endif
        }
    }

    public void ShowInterstitialAd()
    {
        if (timeAds < GameConfig.Instance.timeInterAds)
        {
            return;
        }

        if (interstitalAd != null && !isShowAds)
        {
            if (interstitalAd.IsLoaded())
            {
                interstitalAd.Show();
                isShowAds = true;
                isLoadAds = false;
                timeAds = 0;
                Debug.Log("Show Ads");
            }
        }
        else
        {
            Debug.Log("Null");
        }
    }



    #endregion

    #region ===UNITY ADS===
    public void ShowAdsUnity()
    {
        //#if UNITY_EDITOR
        //        StartCoroutine(WaitForAd());
        //#endif
        if (Advertisement.IsReady())
        {
            Advertisement.Show(GameConfig.Instance.nameVideoUnityAds, new ShowOptions() { resultCallback = HandleUnityAdsCallback });
        }
    }

    IEnumerator WaitForAd()
    {

        while (Advertisement.isShowing)
            yield return null;

    }

    void HandleUnityAdsCallback(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Time.timeScale = 1;
                timeVideo = 0;
                GameManager.Instance.main.dollars += GameConfig.Instance.dollarVideoUnityAds;
                Invoke("HidePanelInfo", 2f);
                break;
            case ShowResult.Skipped:
                Time.timeScale = 1;
                timeVideo = 0;
                //GameManager.Instance.main.dollars += GameConfig.Instance.dollarVideoUnityAds/2;                
                break;
            case ShowResult.Failed:
                Time.timeScale = 1;
                break;
        }
    }
    void HidePanelInfo()
    {
        GameManager.Instance.HidePanelInfo();
    }
    #endregion


}
