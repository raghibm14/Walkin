using UnityEngine;
using System.Collections;

public class rendereroff : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PI"))
        {
            foreach(Transform gochild in go.transform )
            {
                gochild.gameObject.SetActive(false);
            }
        }
        
        foreach (GameObject goi in GameObject.FindGameObjectsWithTag("HI"))
        {
            foreach (Transform goichild in goi.transform)
            {
                goichild.gameObject.SetActive(false);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
