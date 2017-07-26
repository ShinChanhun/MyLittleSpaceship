using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardInput : MonoBehaviour {

    public GameObject partsPanelAll;
    public GameObject partsPanelWeapon;
    public GameObject partsPanelDeactivate;
    public Text StockNum1,StockNum2,StockNum3;
    public Text StockNum1_, StockNum2_, StockNum3_;
    public GameObject TemporaryText; //Temporary
    public int TemporaryNum1 = 30;
    public int TemporaryNum2 = 20;
    public int TemporaryNum3 = 10;

        
    void Start()
    {
        
    }
	void Update () {
        StockNum1.text = TemporaryNum1.ToString();
        StockNum2.text = TemporaryNum2.ToString();
        StockNum3.text = TemporaryNum3.ToString();
        StockNum1_.text = StockNum1.text;
        StockNum2_.text = StockNum2.text;
        StockNum3_.text = StockNum3.text;



        if ((Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")) && partsPanelWeapon.activeSelf == true)
        {
            TemporaryNum1 -= 1;
            partsPanelWeapon.SetActive(false);
            partsPanelDeactivate.SetActive(true);
        }
        else if(Input.GetKeyDown("4") && partsPanelWeapon.activeSelf == true)
        {
            partsPanelWeapon.SetActive(false);
            partsPanelAll.SetActive(true);
        }
        else if(Input.GetKeyDown("4") && partsPanelAll.activeSelf == true)
        {
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
        }
        else if (Input.GetKeyDown("1") && partsPanelAll.activeSelf == true)
        {
            partsPanelAll.SetActive(false);
            partsPanelWeapon.SetActive(true);
        }
        else if (Input.GetKeyDown("2") && partsPanelAll.activeSelf == true)
        {
            TemporaryNum2 -= 1;
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
            TemporaryText.SetActive(false);
        }
        else if (Input.GetKeyDown("3") && partsPanelAll.activeSelf == true)
        {
            TemporaryNum3 -= 1;
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
        }

    }

    public void WeaponClick()
    {
        TemporaryNum1 -= 1;
    }
    public void ArmorClick()
    {
        TemporaryNum2 -= 1;
    }

    public void BoosterClick()
    {
        TemporaryNum3 -= 1;
    }
        
    
}
