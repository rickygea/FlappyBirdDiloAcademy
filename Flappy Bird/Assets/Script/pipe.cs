using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float kecepatan = 1;
    
    private void Update()
    {
        if (!bird.cekmati())
        {
            transform.Translate(Vector3.left * kecepatan * Time.deltaTime, Space.World);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird)
        {
            Collider2D collider = GetComponent<Collider2D>();
            
            if (collider)
            {
                collider.enabled = false;
            }
            
            bird.Dead();
        }
    }
}
