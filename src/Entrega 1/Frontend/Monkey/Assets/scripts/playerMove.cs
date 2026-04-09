using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    //declaracao de variaveis do rigidbody do player, a velocidade de movimento, a força do pulo, a velocida maxima do player
    //o script do alvo para verificar a quantidade de alvos acertados e a vida do player para chamar o metodo de morte de outro script
  
    Rigidbody rb;
    public float moveSpeed = 8f;
    public float jumpForce = 8f;
    public float velocidadeMaxima = 15f;
    [SerializeField] alvo scriptAlvo;
    public playerLife life;
    

    //metodo que inicia a quantidade de alvos acertados em 0, pega o componente de rigidbody do player para facilitar a escrita depois
    void Start()
    {
        alvo.alvosAcertados = 0;
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
        //limitador de velocidade para evitar que o player fique muito rapido, aumentando a dificuldade porém sem deixar impossivel de controlar
        if (rb.linearVelocity.z <= velocidadeMaxima)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, 0.01f + rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }
    }

    //metodo que detecta a colisao do player com o fim da fase, e verifica se o player acertou a quantidade de alvos necessaria para passar de fase,
    //se sim ele carrega a proxima fase, caso contrario (e tenha acertado o fim da fase) chama o metodo de morte do jogador
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




