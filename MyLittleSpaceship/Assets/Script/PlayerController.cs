using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class PlayerController : MonoBehaviour {

    public Spaceship spaceship;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            TurnUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            TurnDown();

        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            TurnA();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            TurnB();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            for (int i = 0; i < spaceship._boosterParts.Count; i++)
            {
                spaceship._boosterParts[i].MoveForward();
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            for (int i = 0; i < spaceship._boosterParts.Count; i++)
            {
                spaceship._boosterParts[i].MoveBackward();
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            for(int i = 0; i < spaceship._weaponParts.Count; i++)
            {
                spaceship._weaponParts[i].Shot();
            }
        }

    }

    public void TurnUp()
    {
        transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * spaceship._rotationSpeed);
    }

    public void TurnLeft()
    {
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * spaceship._rotationSpeed);

    }

    public void TurnRight()
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * spaceship._rotationSpeed);
    }

    public void TurnDown()
    {
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * spaceship._rotationSpeed);
    }

    public void TurnA()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * spaceship._rotationSpeed);
    }

    public void TurnB()
    {
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * spaceship._rotationSpeed);
    }
}
