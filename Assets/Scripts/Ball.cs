using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb { get; set; }

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {

    }
}