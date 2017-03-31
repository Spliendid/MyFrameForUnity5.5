using UnityEngine;
using System.Collections;

public class MovieTest : MonoBehaviour {
    public MovieTexture movie;
    public Texture2D texture;
    public AudioClip ac;
	// Use this for initialization
	void Start () {
        StartCoroutine(GetMovieTexture());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GetMovieTexture() 
    {
        WWW www = new WWW("file://" + Application.streamingAssetsPath + "/Assetbundle/004_360-panoramas.assetbundle");
        yield return www;
        if ( null == www.assetBundle.mainAsset)
        {
            Debug.Log("111");
        }
        Debug.Log(www.assetBundle.mainAsset);
        texture = www.assetBundle.mainAsset as Texture2D;
       // movie = www.movie;
    }
}
