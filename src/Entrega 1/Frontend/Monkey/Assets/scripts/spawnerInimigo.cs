using UnityEngine;
using UnityEngine.UI;

public class spawnerInimigo : MonoBehaviour
{
    //organizar variaveis que serão controladas pelo inspector, declaracao de variaveis do texto que vai ser usado para feedback de alvos acertados, a quantidade de alvos acertados e a quantidade total de alvos na fase
    [Header("Configurações")]
    public GameObject tiroInimigo;
    float veloMovimento = 30f;
    float tempoVida = 4f;
    GameObject jogador;
    

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Spawnar();
        
    }

    // funcao para spawnar o tiro uma posicao na frente do player e direcionar o tiro para a posicao do click
    void Spawnar()
    {
        Ray raio = Camera.main.ScreenPointToRay(jogador.transform.position);
        RaycastHit hit;
        Vector3 posicaoInimigo = new Vector3(1.1f, 2.48f, 88);

        ////quando o raio colidir com algo ele pega a posicao do click ele atira e cria um novo objeto sapawnado que some no tempo determinado
        if (Physics.Raycast(raio, out hit))
        {
            //verifica se acerto o trigger do alvo
            if (hit.collider.CompareTag("Player"))
            {
                // Cria o tiro
                GameObject novoTiro = Instantiate(tiroInimigo, posicaoInimigo, Quaternion.identity);

                //pega o componente do movimento direcionado do tiro no outro scrpit
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                // Inicializa com o movimento da funcao InicializarSeguir
                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);

                Debug.Log("TIRO SEGUE: " + hit.collider.name);

            }
        }
    }
}