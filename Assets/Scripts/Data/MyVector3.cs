using UnityEngine;
using System.Collections;
[System.Serializable]
public class MyVector3
{
    public double x;
    public double y;
    public double z;

    public MyVector3() { }
    public MyVector3(double X,double Y,double Z)
    {
        this .x = X;
        this.y = Y;
        this.z = Z;
    }
    public Vector3 ConvertV3() 
    {
        return new Vector3((float)this.x,(float)this.y,(float)this.z);
    }
}
