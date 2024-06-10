using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag  =="power")
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Vector3 explosionPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
            rb.AddExplosionForce(350, explosionPosition, 5f);
            Invoke("DisableCollider", 0.2f);
        } else
        {
            Movement movmentScript = collision.gameObject.GetComponent<Movement>();
            if (movmentScript)
            {
                movmentScript.ChangeSpeed(0);
            }
        }

    }
    private void DisableCollider()
    {
            gameObject.GetComponent<Collider>().enabled = false;

    }
}
