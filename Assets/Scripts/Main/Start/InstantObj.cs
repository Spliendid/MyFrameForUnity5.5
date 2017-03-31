
using UnityEngine;
using System.Collections;
//实例化物体类
[System.Serializable]
public class InstantObj 
{
    public string Name;
    public string FatherName=null;
    public MyVector3 localPos;
    public MyVector3 LocalEuler;
    public MyVector3 LocalScale;
    public string addComponentArray;
    [System.NonSerialized]
    public InstantObj FatherObj;
}
