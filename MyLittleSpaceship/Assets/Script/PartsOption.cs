namespace Ship
{
    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        Front,
        Back
    }

    public enum PartsType
    {
        Core,
        Armour,
        Weapon,
        Booster
    }

    static class PartsMass
    {
        public static float boosterPartsMass = 1f;
        public static float weaponPartsMass = 1.5f;
        public static float armorPartsMass = 1.3f;
        public static float corePartsMass = 1f;
    }

    static class PartHealth
    {
        public static int boosterPartsHealth = 100;
        public static int weaponPartsHealth = 100;
        public static int corePartsHealth = 200;
        public static int armourNormalPartsHealth = 200;
        public static int armourHpPartsHealth = 300;
        public static int armourRefairPartsHealth = 100;
    }
    public struct Position
    {
        public int x;
        public int y;
        public int z;
    }

    public struct Link
    {
        Parts _top;
        Parts _bottom;
        Parts _left;
        Parts _right;
        Parts _front;
        Parts _back;
        Direction _doking;

        public Parts top
        {
            get
            {
                return _top;
            }

            set
            {
                _top = value;
            }
        }
        public Parts bottom
        {
            get
            {
                return _bottom;
            }

            set
            {
                _bottom = value;
            }
        }
        public Parts left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
            }
        }
        public Parts right
        {
            get
            {
                return _right;
            }

            set
            {
                _right = value;
            }
        }
        public Parts front
        {
            get
            {
                return _front;
            }

            set
            {
                _front = value;
            }
        }
        public Parts back
        {
            get
            {
                return _back;
            }
            set
            {
                _back = value;
            }
        }
        public Direction doking
        {
            get
            {
                return _doking;
            }
            set
            {
                _doking = value;
            }
        }
    }
}