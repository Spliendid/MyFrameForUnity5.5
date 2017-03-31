using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;


public class ToolsScripts
{

    #region Json
    public static T GetJsonObj<T>(string json) 
    {
        return JsonMapper.ToObject<T>(json);
    }
    #endregion

    #region 协程

    #region 开启协程（在MainMono上）
    public static Coroutine StartCoroutine(IEnumerator IE)
    {
        return MainMono.GetInstance().StartCoroutine(IE);
    }
    #endregion

    #region 停止协程（MainMono上的某一协程）
    public static void StopCoroutine(IEnumerator IE) 
    {
        MainMono.GetInstance().StopCoroutine(IE);
    }
    public static void StopCoroutine(Coroutine coroutine)
    {
        MainMono.GetInstance().StopCoroutine(coroutine);
    }
    public static void StopCoroutine(string  IEName)
    {
        MainMono.GetInstance().StopCoroutine(IEName);
    }
    #endregion

    #region 通用协程
    public static void StartCoroutine() 
    {
    }
    #endregion

    #endregion

    #region FileIO

    #region TXT读取
    public static string ReadTXT(string Path) 
    {
        return File.ReadAllText(Path);
    }
    #endregion

    #endregion

}
