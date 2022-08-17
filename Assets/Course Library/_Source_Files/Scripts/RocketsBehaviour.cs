using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsBehaviour : MonoBehaviour
{


    private Transform target;
    public float speed= 10.0f;//
    private bool homing;

    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        if(homing && target != null)
        {
            Debug.Log("ROKETSSS");
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (target != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
    public void Fire(Transform newTarget)
    {
        target = newTarget;//
        homing = true;
        Destroy(gameObject, aliveTimer);
    }
}
