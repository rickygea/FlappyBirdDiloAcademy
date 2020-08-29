using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    [SerializeField]
    private Text teksscore;
    public float force = 100;
    bool mati;
    int nilai;
    [SerializeField]private UnityEvent OnJump, OnDead, OnAddPoint;
    public Rigidbody2D rigid;
    public Animator animasi;

    // Update is called once per frame
    void Update()
    {
        if (!mati && Input.GetMouseButtonDown(0)) {
            Jump();
        }
    }
    public bool cekmati() {
        return mati;
    }

    public void Dead() {
        if (!mati && OnDead != null) {
            OnDead.Invoke();
        }

        mati = true;

    }

    void Jump() {
        if (rigid) {
            rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0, force));
        }
        if (OnJump != null) {
            OnJump.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animasi.enabled = false;
    }
    public void tambahpoint(int input)
    {
        nilai += input;
        if (OnAddPoint != null)
        {   OnAddPoint.Invoke();
        }
        teksscore.text = nilai.ToString();
    }

}
