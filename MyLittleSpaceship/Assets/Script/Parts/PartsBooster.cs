using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class PartsBooster : Parts
    {
        
        Spaceship _spaceship;

        public Spaceship spaceship;

        public float rotationSpeed; 
       
        float _distance;
     
        void Awake()
        {
            _spaceship = GameManager.Instance.player;
           
            mass = PartsMass.boosterPartsMass;
            type = PartsType.Booster;
         }

        void Start()
        {
            _distance = Vector3.Distance(this.transform.position, _spaceship.transform.position);
            _maxHp = PartHealth.boosterPartsHealth;
            _currentHp = _maxHp;
        }
        /// <summary>
        /// Spaceship 움직임
        /// </summary>
        /// 
        public void MoveForward()
        {
            Vector3 movement = transform.worldToLocalMatrix.MultiplyVector(transform.forward) * _spaceship._speed * Time.deltaTime;

            _spaceship._rigidbody.AddRelativeForce(movement);
            if (this.transform.localPosition.x > _spaceship.transform.localPosition.x)
            {
                _spaceship._rigidbody.AddRelativeTorque(new Vector3(0, -1, 0) * rotationSpeed / _distance * Time.deltaTime);
            }
            else if (this.transform.localPosition.x < _spaceship.transform.localPosition.x)
            {
                _spaceship._rigidbody.AddRelativeTorque(new Vector3(0, 1, 0) * rotationSpeed / _distance * Time.deltaTime);
            }
        }

        public void MoveBackward()
        {
            Vector3 movement = transform.worldToLocalMatrix.MultiplyVector(-transform.forward) * _spaceship._speed * Time.deltaTime;
            _spaceship._rigidbody.AddRelativeForce(movement);
        }
    }
}