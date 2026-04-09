using UnityEngine;

public class MoviDirecionado : MonoBehaviour
{
    //listar as variaveis tanto do script SapwnerControler quanto as que foram criadas aqui
    private Vector3 direcao;
    private float velocidade;
    private float tempoVida;
    private float timer;
    private bool inicializado = false;

    //funcao para puxar as variaveis do outro scritpt como tambem declarar o valor das criadas aqui
    public void Inicializar(Vector3 dir, float vel, float vida)
    {
        direcao = dir;
        velocidade = vel;
        tempoVida = vida;
        timer = 0f;
        inicializado = true;
    }
    // start vazio novamente porque usar� apenas o trigger do click para funcionar
    void Start()
    {
        
    }

    
    void Update()
    {
        //quando iniciado ele comeca a contar a quano tempo o tiro esta em tela para destruir ele quando o tempo for maior que o timer
        if (!inicializado) return;

        transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= tempoVida)
        {
            Destroy(gameObject);
        }

        
    }

    //Refazer para ele destruir o alvo
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("limites") /*|| other.CompareTag("inimigos")*/)
        {
            Destroy(gameObject);
        }
    }
}
