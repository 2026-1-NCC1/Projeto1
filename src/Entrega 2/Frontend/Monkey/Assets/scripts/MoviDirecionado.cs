using UnityEngine;

public class moviDirecionado : MonoBehaviour
{
    // Variaveis que guardam as informacoes do projetil/objeto, recebidas do SpawnerControler ou definidas aqui
    private Vector3 direcao;
    private float velocidade;
    private float tempoVida;
    private float timer;
    private bool inicializado = false;
    private Transform alvo;

    // Metodo chamado quando o objeto vai se mover em linha reta, recebendo direcao, velocidade e tempo de vida do SpawnerControler
    public void Inicializar(Vector3 dir, float vel, float vida)
    {
        direcao = dir;
        velocidade = vel;
        tempoVida = vida;
        timer = 0f;
        inicializado = true;
        alvo = null;
    }

    // Metodo chamado quando o objeto vai perseguir um inimigo, recebendo o Transform do inimigo, velocidade e tempo de vida
    public void InicializarSeguir(Transform inimigo, float vel, float vida)
    {
        alvo = inimigo;
        velocidade = vel;
        tempoVida = vida;
        timer = 0f;
        inicializado = true;
    }

    // Update é chamado uma vez por frame pelo Unity
    void Update()
    {
        // Se o objeto ainda nao foi inicializado, nao faz nada
        if (!inicializado) return;

        // Verifica se existe um alvo para perseguir
        if (alvo != null)
        {
            // Se o GameObject do alvo foi destruido, destroi esse objeto tambem e para a execucao
            if (alvo.gameObject == null)
            {
                Destroy(gameObject);
                return;
            }

            // Calcula a direcao ate o alvo e normaliza
            Vector3 direcaoAlvo = (alvo.position - transform.position).normalized;
            // Move o objeto em direcao ao alvo 
            transform.Translate(direcaoAlvo * velocidade * Time.deltaTime, Space.World);
        }
        // Se nao tem alvo, o objeto simplesmente vai em linha reta na direcao definida
        else
        {
            // Move o objeto em linha reta usando a direcao e velocidade configuradas
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
        }

        // Soma o tempo que passou desde o ultimo frame ao contador
        timer += Time.deltaTime;
        // Se o contador passou do tempo de vida, destroi o objeto
        if (timer >= tempoVida)
        {
            Destroy(gameObject);
        }
    }

    // Método para quando esse objeto colide com limite, obstaculo ou fim de fase para destruir o objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Se colidiu com os limites do mapa, obstáculos ou o fim da fase, destrói o objeto
        if (collision.gameObject.tag == "limites" || collision.gameObject.tag == "obstaculos" || collision.gameObject.tag == "fimFase")
        {
            Destroy(gameObject);
        }
    }
}