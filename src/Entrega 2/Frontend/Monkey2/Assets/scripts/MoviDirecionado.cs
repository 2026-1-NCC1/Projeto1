using UnityEngine;

public class moviDirecionado : MonoBehaviour
{
    //listar as variaveis tanto do script SapwnerControler quanto as que foram criadas aqui
    private Vector3 direcao;
    private float velocidade;
    private float tempoVida;
    private float timer;
    private bool inicializado = false;
    private Transform alvo;  

    //metodos para puxar as variaveis do outro scritpt como tambem declarar o valor das criadas aqui
    public void Inicializar(Vector3 dir, float vel, float vida)
    {
        direcao = dir;
        velocidade = vel;
        tempoVida = vida;
        timer = 0f;
        inicializado = true;
        alvo = null;
    }
    
    // Metodo 
    public void InicializarSeguir(Transform inimigo, float vel, float vida)
    {
        alvo = inimigo;
        velocidade = vel;
        tempoVida = vida;
        timer = 0f;
        inicializado = true;
    }

    void Update()
    {
        if (!inicializado) return;

        // quando iniciado ele verifica se alvo diferente de nulo
        if (alvo != null)
        {
            // Verifica se o alvo ainda existe
            if (alvo.gameObject == null)
            {
                Destroy(gameObject);
                return;
            }
            
            // Move em direcao ao alvo (atualizado a cada frame)
            Vector3 direcaoAlvo = (alvo.position - transform.position).normalized;
            transform.Translate(direcaoAlvo * velocidade * Time.deltaTime, Space.World);
        }
        // //quando iniciado e alvo = a nulo ele segue um movimento reto 
        else
        {
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
        }
        //conta o tempo para sumir do mapa
        timer += Time.deltaTime;
        if (timer >= tempoVida)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="limites" || collision.gameObject.tag=="obstaculos" || collision.gameObject.tag=="fimFase")
        {
            Destroy(gameObject);
        }
    }
}