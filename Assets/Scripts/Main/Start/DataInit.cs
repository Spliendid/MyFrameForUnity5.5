using UnityEngine;
using System.Collections;

public class DataInit : Singleton<DataInit>
{
    #region 外部调用
    public IEnumerator IE_DataInit() 
    {
        if (null!=PublicData._MainSceneObjScript)
        {
        yield return ToolsScripts.StartCoroutine(PublicData._MainSceneObjScript.IE_Init());
        }
        yield return null;
    }
    #endregion
}
