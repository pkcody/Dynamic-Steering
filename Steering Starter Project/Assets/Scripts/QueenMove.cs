using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMove : MonoBehaviour
{
    public bool dark = true;
    public Rigidbody rb;
    public float speed = .08f;

    void DarkQueen()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed, ForceMode.Impulse);
    }
    void WhiteQueen()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.back * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        if (dark)
        {
            DarkQueen();
        }
        else
        {
            WhiteQueen();
        }

    }
}
