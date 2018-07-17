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
    //public string idInter_Android;
    //public string idInter_IOS;

    [Header("UnityAds")]
    //public string idUnityAds_Android;
    //public string idUnityAds_IOS;
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
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        //RequestBanner();
        //RequestAd();
        //ShowBanner();

        //Unity Ads
        //Advertisement.Initialize(idUnityAds, false);
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
        //interstitalAd.OnAdClosed += HandleOnAdClosed;

        if (timeAds >= 60 && timeAds < 90)
        {
            RequestAd();
        }
        else if (timeAds >= GameConfig.Instance.timeInterAds)
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
        #if UNITY_ANDROID
        GameConfig.Instance.id_inter_android = "ca-app-pub-6285794272989840/5632501293";
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
        if (interstitalAd != null)
        {
            if (interstitalAd.IsLoaded())
            {
                interstitalAd.Show();
                isShowAds = true;
                isLoadAds = false;
                timeAds = 0;
                Debug.Log("Show Ads");
            }
            else
            {
                RequestAd();
                ShowInterstitialAd();
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
