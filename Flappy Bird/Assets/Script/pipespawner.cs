using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipespawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private pipe atas, bawah;
    [SerializeField] private float interval = 1;
    private Coroutine corotinspawn;
    public float lubang = 1f;

    private float maxMinOffset = 1;
    public Point poin;
    private void Start()
    {
        mulaispawn();
    }
    void mulaispawn()
    {
        if (corotinspawn == null) {
            corotinspawn = StartCoroutine(spawn());
        }
    }

    void ubahukuranlubang() {
        lubang = Random.Range(1f, 3f);
    }

    void berhentispawn()
    {
        if (corotinspawn != null) {
            StopCoroutine(corotinspawn);
        }
    }

    void Spawnpipe()
    {
        ubahukuranlubang();

        pipe newatas = Instantiate(atas, transform.position, Quaternion.Euler(0, 0, 180));
        newatas.gameObject.SetActive(true);
        pipe newbawah = Instantiate(bawah, transform.position, Quaternion.identity);
        newbawah.gameObject.SetActive(true);
        newatas.transform.position += Vector3.up * (lubang / 2);
        newbawah.transform.position += Vector3.down * (lubang / 2);
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newatas.transform.position += Vector3.up * y;
        newbawah.transform.position += Vector3.up * y;


        Point newPoint = Instantiate(poin, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(lubang);
        newPoint.transform.position += Vector3.up * y;
        newbawah.transform.parent = this.transform;
        newatas.transform.parent = this.transform;
        newPoint.transform.parent = this.transform;
    }

    IEnumerator spawn()
    {
        while (true)
        {
            if (bird.cekmati()) {
                berhentispawn();
            }
            Spawnpipe();
            yield return new WaitForSeconds(interval);
        }
    }
}
