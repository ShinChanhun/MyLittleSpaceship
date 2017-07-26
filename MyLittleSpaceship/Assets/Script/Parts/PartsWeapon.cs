using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public enum WeaponType
    {
        Normal,
        Damage,
        Covariance
    }

    public class PartsWeapon : Parts
    {
        float _reloadTime;
        float _reload;

        public int _damage;
        public GameObject bullet;
        public GameObject missile;
        public GameObject lazer;

        public GameObject bulletSpawner;

        public WeaponType weaponType;

        void Awake()
        {
            mass = PartsMass.weaponPartsMass;
            type = PartsType.Weapon;
        }

        void Start()
        {
            _maxHp = PartHealth.weaponPartsHealth;
            _currentHp = _maxHp;
            SetWeaponValue();
        }

        
        public void Shot()
        {
            GameObject _bul;

            if(Time.time <= _reload)
            {
                return ;
            }
            else
            {
                _reload = Time.time + _reloadTime;
            }
            

            switch (weaponType)
            {
                case WeaponType.Normal:
                    _bul = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    _bul.GetComponent<Bullet>().weapon = this;
                    break;
                case WeaponType.Damage:
                    _bul = Instantiate(missile, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    _bul.GetComponent<Bullet>().weapon = this;
                    break;
                case WeaponType.Covariance:
                    _bul = Instantiate(lazer, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    _bul.GetComponent<Bullet>().weapon = this;
                    break;
            }
        }

        void SetWeaponValue()
        {
            switch (weaponType)
            {
                case WeaponType.Normal:
                    _damage = 20;
                    _reloadTime = 0.5f;
                    break;
                case WeaponType.Damage:
                    _damage = 40;
                    _reloadTime = 2f;
                    break;
                case WeaponType.Covariance:
                    _damage = 5;
                    _reloadTime = 0.2f;
                    break;
            }
        }
    }
}