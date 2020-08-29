using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru : MonoBehaviour
{
    public float kecepatan = 20f;
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * kecepatan;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pipa") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "penghancurpeluru")
        {
            Destroy(gameObject);

        }
    }
}
