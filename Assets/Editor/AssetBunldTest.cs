/*
 * 旧版AssetBundle打包脚本
 */

//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//public class AssetBunldTest : Editor
//{
//    //打包主要资源
//    [MenuItem("Custom Editor/Create AssetBunldes Main")]
//    static void CreateAssetBunldesMain()
//    {
//        //获取在Project视图选择的所有游戏对象
//        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//        //遍历所有的游戏对象
//        foreach (Object obj in SelectedAsset)
//        {
            
//            string targetPath = Application.dataPath + "/StreamingAssets/Assetbundle/" + obj.name + ".assetbundle";
//            //参数1：要打包的对象 因为这里分别打包 通过循环将每个对象分别放在这里  
//            //参数2：可以放入一个数组对象
//            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))
//            {
//                Debug.Log(obj.name + "资源打包成功");
//            }
//            else
//            {
//                Debug.Log(obj.name + "资源打包失败");
//            }
//        }
//        AssetDatabase.Refresh();//刷新编辑器

//    }

//    //打包所有资源
//    [MenuItem("Custom Editor/Create AssetBunldes ALL")]
//    static void CreateAssetBunldesALL()
//    {
//        Caching.CleanCache();//清空缓存
//        string Path = Application.dataPath + "StreamingAssets/Assetbundle/ALL.assetbundle";
//        //获取在Project视图选择的所有游戏对象
//        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//        foreach (Object obj in SelectedAsset)
//        {
//            Debug.Log("创建一个资源包的名字" + obj);
//        }
//        if (BuildPipeline.BuildAssetBundle(null, SelectedAsset, Path, BuildAssetBundleOptions.CollectDependencies))
//        {
//            AssetDatabase.Refresh();//刷新编辑器
//        }
//        else
//        {

//        }
//    }

//    //在Unity编辑器中添加菜单  
//    [MenuItem("Assets/Build AssetBundle From Selection")]
//    static void ExportResourceRGB2()
//    {
//        // 打开保存面板，获得用户选择的路径  
//        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "assetbundle");

//        if (path.Length != 0)
//        {
//            // 选择的要保存的对象  
//            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//            //打包  
//            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
//        }
//    }

//    //保存场景
//    [MenuItem("Custon Editor/Save Scene")]
//    static void ExportScene()
//    {
//        // 打开保存面板 获取用户选择的路径
//        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
//        if (path.Length != 0)
//        {
//            //选择要保存的对象
//            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//            string[] scenes = { "Assets/myScene.unity" };
//            //打包
//            BuildPipeline.BuildPlayer(scenes, path, BuildTarget.StandaloneWindows, BuildOptions.BuildAdditionalStreamedScenes);

//        }
//        AssetDatabase.Refresh();
//    }




//    [MenuItem("Assets/Save Scene")]
//    static void ExportScene2()
//    {
//        // 打开保存面板，获得用户选择的路径  
//        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");

//        if (path.Length != 0)
//        {
//            // 选择的要保存的对象  
//            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//            string[] scenes = { "Assets/scene1.unity" };
//            //打包  
//            BuildPipeline.BuildPlayer(scenes, path, BuildTarget.StandaloneWindows, BuildOptions.BuildAdditionalStreamedScenes);
//        }
//    }
//    //
//    [MenuItem("Custom Editor/Save Scene2")]
//    static void ExportResource()
//    {
//        //打开保存面板
//        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
//        if (path.Length != 0)
//        {

//            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
//            Selection.objects = selection;

//        }
//    }

//}
