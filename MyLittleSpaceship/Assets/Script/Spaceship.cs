using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class Spaceship : MonoBehaviour {
        [SerializeField]
        PartsCore corePrefab;
        [SerializeField]
        PartsArmour armourPrefab;
        [SerializeField]
        PartsWeapon weaponPrefab;
        [SerializeField]
        PartsBooster boosterPrefab;

        public PartsCore _core;
        public List<PartsArmour> _armourParts = new List<PartsArmour>();
        public List<PartsWeapon> _weaponParts = new List<PartsWeapon>();
        public List<PartsBooster> _boosterParts = new List<PartsBooster>();
        public List<Parts> _parts = new List<Parts>();
 
        public int _rotationSpeed;
        public int _speed;
        public Rigidbody _rigidbody;
        public GameObject _cameraPosition;
        float _mass;


        void Awake()
        {
            _core = Instantiate(corePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            _core.transform.parent = this.transform;
    
            _rigidbody = GetComponent<Rigidbody>();
            _parts = GetChildren(this.gameObject);

    
            foreach (Parts i in _parts)
            {
                if (i is PartsArmour)
                {
                    _armourParts.Add(i.GetComponent<PartsArmour>());
                }
                else if (i is PartsWeapon)
                {
                    _weaponParts.Add(i.GetComponent<PartsWeapon>());
                }
                else if (i is PartsBooster)
                {
                    _boosterParts.Add(i.GetComponent<PartsBooster>());
                }
            }





        }

        void Start()
        {
            GetSpaceshipMass();
            _rigidbody.mass = _mass;

            Parts _partsTemp;
            _partsTemp = DokingParts(_core, PartsType.Armour, Direction.Top);
            _partsTemp = DokingParts((PartsLinker)_partsTemp, PartsType.Booster, Direction.Back);
            _partsTemp = DokingParts(_core, PartsType.Armour, Direction.Left);
            _partsTemp = DokingParts((PartsLinker)_partsTemp, PartsType.Booster, Direction.Back);
            _partsTemp = DokingParts(_core, PartsType.Armour, Direction.Right);
            _partsTemp = DokingParts((PartsLinker)_partsTemp, PartsType.Booster, Direction.Back);
            _partsTemp = DokingParts(_core, PartsType.Armour, Direction.Bottom);
            _partsTemp = DokingParts((PartsLinker)_partsTemp, PartsType.Booster, Direction.Back);
        }


        void OnEnable()
        {
            StartCoroutine(WaitForRefair());
        }


        IEnumerator WaitForRefair()
        {
            while(true)
            {
                UpdateDestroy();
                PartsArmour.Refair(_armourParts);
                yield return new WaitForSeconds(3f);
            }
        }

        int GetPartsCount()
        {
            return this.transform.childCount;
        }
        /// <summary>
        /// 파츠를 붙임
        /// </summary>
        /// <param name="target">주체</param>
        /// <param name="parts">객체 - 새로 추가되는 파츠</param>
        /// <param name="direction"> 주체에 객체가 붙는 방향</param>
        public Parts DokingParts(PartsLinker target, PartsType type, Direction direction)
        {
            if (target.type == PartsType.Booster || target.type == PartsType.Weapon)
            {
                Debug.LogError("Err[Spaceship.cs] - Do not doking this Parts");
                return null;
            }

            Parts parts = null;

            switch(type)
            {
                case PartsType.Armour:
                    parts = Instantiate(armourPrefab);
                    _armourParts.Add((PartsArmour)parts);
                    _parts.Add(parts);
                    break;

                case PartsType.Weapon:
                    parts = Instantiate(weaponPrefab);
                    _weaponParts.Add((PartsWeapon)parts);
                    _parts.Add(parts);
                    break;

                case PartsType.Booster:
                    parts = Instantiate(boosterPrefab);
                    _boosterParts.Add((PartsBooster)parts);
                    _parts.Add(parts);
                    break;
            }
            parts.transform.parent = this.transform;

            target.DokingParts(direction, parts);

            if (type == PartsType.Core || type == PartsType.Armour)
            {
                AroundLink((PartsLinker)parts);
            }

            return parts;
        }

        void AroundLink(PartsLinker parts)
        {
            Position p1 = parts.position;
            Position p2;

            
            for (int i = 0; i < _armourParts.Count; i++)
            {
                p2 = _armourParts[i].position;

                if (p1.x - 1 == p2.x && p1.y == p2.y && p1.z == p2.z)
                {
                    if (parts._link.left == null)
                    {
                        parts._link.left = _armourParts[i];
                        _armourParts[i]._link.right = parts;
                    }
                }
                else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z == p2.z)
                {
                    if (parts._link.right == null)
                    {
                        parts._link.right = _armourParts[i];
                        _armourParts[i]._link.left = parts;
                    }
                }
                else if (p1.x == p2.x && p1.y - 1 == p2.y && p1.z == p2.z)
                {
                    if (parts._link.bottom == null)
                    {
                        parts._link.bottom = _armourParts[i];
                        _armourParts[i]._link.top = parts;

                    }
                }
                else if (p1.x + 1 == p2.x && p1.y + 1 == p2.y && p1.z == p2.z)
                {
                    if (parts._link.top == null)
                    {
                        parts._link.top = _armourParts[i];
                        _armourParts[i]._link.bottom = parts;

                    }
                }
                else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z - 1 == p2.z)
                {
                    if (parts._link.back == null)
                    {
                        parts._link.back = _armourParts[i];
                        _armourParts[i]._link.front = parts;

                    }
                }
                else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z + 1 == p2.z)
                {
                    if (parts._link.front == null)
                    {
                        parts._link.front = _armourParts[i];
                        _armourParts[i]._link.back = parts;
                    }
                }
            }

            p2 = _core.position;

            if (p1.x - 1 == p2.x && p1.y == p2.y && p1.z == p2.z)
            {
                if (parts._link.left == null)
                {
                    parts._link.left = _core;
                    _core._link.right = parts;
                }
            }
            else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z == p2.z)
            {
                if (parts._link.right == null)
                {
                    parts._link.right = _core;
                    _core._link.left = parts;
                }
            }
            else if (p1.x == p2.x && p1.y - 1 == p2.y && p1.z == p2.z)
            {
                if (parts._link.bottom == null)
                {
                    parts._link.bottom = _core;
                    _core._link.top = parts;

                }
            }
            else if (p1.x + 1 == p2.x && p1.y + 1 == p2.y && p1.z == p2.z)
            {
                if (parts._link.top == null)
                {
                    parts._link.top = _core;
                    _core._link.bottom = parts;

                }
            }
            else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z - 1 == p2.z)
            {
                if (parts._link.back == null)
                {
                    parts._link.back = _core;
                    _core._link.front = parts;

                }
            }
            else if (p1.x + 1 == p2.x && p1.y == p2.y && p1.z + 1 == p2.z)
            {
                if (parts._link.front == null)
                {
                    parts._link.front = _core;
                    _core._link.back = parts;
                }
            }
        }

        public List<Parts> GetChildren(GameObject go)
        {
            List<Parts> children = new List<Parts>();

            foreach (Transform tran in go.transform)
            {
                if (tran.gameObject.GetComponent<Parts>() != null)
                {
                    children.Add(tran.gameObject.GetComponent<Parts>());
                }
            }
            return children;
        }

        public void GetSpaceshipMass()
        {
            foreach (Parts i in _parts)
            {
                _mass += i.mass;
            }
        }

        public void DestroyParts(Parts parts)
        {
            switch(parts.type)
            {
                case PartsType.Armour:
                    
                    break;

                case PartsType.Weapon:
                    
                    break;

                case PartsType.Booster:
                    break;
            }
        }

        void UpdateDestroy()
        {
            for (int i = 0; i < _parts.Count; i++)
            {
                if (_parts[i].IsLifeZero())
                {
                    Debug.Log(_parts[i].name);
                    _parts[i].DestroyParts();

                    switch (_parts[i].type)
                    {
                        case PartsType.Armour:
                            _armourParts.Remove((PartsArmour)_parts[i]);
                            break;
                        case PartsType.Booster:
                            _boosterParts.Remove((PartsBooster)_parts[i]);
                            break;
                        case PartsType.Weapon:
                            _weaponParts.Remove((PartsWeapon)_parts[i]);
                            break;
                    }

                    _parts.Remove(_parts[i]);
                }
            }
        }
    }
}
