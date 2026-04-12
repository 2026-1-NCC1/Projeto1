using UnityEngine;

public class SpawnerControler : MonoBehaviour
{
    //organizar variaveis que serão controladas pelo inspector
    [Header("Configurações")]
    public GameObject tiro;
    public float veloMovimento = 5f;
    public float tempoVida = 3f;
    public GameObject player;
    [SerializeField] Municao municaoScript;

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

    // função para spawnar o tiro uma posição na frente do player e direcionar o tiro para a posição do click
    void Spawnar()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 posicaoPlayer = player.transform.position + new Vector3(0, 0, 1);

        ////quando o raio colidir com algo ele pega a posição do click ele atira e cria um novo objeto sapawnado que some no tempo determinado
        if (Physics.Raycast(raio, out hit))
        {
            //verifica se acerto o trigger do alvo
            if (hit.collider.CompareTag("alvos"))
            {
                // Cria o tiro
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);
                
                //pega o componente do movimento direcionado do tiro no outro scrpit
                MoviDirecionado movimento = novoTiro.GetComponent<MoviDirecionado>();
                
                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<MoviDirecionado>();
                }
                
                // Inicializa com o movimento da função InicializarSeguir
                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);
                
                Debug.Log("TIRO SEGUE: " + hit.collider.name);
            }
            else
            {
                // Tiro normal sem o trigger do alvo
                Vector3 posicaoClique = hit.point;
                Vector3 posicaoSpawn = posicaoPlayer;
                GameObject novoTiro = Instantiate(tiro, posicaoSpawn, Quaternion.identity);
                Vector3 direcao = (posicaoClique - posicaoSpawn).normalized;

                MoviDirecionado movimento = novoTiro.GetComponent<MoviDirecionado>();
                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<MoviDirecionado>();
                }
                
                movimento.Inicializar(direcao, veloMovimento, tempoVida);
                Debug.Log("TIRO RETO");
            }
        }
    }
}