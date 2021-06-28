using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public GameObject shot;
    Vector2 input;

    void Start()
    {
        
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        transform.Translate(input * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            OnFire();
        }
    }

    void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }
}
