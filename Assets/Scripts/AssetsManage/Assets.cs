using UnityEngine;
using System.Collections;
[System.Serializable]
public class Asset 
{
    public E_AssetsType assetsType;//资源类型
    public string AssetsName;
    public string Path;
   // [System.NonSerialized]
  //  public AssetBundle ab;
   
}

[System.Serializable]
public class AssetManager 
{
    private Object assetObj;   
    public  Asset asset;
    public AssetManager() 
    {

    }

    public AssetManager(Asset asset) 
    {
        this.asset = asset;
    }
    public string Name {
        get {
            return this.asset.AssetsName;
        }
    }

    //加载Asset(旧版的Asset加载)
    public IEnumerator IE_GetAsset() 
    {

      
          string LoadPath = "file://" + Application.streamingAssetsPath + "/" + asset.Path;
         WWW www = new WWW(LoadPath);
            yield return www;
            //asset.ab = www.assetBundle;
            assetObj = www.assetBundle.mainAsset;
          www.assetBundle.Unload(false);
          if (null != assetObj)
          {
            //  Debug.Log(asset.AssetsName + "LoadComplete");
          }
        
    }

    //public IEnumerator IE_NewGetAsset()
    //{
    //    //加载Mainifest文件

    //    AssetBundle mainfestBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/Windows/Windows");

    //    if (null != mainfestBundle)
    //    {
    //        AssetBundleManifest manifest = (AssetBundleManifest)mainfestBundle.LoadAsset("AssetBundleManifest");

    //        Debug.Log(manifest == null);
    //        //获取依赖文件列表;  
    //        string[] cubedepends = manifest.GetAllDependencies(asset.AssetsName + ".data");

    //        //Debug.Log(cubedepends.Length);
    //        //foreach (var item in cubedepends)
    //        //{
    //        //    Debug.Log("depends " + item);
    //        //}
    //        AssetBundle[] dependsAssetbundle = new AssetBundle[cubedepends.Length];

    //        for (int index = 0; index < cubedepends.Length; index++)
    //        {
    //            //加载所有的依赖文件;  
    //            dependsAssetbundle[index] = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/Windows/" + cubedepends[index]);
    //            yield return dependsAssetbundle[index];
    //        }
    //        // DateTime t1 = DateTime.Now;

    //        //加载我们需要的文件;"  
    //        AssetBundle cubeBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + asset.Path);
    //        yield return cubeBundle;
    //        Debug.Log(cubeBundle == null);
    //        assetObj = cubeBundle.LoadAsset(Name);
    //        if (null != assetObj)
    //        {
    //            Debug.Log(asset.AssetsName + "LoadComplete");
    //        }
    //    }
    //}



    public IEnumerator IE_NewGetAsset()
    {
        //加载Mainifest文件
        string _LoadPath = Application.streamingAssetsPath + "/Windows/Windows";

        AssetBundle mainfestBundle;

        if (!AssetsLoader.GetInstance().assetBundleLoadDic.ContainsKey(_LoadPath))
        {
            yield return ToolsScripts.StartCoroutine(AssetsLoader.GetInstance().IE_LoadABToDic(_LoadPath));
        }
        else 
        {
            yield return new WaitUntil(()=>AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath]);
        }
        mainfestBundle = AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath];


        if (null != mainfestBundle)
        {
            AssetBundleManifest manifest = (AssetBundleManifest)mainfestBundle.LoadAsset("AssetBundleManifest");

            Debug.Log(manifest == null);
            //获取依赖文件列表;  
            string[] cubedepends = manifest.GetAllDependencies(asset.AssetsName + ".data");

            AssetBundle[] dependsAssetbundle = new AssetBundle[cubedepends.Length];

            for (int index = 0; index < cubedepends.Length; index++)
            {
                _LoadPath = Application.streamingAssetsPath + "/Windows/" + cubedepends[index];
                //加载所有的依赖文件;  

                if (!AssetsLoader.GetInstance().assetBundleLoadDic.ContainsKey(_LoadPath))
                {
                    yield return ToolsScripts.StartCoroutine(AssetsLoader.GetInstance().IE_LoadABToDic(_LoadPath));
                }
                else
                {
                    yield return new WaitUntil(() => AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath]);
                }
                dependsAssetbundle[index] = AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath];

           
            }
            // DateTime t1 = DateTime.Now;

            //加载我们需要的文件;"  
            _LoadPath = Application.streamingAssetsPath + "/" + asset.Path;
            if (!AssetsLoader.GetInstance().assetBundleLoadDic.ContainsKey(_LoadPath))
            {
                yield return ToolsScripts.StartCoroutine(AssetsLoader.GetInstance().IE_LoadABToDic(_LoadPath));
            }
            else
            {
                yield return new WaitUntil(() => AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath]);
            }
            AssetBundle Bundle = AssetsLoader.GetInstance().assetBundleLoadDic[_LoadPath];
         
          
            assetObj = Bundle.LoadAsset(Name);
            yield return assetObj;
            if (null != assetObj)
            {
                Debug.Log(asset.AssetsName + "LoadComplete");
            }
        }
    }

    public Object GetAsset() 
    {
        if (null!=assetObj)
        {
            return assetObj;
        }
        Debug.Log(string.Format("<color=red>{0}:\tLoadAssetError</color>",asset.AssetsName));
        return null;
    }
}
