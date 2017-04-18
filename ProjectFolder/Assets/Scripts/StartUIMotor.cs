using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartUIMotor : MonoBehaviour {
    public GameObject mainpanel, instrpanel;
    public Text switchtext;
    bool mainpanelOn;
    
    public GameObject Temp;
    // Use this for initialization
    void Start () {
        mainpanelOn = true;
	    
	}
	public void panelswitch()
    {
        mainpanelOn = !mainpanelOn;
        mainpanel.SetActive(mainpanelOn);
        instrpanel.SetActive(!mainpanelOn);
    }
    public void SwitchTextChange()
    {
        if(mainpanelOn)
        {
            switchtext.text = "Instructions";
        }
        else
        {
            switchtext.text = "Back";
        }
    }
	
}
