using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 8f;
    public float jumpForce = 8f;
    public float aceleracao = 1f;
    public int contador = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetButton("Vertical"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce,0);
        }

        if (rb.linearVelocity.z <= 30)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, aceleracao);
        }

        if(contador >= 60)
        {
            aceleracao += 1f;
            contador = 0;
        }else
        {
            contador++;
        }

    }

}




