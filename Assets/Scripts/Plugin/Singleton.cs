using UnityEngine;
using System.Collections;

public class SingletonMono<T>:MonoBehaviour where T: SingletonMono<T>,new()
{
    private static T instance;
    public static T GetInstance() 
    {

        if (instance == null)
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (instance == null)
            {
                instance = new GameObject("_" + typeof(T).Name).AddComponent<T>();
            }
        }
        return instance;
    
    }
}
public class Singleton<T> where T : Singleton<T> ,new ()
{
    private static T instance;
    public static T GetInstance() 
    {
        if (null == instance)
        {
            instance = new T();
        }
        return instance;
    }

}
