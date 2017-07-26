using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ship;
using UnityEngine.EventSystems;
using System;

public static class UIModelDirectionText
{
    public const string Top = "Top";
    public const string Bottom = "Bottom";
    public const string Left = "Left";
    public const string Right = "Right";
    public const string Front = "Front";
    public const string Back = "Back";
}
public class ModelRotater : UIBehaviour ,IDragHandler
{

    public GameObject model;
    public Text text;
    public UIManager UIManager;

    public float horizontalSpeed = 10.0F;
    public float verticalSpeed = 10.0F;

    public void LeftClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        text.text = UIModelDirectionText.Left;
    }

    public void RightClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        text.text = UIModelDirectionText.Right;
    }

    public void TopClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        text.text = UIModelDirectionText.Top;
    }

    public void BottomClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        text.text = UIModelDirectionText.Bottom;
    }

    public void FrontClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        text.text = UIModelDirectionText.Front;
    }

    public void BackClick()
    {
        model.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        text.text = UIModelDirectionText.Back;
    }
 
    public void OnDrag(PointerEventData eventData)
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        model.transform.Rotate(-v, -h, 0);
    }
}
   

