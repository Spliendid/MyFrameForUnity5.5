using UnityEngine;
using UnityEditor;

public class MyABBuilder : ScriptableObject
{
    public static string OutPutPath = "Assets/StreamingAssets/NewAB";
    [MenuItem("Tools/BuilderSelectedAsset")]
    static void BuildMapABs()
    {
        Object[] objs = Selection.GetFiltered(typeof(Object),SelectionMode.DeepAssets);
        foreach (var obj in objs)
	    {
		 string SelectPAth = AssetDatabase.GetAssetOrScenePath(obj);
        // Create the array of bundle build details.
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        buildMap[0].assetBundleName = obj.name;

        string[] MainAsset = new string[1];
        MainAsset[0] =SelectPAth;

        buildMap[0].assetNames = MainAsset;


        BuildPipeline.BuildAssetBundles(OutPutPath, buildMap, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows);
	    }
        
    }
}