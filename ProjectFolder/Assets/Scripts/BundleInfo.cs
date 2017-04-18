using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class BundleInfo : MonoBehaviour {

    //for bundle
    public InputField bu,an;
    public string BundleURL;
    public string AssetName;
    public int version=1;
    public bool bybundle = false;

    //not for bundle
    public Dropdown droplist;
    List<string> prefablist;
    int prefabtoload;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        //Debug.Log("Meshes " + Resources.FindObjectsOfTypeAll(typeof()).Length);
      /*  Object[] subListObjects = Resources.LoadAll("", typeof(GameObject));
        for(int i=0;i<subListObjects.Length;i++)
        {
            Debug.Log(subListObjects[i]);
        }*/
        prefablist = new List<string>();
        //
        droplist.ClearOptions();
        droplist.AddOptions(prefablist);
    }
    public void SwitchwithBundleTrue()
    {
        BundleURL = bu.text;
        AssetName = an.text;
        bybundle = true;
        SceneManager.LoadScene("RoutePlay");
    }
    public void SwitchwithBundleFalse()
    {
        bybundle = false;
        prefabtoload = droplist.value;
        SceneManager.LoadScene("RoutePlay");
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
