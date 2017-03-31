
using UnityEngine;
using System.Collections;

public class MainSceneObjScript : SingletonMono<MainSceneObjScript>
{

    public IEnumerator IE_Init() 
    {
        yield return null;
        Debug.Log("MainSceneObjScriptInitComplete");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
