using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembak : MonoBehaviour
{
    public Transform pointtembak;
    public GameObject peluru;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            fungsitembak();
        }
    }

    void fungsitembak() {
        Instantiate(peluru, pointtembak.position, pointtembak.rotation);
    }
}
