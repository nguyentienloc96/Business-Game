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
    //BannerView bannerView;
    public string idInter;

    [Header("UnityAds")]
    public string idUnityAds_Android;
    public string idUnityAds_IOS;
    bool isLoadAds = false;
    bool isShowAds = false;

    [Header("Time")]
    public float timeAds;
    public float timeVideo;

    //public GameObject btnUnityAds;

    public static Ads Instance = new Ads();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        //RequestBanner();
        RequestAd();
        //ShowBanner();

        //Unity Ads
        //Advertisement.Initialize(idUnityAds, false);
#if UNITY_ANDROID
        //Advertisement.Initialize(idUnityAds_Android, true);
#elif UNITY_IOS
         Advertisement.Initialize(idUnityAds_IOS, true);
#endif
    }

    void Update()
    {
        timeAds += Time.deltaTime;
        timeVideo += Time.deltaTime;
        interstitalAd.OnAdClosed += HandleOnAdClosed;

        if (timeAds >= 60 && timeAds < 150)
        {
            RequestAd();
        }
        else if (timeAds >= 150)
        {
            ShowInterstitialAd();
        }

        if(timeVideo >= 120)
        {
            //Hiện nút xem video
        }
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //AudioManager.Instance.StopGameMusic();
        //AudioManager.Instance.PlayGameMusic();
        Time.timeScale = 1;
    }

    #region ===ADMOB===
    //public void RequestBanner()
    //{
    //    if (idBanner != null)
    //    {
    //        bannerView = new BannerView(idBanner, AdSize.SmartBanner, AdPosition.Bottom);
    //        //bannerView = new BannerView(idBanner, AdSize.SmartBanner, 0,-520);
    //        AdRequest requestBanner = new AdRequest.Builder().Build();
    //        bannerView.LoadAd(requestBanner);
    //        Debug.Log("Load Banner");
    //    }
    //}

    public void RequestAd()
    {
        if (isLoadAds == false && idInter != null)
        {
            interstitalAd = new InterstitialAd(idInter);
            AdRequest requestInterAd = new AdRequest.Builder().Build();
            interstitalAd.LoadAd(requestInterAd);
            isLoadAds = true;
            isShowAds = false;
            Debug.Log("Load Ads");
        }
    }

    //public void ShowBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Show();
    //        Debug.Log("Show Banner");
    //    }
    //}

    //public void HideBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Hide();
    //    }
    //}

    public void ShowInterstitialAd()
    {
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
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleUnityAdsCallback });
        //}
    }

    IEnumerator WaitForAd()
    {

        //while (Advertisement.isShowing)
            yield return null;

    }

    //void HandleUnityAdsCallback(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Time.timeScale = 1;
    //            timeVideo = 0;
    //            //GamePlay.gameplay.btnContinue.SetActive(false);
    //            break;
    //        case ShowResult.Skipped:
    //            Time.timeScale = 1;
    //            timeVideo = 0;
    //            //amePlay.gameplay.btnContinue.SetActive(false);
    //            break;
    //        case ShowResult.Failed:
    //            Time.timeScale = 1;

    //            break;
    //    }
    //}
    #endregion


}
