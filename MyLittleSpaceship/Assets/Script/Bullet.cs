using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class Bullet : MonoBehaviour
{
    public float speed;
    public PartsWeapon weapon;

    private void Start()
    {
        DestroyObject(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Parts")
        {
            Parts parts = other.gameObject.GetComponent<Parts>();
            parts._currentHp -= weapon._damage;

            if (parts._currentHp <= 0)
            {
                parts.DestroyParts();
            }

            Destroy(this.gameObject);
        }
    }
}
