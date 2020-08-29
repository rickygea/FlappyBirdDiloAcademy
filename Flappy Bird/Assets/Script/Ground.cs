using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    public Bird bird;
    public float kecepatan = 1;
    public Transform nextpos;


    void Update()
    {
        if (bird == null || (bird != null && !bird.cekmati()))
        {
            transform.Translate(Vector3.left * kecepatan * Time.deltaTime, Space.World);
        }
    }
    public void SetNextGround(GameObject ground)
    {
        if (ground != null)
        {
            ground.transform.position = nextpos.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bird != null && !bird.cekmati())
        {
            bird.Dead();
        }
    }
 }
