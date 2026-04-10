using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 8f;
    public float jumpForce = 8f;
    public float aceleracao = 0.01f;
    public float velocidadeMaxima=15f;
    public int contador = 0;
    [SerializeField] alvo scriptAlvo;
    public playerLife life;

    int CurrentCena;

    void Start()
    {
        /*if(CurrentCena < 10)
        {
            aceleracao = SceneManager.sceneCount/0.1f;
        }else
        {
            aceleracao = SceneManager.sceneCount / 0.001f;
        }*/
        alvo.alvosAcertados = 0;
        //variavel para pegar o rigidbody do player mais facilmente
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        Debug.Log(Physics.gravity);
        if(rb.linearVelocity.y < 0){

            Physics.gravity = new Vector3(0, -18.0F, 0);

        }
        //pega o input do teclado para movimentar o player e pular, e também aumenta a velocidade do player constantemente
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetButton("Vertical"))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        if (rb.linearVelocity.z <= velocidadeMaxima * SceneManager.sceneCount)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, aceleracao + rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }
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




