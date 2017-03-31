
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InstantiateManager:Singleton<InstantiateManager>
{
    private List<InstantObj> instantObjList;
    private Dictionary<string, InstantObj> InstantObjDic = new Dictionary<string,InstantObj>();
    #region 获取instantObjList
    private IEnumerator IE_GetinstantList() 
    {
        string Path = Application.streamingAssetsPath+"/"+ConstantClass.InstObj_JsonPath;
        string JsonStr= ToolsScripts.ReadTXT(Path);
        yield return JsonStr;
        instantObjList = ToolsScripts.GetJsonObj<List<InstantObj>>(JsonStr);
        yield return instantObjList;
        //获取InstantDic
        foreach (var item in instantObjList)
        {
            InstantObjDic.Add(item.Name,item);
        }
        foreach (var item in instantObjList)
        {
            if (null!=item.FatherName)
            {
                item.FatherObj= InstantObjDic[item.FatherName];
            }
        }
    }
    #endregion

    #region 实例化InstantObj
    //根据InstantObj内的信息实例化AssetsLoader内已经加载好的资源
    private IEnumerator IE_InstantObj(InstantObj item) 
    {
       
          
            GameObject go = GameObject.Instantiate(AssetsLoader.GetInstance().GetAssetObj(item.Name)) as GameObject;
            yield return go;
            if (item.FatherObj == null)
            {
                
            }
            else if ( PublicData.MainObjDic.ContainsKey(item.FatherName))
            {
                go.transform.SetParent(PublicData.MainObjDic[item.FatherName].transform);
            }
            else {
                yield return ToolsScripts.StartCoroutine(IE_InstantObj(item.FatherObj));
            }

            if (null!=item.localPos)
            {
                go.transform.localPosition = item.localPos.ConvertV3();
            }
            if (null != item.LocalEuler)
            {
                go.transform.localRotation = Quaternion.Euler(item.LocalEuler.ConvertV3());
            }
            if (null !=item.LocalScale)
            {
                go.transform.localScale = item.LocalScale.ConvertV3();
            }
           
            PublicData.MainObjDic.Add(item.Name,go);
       
        yield return null;
    }
    #endregion

    #region 外部调用
    //实例化并获取obj
    public IEnumerator IE_InstantiateObjMain() 
    {
        yield return ToolsScripts.StartCoroutine(IE_GetinstantList());
        foreach (var item in instantObjList)
        {
            if (null==item) continue;
           yield return ToolsScripts.StartCoroutine(IE_InstantObj(item));//可等待也可不等待
        }
        yield return null;
    }
    //添加组件 并获取
    public IEnumerator IE_AddComponent() 
    {
     // PublicData._MainSceneObjScript =   PublicData.MainObjDic[ConstantClass.MianSecneObjName].AddComponent<MainSceneObjScript>();

        yield return null;
    }
    #endregion
}
