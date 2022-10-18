using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float power;
    [SerializeField] private float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }

    public void Effect()
    {
        gameObject.SetActive(false);
        print("calisti");
    }
}
