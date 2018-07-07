﻿using UnityEngine;

public class ConvertNumber : MonoBehaviour {
    public static string convertNumber_DatDz(long number)
    {
        string current = "";
        long curentNumber = 0;

        if (number < 1000 && number >= 0)
            current = number.ToString();
        else if (number < 10000 && number >= 1000)
        {
            string a = "";
            a = number.ToString();
            current = ((long)(number / 1000f)).ToString() + "," + a.Substring(1, a.Length - 1);
            //Debug.Log("convert" + current);
        }
        //else if (number >= 10000 && number < 100000)
        //{
        //    string a = "";
        //    a = number.ToString();
        //    a = current.Substring(0, 2) + "," + current.Substring(2, 3);
        //}
        //else if (number >= 10000 && number < 1000000)
        //{
        //    curentNumber = (long)(number / 1000);
        //    current = _toPrettyString(curentNumber) + "K";
        //}
        else if (number >= 1000000 && number < 1000000000)
        {
            curentNumber = (long)(number / 1000000);
            current = _toPrettyString(curentNumber) + "M";
        }
        else
        {
            curentNumber = (long)(number / 1000000000);
            current = _toPrettyString(curentNumber) + "B";
        }
        return current.Trim();
    }

    public static string _toPrettyString(long number)
    {
        string current = "";
        if (number != 0)
        {
            current = string.Format("{0:0,0}", number);
        }
        else
        {
            current = "0";
        }
        return current.Trim();

    }
}
