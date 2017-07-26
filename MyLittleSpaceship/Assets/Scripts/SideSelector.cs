using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideSelector : MonoBehaviour {

    public Button Side;
    public GameObject Temp;
    public Color OnPart = new Color(0.2F, 0.3F, 0.4F, 0.5F); //Temporary
	
    
	void Update () {
		/*if(Input.GetKeyDown("1"))
        {
            Side.interactable = false;
        }*/ //Temporary
        if(Input.GetKeyDown("2"))
        {
            Side.interactable = false;
            Temp.SetActive(false);
        }
        else if (Input.GetKeyDown("3"))
        {
            Side.interactable = false;
        }

    }
}
