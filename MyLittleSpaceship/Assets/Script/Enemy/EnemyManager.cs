using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        const int detectDistance = 50;
        const int attackDistance = 30;

        Ship.Spaceship _player;

        List<EnemySpaceship> _enemySpaceships = new List<EnemySpaceship>();

        void Awake()
        {
            _player = GameManager.Instance.player;
        }

        /// <summary>
        /// 플레이어와 이 적이 거리 몇 이하일때 플레이어 방향으로 이동
        /// </summary>
        public void DetectPlayer()
        {
            for(int i = 0; i < _enemySpaceships.Count; i++)
            {
                float distance = UtilityMath.GetDistance(
                    _player._core.position.x,
                    _player._core.position.y,
                    _player._core.position.z,
                    _enemySpaceships[i]._core.position.x,
                    _enemySpaceships[i]._core.position.y,
                    _enemySpaceships[i]._core.position.z);

                if (distance < detectDistance)
                {
                    Turn();
                }

                if(distance < attackDistance)
                {
                    Attack();
                }

                //NOTE : Move도 해야함
                //if(distance < Move)
            }
        }

        /// <summary>
        /// 플레이어 방향으로 기체를 돌림
        /// </summary>
        public void Turn()
        {

        }

        public void Move()
        {

        }

        public void Attack()
        {

        }
    }
}
