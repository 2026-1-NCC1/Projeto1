using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    //declaracao de variaveis do rigidbody do player, a velocidade de movimento, a for�a do pulo, a velocida maxima do player
    //o script do alvo para verificar a quantidade de alvos acertados e a vida do player para chamar o metodo de morte de outro script
    //os pontos do jogador, e o texto para mostrar os pontos (feedback)

    Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float aceleracao = 0.01f;
    public float velocidadeMaxima = 15f;
    [SerializeField] spawnerControler scriptAlvo;
    public playerLife life;
    public static int pontos = 0;
    

    //metodo que inicia a quantidade de alvos acertados em 0, pega o componente de rigidbody do player para facilitar a escrita depois
    void Start()
    {
        spawnerControler.alvosAcertados = 0;
        pontos = 0;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //no momento da queda do pulo, a gravidade � aumentada para o player cair mais r�pido, dando uma sensacao melhor de queda
        if (rb.linearVelocity.y <= 0){

            Physics.gravity = new Vector3(0, -19.0F, 0);

        }
        //pega o input do teclado para pular, e toda vez que ele pula a gravidade volta ao normal durante a subida
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetButton("Vertical"))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        //pega o input do teclado para movimentar o player, aumenta a velocidade do player constantemente, contanto que nao tenha ultrapassado a velocidade maxima da fase
        // que aumenta a cada fase para dar uma sensacao de progresso e desafio, se o fosse ultrapassar a velocidade maxima, ele continua se movendo com a velocidade atual
        if (rb.linearVelocity.z <= velocidadeMaxima * SceneManager.sceneCount)
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, aceleracao + rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        }

        //variavel aceleracao para aumentar a velocidade do player constantemente, de acordo com o tempo para ser gradual e para o player conseguir se adaptar
        aceleracao += 0.005f * Time.deltaTime;
    }

    //metodo que detecta a colisao do player com o fim da fase, e verifica se o player acertou a quantidade de alvos necessaria para passar de fase,
    //se sim ele carrega a proxima fase (como ainda nao tem proxima fase, ele volta pro comeco), caso contrario (e tenha acertado o fim da fase) chama
    //o metodo de morte do jogador
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "fimFase" && spawnerControler.alvosAcertados >= spawnerControler.qtdAlvos)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//colocar depois .buildIndex + 1);

        }
        else if (hit.gameObject.tag == "fimFase")
        {
            life.Die();
            //chegou no final da fase mas n acertou todos os alvos 
        }
    }


}




