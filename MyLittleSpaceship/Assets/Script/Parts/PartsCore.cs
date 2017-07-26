using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ship
{
    public class PartsCore : PartsLinker
    {

        void Awake()
        {
            mass = PartsMass.corePartsMass;
            type = PartsType.Core;
            _currentHp = 100;
        }

        void Start()
        {
            _maxHp = PartHealth.corePartsHealth;
            _currentHp = _maxHp;
        }

        public override void DestroyParts()
        {
            base.DestroyParts();
            Spaceship spaceship = transform.parent.GetComponent<Spaceship>();
            Destroy(spaceship.gameObject);

            //NOTE : GameOver
        }
    }
}
