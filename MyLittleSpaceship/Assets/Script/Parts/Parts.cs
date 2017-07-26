using UnityEngine;
using System;
using System.Collections;


namespace Ship
{
    public class Parts : MonoBehaviour
    {
        public float mass;
        public int _currentHp;
        public GameObject explosionPrefab;

        public Position position;
        public Link _link;
        protected int _maxHp;

        public PartsType _type;


        public int hp
        {
            get
            {
                return _maxHp;
            }
            set
            {
                _maxHp = value;
            }
        }

        public PartsType type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public bool IsLifeZero()
        {
            return _currentHp <= 0;
        }

        void Awake()
        {
            position = new Position();
            _currentHp = 100;
        }

        public void SetPosition(Direction dir, Position standard)
        {
            switch (dir)
            {
                case Direction.Top:
                    position.x = standard.x;
                    position.y = standard.y + 1;
                    position.z = standard.z;
                    break;
                case Direction.Bottom:
                    position.x = standard.x;
                    position.y = standard.y - 1;
                    position.z = standard.z;
                    break;
                case Direction.Left:
                    position.x = standard.x - 1;
                    position.y = standard.y;
                    position.z = standard.z;
                    break;
                case Direction.Right:
                    position.x = standard.x + 1;
                    position.y = standard.y;
                    position.z = standard.z;
                    break;
                case Direction.Front:
                    position.x = standard.x;
                    position.y = standard.y;
                    position.z = standard.z + 1;
                    break;
                case Direction.Back:
                    position.x = standard.x;
                    position.y = standard.y;
                    position.z = standard.z - 1;
                    break;
            }

            this.transform.localPosition = new Vector3(position.x, position.y, position.z);
        }

        public Vector3 GetPosition()
        {
            Vector3 position = new Vector3(this.position.x, this.position.y, this.position.z);

            return position;
        }

        public void DokingParts(Direction direction, Parts parts)
        {
            parts.SetPosition(direction, position);

            //Debug.Log(this.name + " " + position.x + " " + position.y + " " + position.z);

            switch (direction)
            {
                case Direction.Top:
                    if (_link.top != null || parts._link.bottom != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 0" + this.name + "," + parts.name);

                    _link.top = parts;
                    parts._link.bottom = this;
                    break;

                case Direction.Bottom:
                    if (_link.bottom != null || parts._link.top != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 1 " + this.name + "," + parts.name);

                    _link.bottom = parts;
                    parts._link.top = this;
                    break;

                case Direction.Left:
                    if (_link.left != null || parts._link.right != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 2 " + this.name + "," + parts.name);

                    _link.left = parts;
                    parts._link.right = this;
                    break;

                case Direction.Right:
                    if (_link.right != null || parts._link.left != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 3 " + this.name + "," + parts.name);

                    _link.right = parts;
                    parts._link.left = this;
                    break;

                case Direction.Front:
                    if (_link.front != null || parts._link.back != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 4 " + this.name + "," + parts.name);

                    _link.front = parts;
                    parts._link.back = this;
                    break;

                case Direction.Back:
                    if (_link.back != null || parts._link.front != null)
                        Debug.LogError("Err[Parts.cs] - Already Linked 5 " + this.name + "," + parts.name);

                    _link.back = parts;
                    parts._link.front = this;
                    break;
            }
        }

        public virtual void DestroyParts()
        {
            Instantiate(explosionPrefab,this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}