using UnityEngine;

public class ConvertNumber : MonoBehaviour {
    //public static string convertNumber_DatDz(long number)
    //{
    //    string current = "";
    //    long curentNumber = 0;

    //    if (number < 1000 && number >= 0)
    //        current = number.ToString();
    //    else if (number < 10000 && number >= 1000)
    //    {
    //        string a = "";
    //        a = number.ToString();
    //        current = ((long)(number / 1000f)).ToString() + "," + a.Substring(1, a.Length - 1);
    //        //Debug.Log("convert" + current);
    //    }
    //    else if (number >= 10000 && number < 100000)
    //    {
    //        string a = "";
    //        a = number.ToString();
    //        a = current.Substring(0, 2) + "," + current.Substring(2, 3);
    //    }
    //    else if (number >= 10000 && number < 1000000)
    //    {
    //        curentNumber = (long)(number / 1000);
    //        current = _toPrettyString(curentNumber) + "K";
    //    }
    //    else if (number >= 1000000 && number < 1000000000)
    //    {
    //        curentNumber = (long)(number / 1000000);
    //        current = _toPrettyString(curentNumber) + "M";
    //    }
    //    else
    //    {
    //        curentNumber = (long)(number / 1000000000);
    //        current = _toPrettyString(curentNumber) + "B";
    //    }
    //    return current.Trim();
    //}

    //public static string _toPrettyString(long number)
    //{
    //    string current = "";
    //    if (number != 0)
    //    {
    //        current = string.Format("{0:0,0}", number);
    //    }
    //    else
    //    {
    //        current = "0";
    //    }
    //    return current.Trim();

    //}

    public static string convertNumber_DatDz(long number)
    {
        string smoney = string.Format("{0:n0}", number);
        if (smoney.Length >= 9 && smoney.Length < 13)
        {
            smoney = smoney.Substring(0, smoney.Length - 4);
            smoney = smoney + "K";
        }
        else if (smoney.Length >= 13 && smoney.Length < 17)
        {
            smoney = smoney.Substring(0, smoney.Length - 8);
            smoney = smoney + "M";
        }
        else if (smoney.Length >= 17 && smoney.Length < 21)
        {
            smoney = smoney.Substring(0, smoney.Length - 12);
            smoney = smoney + "B";
        }
        else if (smoney.Length >= 21)
        {
            smoney = smoney.Substring(0, smoney.Length - 16);
            smoney = smoney + "KB";
        }
        return smoney;
    }
}
