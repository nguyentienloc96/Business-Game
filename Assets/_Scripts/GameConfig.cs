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
        DontDestroyOnLoad(this);
    }

    public float timeScale = 4;
    public double dollarStartGame = 50000;
    public double bitcoinStartGame = 10;

    public int srd;
    public float timeInterAds;
    public double InMin = 10000;
    public double InMax = 50000;
    public float Ipc = 0.1f;

    public int dTime;

    public float HP_ext;
    public float TC_tax;
    public float TC_wx;
    public float SC_ax;
    public float SC_bx;
    public float SC_ox;
}
