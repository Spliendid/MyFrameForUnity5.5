using UnityEngine;
using System.Collections;
public class SecendLevelMono
{
    #region MyRegion
    protected bool isInitComplete = false;
    #endregion

    #region Mono
    public void Awake()
    {

    }
    // Use this for initialization
    public void Start()
    {
        Init();
    }

    // Update is called once per frame
    public void Update()
    {
        if (isInitComplete)
        {

        }
    }
    #endregion
   

    #region 初始化
  protected void Init() 
  {
      ToolsScripts.StartCoroutine(InitManage());
  }
  protected IEnumerator InitManage() 
  {
      yield return ToolsScripts.StartCoroutine(LoadAssets());
      Debug.Log("<color=red>LoadAssetsComplete</color>");
      yield return ToolsScripts.StartCoroutine(IE_InstantAndAddC());
      Debug.Log("<color=red>AddComponentComplete</color>");
      yield return ToolsScripts.StartCoroutine(IE_DataInit());
      Debug.Log("<color=red>DataInitComplete</color>");
      isInitComplete = true;
  }
    //加载资源
  protected IEnumerator LoadAssets() 
  {

      yield return ToolsScripts.StartCoroutine(AssetsLoader.GetInstance().IE_LoadAsset());
      yield return null; 
  }
   
    //实例化添加组件
  protected IEnumerator IE_InstantAndAddC() 
  {
      yield return ToolsScripts.StartCoroutine(InstantiateManager.GetInstance().IE_InstantiateObjMain());
      yield return ToolsScripts.StartCoroutine(InstantiateManager.GetInstance().IE_AddComponent());
      yield return null; 
  }
  
    //数据脚本初始化
  protected IEnumerator IE_DataInit() 
  {
      yield return ToolsScripts.StartCoroutine(DataInit.GetInstance().IE_DataInit());
      yield return null; 
  }
    #endregion


}
