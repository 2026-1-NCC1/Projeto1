using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour

{

    public Rigidbody rb;
    public float moveSpeed = 8f;
    public float jumpForce = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void resetPosicao()
    {
        transform.position = new Vector3(-1.7f, 0.74f, 1f);
    }
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        if (rb.linearVelocity.z <= 35)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, 0.01f + rb.linearVelocity.z);
        }



        if (Input.GetButtonDown("Jump") || Input.GetButton("Vertical"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
        
    }

 
    private void OnTriggerEnter(Collider hit)
    {
        if ((hit.gameObject.tag == "obstaculos")|| hit.gameObject.tag == "limites" )
        {
            resetPosicao();
        }
    }
}




