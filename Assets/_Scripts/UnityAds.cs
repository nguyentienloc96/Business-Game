using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
//    public static UnityAds uads;

//    public string idAndroid;
//    public string idIos;

//    void Awake()
//    {
//        DontDestroyOnLoad(gameObject);
//        uads = this;
       
//#if UNITY_ANDROID
//        Advertisement.Initialize(idAndroid, true);
//#elif UNITY_IOS
//         Advertisement.Initialize(idIos, true);
//#endif
//    }

//    public void ShowAd(string zone = "")
//    {
//#if UNITY_EDITOR
//        StartCoroutine(WaitForAd());
//#endif

//        ShowOptions options = new ShowOptions();
//        options.resultCallback = AdCallbackhandler;

//        if (Advertisement.IsReady(zone))
//            Advertisement.Show(zone, options);
//    }

//    void AdCallbackhandler(ShowResult result)
//    {
//        switch (result)
//        {
//            case ShowResult.Finished:
//                Debug.Log("Ad Finished. Rewarding player...");
//                break;
//            case ShowResult.Skipped:
//                Debug.Log("Ad skipped. Son, I am dissapointed in you");
//                break;
//            case ShowResult.Failed:
//                Debug.Log("I swear this has never happened to me before");
//                break;
//        }
//    }

//    IEnumerator WaitForAd()
//    {

//        while (Advertisement.isShowing)
//            yield return null;

//    }
}