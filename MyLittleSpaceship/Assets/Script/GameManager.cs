using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class GameManager : Singletons.Singleton<GameManager> {
    int _stage = 0;

    [SerializeField]
    Spaceship _spaceshipPrefab;

    Spaceship _player;
    
    public Spaceship player
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        _player = Instantiate(_spaceshipPrefab);
        _player.transform.name = "Spaceship";

        Debug.Log(_player);
    }
}
