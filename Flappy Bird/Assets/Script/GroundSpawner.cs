using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private Ground ground;
    private Ground sebelum;
    
    private void SpawnGround()
    {
        if (sebelum != null)
        {
            Ground groundbaru = Instantiate(ground);
            groundbaru.gameObject.SetActive(true);
            groundbaru.transform.parent = this.transform;
            sebelum.SetNextGround(groundbaru.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Ground groundb = collision.GetComponent<Ground>();
        if (groundb)
        {
            sebelum = groundb;
            SpawnGround();
        }
    }
}
