using UnityEngine;
using UnityEngine.UI;

public class spawnerControler : MonoBehaviour
{
    //organizar variaveis que serão controladas pelo inspector, declaracao de variaveis do texto que vai ser usado para feedback de alvos acertados, a quantidade de alvos acertados e a quantidade total de alvos na fase
    [Header("Configurações")]
    public GameObject tiro;
    public float veloMovimento = 5f;
    public float tempoVida = 3f;
    public GameObject player;
    [SerializeField] Municao municaoScript;

    Text textoAlvos;
    public Text textoPontos;
    public static int alvosAcertados = 0;
    public static int qtdAlvos = 3;

    private void Start()
    {
        alvosAcertados = 0;
        textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
    }

    void Update()
    {
        //se tem municao suficiente, pega o input do mouse click esquerdo para fazer o tiro spawnar e pega a localizaçao do player
        //diminui uma bala da variavel municao e atualiza o texto de municao para mostrar a quantidade atualizada de balas (feedback visual)
        if (Input.GetMouseButtonDown(0) && (municaoScript.municao > 0))
        {
            Spawnar();
            player = GameObject.FindGameObjectWithTag("Player");
            municaoScript.municao--;
            municaoScript.atualizarMunicao();
        }
    }

    // funcao para spawnar o tiro uma posicao na frente do player e direcionar o tiro para a posicao do click
    void Spawnar()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 posicaoPlayer = player.transform.position + new Vector3(0, 0, 1);

        ////quando o raio colidir com algo ele pega a posicao do click ele atira e cria um novo objeto sapawnado que some no tempo determinado
        if (Physics.Raycast(raio, out hit))
        {
            //verifica se acerto o trigger do alvo
            if (hit.collider.CompareTag("alvos"))
            {
                // Cria o tiro
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);

                //pega o componente do movimento direcionado do tiro no outro scrpit
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                // Inicializa com o movimento da funcao InicializarSeguir
                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);

                Debug.Log("TIRO SEGUE: " + hit.collider.name);

                alvosAcertados++;
                textoAlvos.text = "Alvos:" + alvosAcertados;
                playerMove.pontos += 5;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            //verifica se acerto o trigger do alvo bonus
            else if (hit.collider.CompareTag("alvoBonus"))
            {
                // Cria o tiro
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);

                //pega o componente do movimento direcionado do tiro no outro scrpit
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                // Inicializa com o movimento da funcao InicializarSeguir
                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);

                Debug.Log("TIRO SEGUE: " + hit.collider.name);

                playerMove.pontos += 10;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            else if (hit.collider.CompareTag("inimigos"))
            {
                // Cria o tiro
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);

                //pega o componente do movimento direcionado do tiro no outro scrpit
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                // Inicializa com o movimento da funcao InicializarSeguir
                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);

                Debug.Log("TIRO SEGUE: " + hit.collider.name);

                playerMove.pontos += 15;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            else
            {
                // Tiro normal sem o trigger do alvo
                Vector3 posicaoClique = hit.point;
                Vector3 posicaoSpawn = posicaoPlayer;
                GameObject novoTiro = Instantiate(tiro, posicaoSpawn, Quaternion.identity);
                Vector3 direcao = (posicaoClique - posicaoSpawn).normalized;

                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();
                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();


                    movimento.Inicializar(direcao, veloMovimento, tempoVida);
                    Debug.Log("TIRO RETO");
                }
            }
        }
    }
}