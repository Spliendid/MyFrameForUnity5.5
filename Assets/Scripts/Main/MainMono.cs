using UnityEngine;
using System.Collections;

public class MainMono : SingletonMono<MainMono> {

    private SecendLevelMono secendMono = new SecendLevelMono();
    // Use this for initialization
    void Awake()
    {
        secendMono.Awake();
    }

    void Start()
    {
        secendMono.Start();
    }

    // Update is called once per frame
    void Update()
    {
        secendMono.Update();
    }

    void OnDisable() 
    {

    }
}
