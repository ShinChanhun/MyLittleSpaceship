using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ship
{
    public enum ArmourType
    {
        Hp,
        Refair,
        Noraml
    }

    public class PartsArmour : PartsLinker
    {

        ArmourType armourType;

        void Awake()
        {
            type = PartsType.Armour;
        }

        void Start()
        {
            switch (armourType)
            {
                case ArmourType.Hp:
                    _maxHp = PartHealth.armourHpPartsHealth;
                    _currentHp = _maxHp;
                    break;

                case ArmourType.Noraml:
                    _maxHp = PartHealth.armourNormalPartsHealth;
                    _currentHp = _maxHp;
                    break;

                case ArmourType.Refair:
                    _maxHp = PartHealth.armourRefairPartsHealth;
                    _currentHp = _maxHp;
                    break;
            }
        }

        public static void Refair(List<PartsArmour> parts)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                switch (parts[i].armourType)
                {
                    case ArmourType.Hp:
                        parts[i]._currentHp += 5;
                        if (parts[i]._currentHp >= parts[i]._maxHp)
                        {
                            parts[i]._currentHp = parts[i]._maxHp;
                        }
                        break;

                    case ArmourType.Noraml:
                        parts[i]._currentHp += 10;
                        if (parts[i]._currentHp >= parts[i]._maxHp)
                        {
                            parts[i]._currentHp = parts[i]._maxHp;
                        }
                        break;

                    case ArmourType.Refair:
                        parts[i]._currentHp += 20;
                        if (parts[i]._currentHp >= parts[i]._maxHp)
                        {
                            parts[i]._currentHp = parts[i]._maxHp;
                        }
                        break;
                }
            }
        }

        int GetLink()
        {
            int count = 0;
            if (_link.top != null) count++;
            if (_link.bottom != null) count++;
            if (_link.left != null) count++;
            if (_link.right != null) count++;
            if (_link.front != null) count++;
            if (_link.back != null) count++;

            return count;
        }

        public override void DestroyParts()
        {
            base.DestroyParts();

            if (_link.top != null)
            {
                if (_link.top.type != PartsType.Armour || _link.top.type != PartsType.Core)
                {
                    _link.top.DestroyParts();
                }
            }

            if (_link.bottom != null)
            {
                if (_link.bottom.type != PartsType.Armour && _link.bottom.type != PartsType.Core)
                {
                    _link.bottom.DestroyParts();
                }
            }

            if (_link.left != null)
            {
                if (_link.left.type != PartsType.Armour && _link.left.type != PartsType.Core)
                {
                    _link.left.DestroyParts();
                }
            }

            if (_link.right != null)
            {
                if (_link.right.type != PartsType.Armour && _link.right.type != PartsType.Core)
                {
                    _link.right.DestroyParts();
                }
            }

            if (_link.front != null)
            {
                if (_link.front.type != PartsType.Armour && _link.front.type != PartsType.Core)
                {
                    _link.front.DestroyParts();
                }
            }

            if (_link.back != null)
            {
                if (_link.back.type != PartsType.Armour && _link.back.type != PartsType.Core)
                {
                    _link.back.DestroyParts();
                }
            }
        }
    }
}