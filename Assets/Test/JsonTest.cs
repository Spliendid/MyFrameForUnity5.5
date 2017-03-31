using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
public class JsonTest : MonoBehaviour {
    string Path;
    string Path2;
	// Use this for initialization
	void Start () {
        Path = Application.dataPath + "/Assets_Json.txt";
        Path2 = Application.dataPath + "/InstObj_Json.txt";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //加载Asset
    [ContextMenu("下载Asset")]
    private void LoadTest() 
    {
        StartCoroutine(llll());
    }

    private IEnumerator llll()
    {
       AssetBundle ab;
   // AssetBundle ab=   AssetBundle.LoadFromFile(Application.streamingAssetsPath+"/"+"NewAB"+"/dimian.assetbundle");
       WWW www = new WWW("file://" + Application.streamingAssetsPath + "/" + "NewAB" + "/dimian");
     yield return www;
      ab = www.assetBundle;
        yield return ab;
     GameObject.Instantiate(ab.mainAsset);
        yield return null;
    }


    [SerializeField]
    List<InstantObj> list;
    [ContextMenu("生成Json")]
    private void WriteJson()
    {
        StartCoroutine(CreatJson());
    }
    private IEnumerator CreatJson()
    {
        InstantObj obj1 = new  InstantObj();
        //obj1.isResetTransform = true;
        obj1.localPos = new MyVector3(1f,1f,1f);
        obj1.LocalEuler = new MyVector3(0f,90f,0f);
        obj1.Name = "SceneObj";
        
        InstantObj obj2 = new InstantObj();
        //obj2.isResetTransform = true;
        obj2.localPos = new MyVector3(1f, 1f, 1f);
        obj2.LocalEuler = new MyVector3(0f, 90f, 0f);
        obj2.Name = "refenglu";
        obj1.FatherName = "SceneObj";
        list = new List<InstantObj> { obj1,obj2};

        string jsonstr = JsonMapper.ToJson(list);
        yield return jsonstr;
        Debug.Log(jsonstr);
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonstr);
        yield return data;
        File.WriteAllBytes(Path2, data);
    }
    [ContextMenu("获取Json内容")]
    private void GetJson()
    {
        string json = File.ReadAllText(Path2);
        Debug.Log(json);
        list = JsonMapper.ToObject<List<InstantObj>>(json);
        //StartCoroutine(IE_GetJson());
    }
    private IEnumerator IE_GetJson()
    {
        string json = File.ReadAllText(Path);
        yield return json;
        list = JsonMapper.ToObject<List<InstantObj>>(json);
        yield return list;
    }

//    [SerializeField]
//    List<AssetManager> list;
//    [ContextMenu("生成Json")]
//    private void WriteJson() 
//    {
//        StartCoroutine(CreatJson());
//    }
//    private IEnumerator CreatJson()
//    {
//        Asset asset1 = new Asset();
//        asset1.Path = "Assetbundle/fangzi.assetbudle";
//        asset1.AssetsName = "fangzi";
//        Asset asset2 = new Asset();
//        asset2.Path = "Assetbundle/004_360-panoramas.assetbudle";
//        asset2.AssetsName = "004_360-panoramas";

//        AssetManager manager1 = new AssetManager(asset1);
//        AssetManager manager2 = new AssetManager(asset2);
//       list= new List<AssetManager> { manager1,manager2};
//        string jsonstr = JsonMapper.ToJson(list);
//        yield return jsonstr;
//        Debug.Log(jsonstr);
//        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonstr);
//        yield return data;
//        File.WriteAllBytes(Path,data);
//    }

//    [ContextMenu("获取Json内容")]
//    private void GetJson() 
//    {
//        string json = File.ReadAllText(Path);
//        Debug.Log(json);
//        list = JsonMapper.ToObject<List<AssetManager>>(json);
//        //StartCoroutine(IE_GetJson());
//    }
//    private IEnumerator IE_GetJson() 
//    {
//        string json = File.ReadAllText(Path);
//        yield return json;
//        list = JsonMapper.ToObject<List<AssetManager>>(json);
//        yield return list;
//    }
//    [ContextMenu("加载Asset")]
//private void  GetAsset()
//{
//    AssetsLoader.GetInstance().L_assetManager = list;
//    StartCoroutine(AssetsLoader.GetInstance().IE_LoadAsset());
//}
}
