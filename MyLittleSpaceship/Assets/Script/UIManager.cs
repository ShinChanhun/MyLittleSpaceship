using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ship;


public class UIManager : MonoBehaviour
{

    public Spaceship spaceship;
    public GameObject model;
    public GameObject partsPanelAll;
    public GameObject partsPanelWeapon;
    public GameObject partsPanelDeactivate;
    public Text StockNum1, StockNum2, StockNum3;
    public Text StockNum1_, StockNum2_, StockNum3_;

    public Direction _currentDirection = new Direction();

    public int weaponPartsNumber = 30;
    public int armourPartsNumber = 20;
    public int boosterPartsNumber = 10;

    GameObject _clickedParts;


    void Start()
    {
        spaceship = GameManager.Instance.player;
        ModelRefresh();
        TextRefresh();
    }

    void Update()
    {
        PartsClick();
        //Debug.Log(_currentDirection);
    }

    void PartsClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit = new RaycastHit();

            Ray ray = Camera.allCameras[1].ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask.GetMask("UI")))
            {
                Debug.Log(raycastHit.collider.gameObject);
                _clickedParts = raycastHit.collider.gameObject;
                partsPanelAll.SetActive(true);
                partsPanelDeactivate.SetActive(false);
                
                if(raycastHit.normal == -raycastHit.collider.transform.forward)
                {
                    _currentDirection = Direction.Back;
                }
                else if (raycastHit.normal == raycastHit.collider.transform.forward)
                {
                    _currentDirection = Direction.Front;
                }
                else if (raycastHit.normal == raycastHit.collider.transform.up)
                {
                    _currentDirection = Direction.Top;
                }
                else if (raycastHit.normal == -raycastHit.collider.transform.up)
                {
                    _currentDirection = Direction.Bottom;                    
                }
                else if (raycastHit.normal == raycastHit.collider.transform.right)
                {
                    _currentDirection = Direction.Right;                 
                }
                else if (raycastHit.normal == -raycastHit.collider.transform.right)
                {
                    _currentDirection = Direction.Left;
                }
            }

            Debug.Log(_currentDirection);

        }
        if (_clickedParts != null)
        {
            if (_clickedParts.GetComponent<Parts>() is PartsLinker)
            {
                KeyBoardInput();
                TextRefresh();
            }
        }
    }

    void TextRefresh()
    {
        StockNum1.text = weaponPartsNumber.ToString();
        StockNum2.text = armourPartsNumber.ToString();
        StockNum3.text = boosterPartsNumber.ToString();
        StockNum1_.text = StockNum1.text;
        StockNum2_.text = StockNum2.text;
        StockNum3_.text = StockNum3.text;

    }
    void ModelRefresh()
    {
        foreach (Parts i in spaceship._parts)
        {
            GameObject a = Instantiate(i.gameObject, Vector3.zero, model.transform.rotation);

            a.transform.parent = model.transform;
            a.transform.localPosition = i.GetPosition();
            a.transform.localRotation = model.transform.rotation;

            a.GetComponent<BoxCollider>().isTrigger = true;
            a.layer = 5;
        }
    }
    void KeyBoardInput()
    {
        if ((Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")) && partsPanelWeapon.activeSelf == true)
        {
            weaponPartsNumber -= 1;
            partsPanelWeapon.SetActive(false);
            partsPanelDeactivate.SetActive(true);

        } //웨펀 파츠 종류 선택
        else if (Input.GetKeyDown("4") && partsPanelWeapon.activeSelf == true)
        {
            partsPanelWeapon.SetActive(false);
            partsPanelAll.SetActive(true);

        } // 웨펀 패널 취소 후 이전 패널로 이동
        else if (Input.GetKeyDown("4") && partsPanelAll.activeSelf == true)
        {
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
       
        } // 면 선택 취소
        else if (Input.GetKeyDown("1") && partsPanelAll.activeSelf == true)
        {
            partsPanelAll.SetActive(false);
            partsPanelWeapon.SetActive(true);
         
        } // 웨펀 패널 활성화
        else if (Input.GetKeyDown("2") && partsPanelAll.activeSelf == true)
        {
            armourPartsNumber -= 1;
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
      
        } // 장갑 선택 후 패널 비 활성화
        else if (Input.GetKeyDown("3") && partsPanelAll.activeSelf == true)
        {
            boosterPartsNumber -= 1;
            partsPanelAll.SetActive(false);
            partsPanelDeactivate.SetActive(true);
        } // 부스터 선택 후 패널 비 활성화

    }

}
