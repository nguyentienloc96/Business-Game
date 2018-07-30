using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    [Header("Admob")]
    InterstitialAd interstitalAd;
    RewardBasedVideoAd rewardVideo;

    [Header("UnityAds")]
    //public GameObject buttonVideo;
    bool isLoadAds = false;
    //bool isShowAds = false;

    [Header("Time")]
    public float timeAds = 1;
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
        RequestAd();
        this.rewardVideo = RewardBasedVideoAd.Instance;
        //rewardVideo.OnAdClosed += HandleRewardBasedVideoClosed;
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

        //if (timeVideo >= GameConfig.Instance.timeVideoAds)
        //{
        //    //Hiện nút xem video
        //}
    }

    #region ===ADMOB===


    public void RequestAd()
    {
        if (timeAds >= 0 && timeAds <= GameConfig.Instance.timeInterAds / 1.5f)
        {
#if UNITY_ANDROID
        GameConfig.Instance.id_inter_android = "ca-app-pub-6285794272989840/5632501293"; //test
        if (!isLoadAds && GameConfig.Instance.id_inter_android != null)
        {
            interstitalAd = new InterstitialAd(GameConfig.Instance.id_inter_android);
            AdRequest requestInterAd = new AdRequest.Builder().Build();
            interstitalAd.LoadAd(requestInterAd);                      
            isLoadAds = true;
            Debug.Log("Load Ads - "+ interstitalAd.IsLoaded().ToString());
        }
#elif UNITY_IOS
            if (!isLoadAds && GameConfig.Instance.id_inter_ios != null)
            {
                interstitalAd = new InterstitialAd(GameConfig.Instance.id_inter_ios);
                AdRequest requestInterAd = new AdRequest.Builder().Build();
                interstitalAd.LoadAd(requestInterAd);
                isLoadAds = true;
                Debug.Log("Load Ads - " + interstitalAd.IsLoaded().ToString());
            }
#else
            GameConfig.Instance.id_inter_android = "ca-app-pub-6285794272989840/5632501293"; //test
            if (!isLoadAds && GameConfig.Instance.id_inter_android != null)
            {
                interstitalAd = new InterstitialAd(GameConfig.Instance.id_inter_android);
                AdRequest requestInterAd = new AdRequest.Builder().Build();
                interstitalAd.LoadAd(requestInterAd);
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

        if (interstitalAd != null)
        {
            if (interstitalAd.IsLoaded())
            {
                interstitalAd.Show();
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

    //public void RequestRewardVideo()
    //{
    //    if (timeVideo >= 0 && timeVideo < GameConfig.Instance.timeVideoAds / 1.5f)
    //    {
    //        if (!rewardVideo.IsLoaded())
    //        {
    //            AdRequest request = new AdRequest.Builder().Build();
    //            this.rewardVideo.LoadAd(request, GameConfig.Instance.id_inter_android);
    //        }
    //    }
    //}
    //public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    //{
    //    Time.timeScale = 1;
    //    timeVideo = 0;
    //    GameManager.Instance.main.dollars += GameConfig.Instance.dollarVideoUnityAds;
    //    WorldManager.Instance.panelInfo.SetActive(true);
    //    WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "You just received " + ConvertNumber.convertNumber_DatDz(GameConfig.Instance.dollarVideoUnityAds) + "$ ";
    //    UIManager.Instance.panelDollars.SetActive(false);
    //    Invoke("HidePanelInfo", 2f);
    //}

    #endregion

    #region ===UNITY ADS===
    public void ShowAdsUnity()
    {
        //#if UNITY_EDITOR
        //        StartCoroutine(WaitForAd());
        //#endif
        if (timeVideo < GameConfig.Instance.timeVideoAds)
        {
            WorldManager.Instance.panelInfo.SetActive(true);
            WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "Ads is not ready";
            Invoke("HidePanelInfo", 2f);
            //return;
        }
        else
        {
            //if (Advertisement.IsReady())
            //{
            //    Advertisement.Show(GameConfig.Instance.nameVideoUnityAds, new ShowOptions() { resultCallback = HandleUnityAdsCallback });
            //}
            //else
            //{
            //    Debug.Log(Advertisement.IsReady());
                ShowInterstitialAd();
            //}
        }
    }

    //IEnumerator WaitForAd()
    //{

    //    while (Advertisement.isShowing)
    //        yield return null;

    //}

    //void HandleUnityAdsCallback(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Time.timeScale = 1;
    //            timeVideo = 0;
    //            GameManager.Instance.main.dollars += GameConfig.Instance.dollarVideoUnityAds;
    //            WorldManager.Instance.panelInfo.SetActive(true);
    //            WorldManager.Instance.panelInfo.transform.GetChild(0).GetComponent<Text>().text = "You just received " + ConvertNumber.convertNumber_DatDz(GameConfig.Instance.dollarVideoUnityAds) + "$ ";
    //            UIManager.Instance.panelDollars.SetActive(false);
    //            Invoke("HidePanelInfo", 2f);
    //            break;
    //        case ShowResult.Skipped:
    //            Time.timeScale = 1;
    //            timeVideo = 0;
    //            //GameManager.Instance.main.dollars += GameConfig.Instance.dollarVideoUnityAds/2;                
    //            break;
    //        case ShowResult.Failed:
    //            Time.timeScale = 1;
    //            break;
    //    }
    //}
    void HidePanelInfo()
    {
        GameManager.Instance.HidePanelInfo();
    }
    #endregion
    private void OnDestroy()
    {
        if (UIManager.Instance.indexScene != -1)
        {
            DataPlayer.Instance.SaveDataPlayer();
            PlayerPrefs.SetInt("isData", 1);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            if (UIManager.Instance.indexScene != -1)
            {
                DataPlayer.Instance.SaveDataPlayer();
                PlayerPrefs.SetInt("isData", 1);
            }
        }
        else
        {
            if (UIManager.Instance.indexScene == -1)
            {
                if (PlayerPrefs.GetInt("isData") == 0)
                {
                    UIManager.Instance.btnContinue.interactable = false;
                }
                else
                {
                    UIManager.Instance.btnContinue.interactable = true;
                }
            }
        }
    }

}
