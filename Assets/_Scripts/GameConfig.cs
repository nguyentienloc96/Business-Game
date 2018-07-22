using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static GameConfig Instance = new GameConfig();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    public float timeScale = 4;
    public long dollarStartGame = 50000;
    public long bitcoinStartGame = 10;
    public string stringStart;
    public string linkGame_android;
    public string linkGame_ios;

    public float timeInterAds;
    public string id_inter_android;
    public string id_inter_ios;
    public string id_video_android;
    public string id_video_ios;
    public string id_video_android_admob;
    public string id_video_ios_admob;
    public string nameVideoUnityAds;
    public long dollarVideoUnityAds;
    public float timeVideoAds;
    public long InMin = 10000;
    public long InMax = 50000;
    public float Ipc = 0.1f;

    public int dTime;

    public float HP_ext;
    public float TC_tax;
    public float TC_wx;
    public float TC_vx;
    public float SC_ax;
    public float SC_bx;
    public float SC_ox;
    public long PP_rdb;
    public long PP_f_Min;
    public float PP_fxi;
    public float PP_o;
    public long PP_b_Min;
    public float PP_bxi;
    public long SR_b_Min;
    public float SR_bp;
    public int Ads_t;
    public float Ads_w;
    public float Bx;

    public int TL_sp;
    public int TL_mkt;
    public int TL_maket;
    public int TL_lo;
    public int TL_ns;
    public int TL_kh;
    public int TL_st;

    public int HR_ph;
    public int HR_cc;
    public int HR_ae;
    public int HR_ic;

    public int s;

    public float Srd_easy;
    public float Srd_medium;
    public float Srd_hard;
    public float Srd_crazy;
}
