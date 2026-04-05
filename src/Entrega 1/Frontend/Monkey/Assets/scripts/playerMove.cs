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
    [SerializeField] alvo scriptAlvo;
    public playerLife life;

    void Start()
    {
        alvo.alvosAcertados = 0;
        //variavel para pegar o rigidbody do player mais facilmente
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        //pega o input do teclado para movimentar o player e pular, e também aumenta a velocidade do player constantemente
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetButton("Vertical"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        if (rb.linearVelocity.z <= 15)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, 0.01f + rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }

       /* if (contador >= 60)
        {
            aceleracao += 1f;
            contador = 0;
        }else
        {
            contador++;
        }*/

    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "fimFase" && alvo.alvosAcertados >= scriptAlvo.qtdAlvos)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//colocar depois .buildIndex + 1);

        }
        else if (hit.gameObject.tag == "fimFase")
        {

            life.Die();
        }

    }
}




