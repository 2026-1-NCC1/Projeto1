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
       //pega o raio da câmera e a posição do player +1 para o tiro sempre sair do player
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 posicaoPlayer = player.transform.position + new Vector3(0,0,1);

        //quando o raio colidir com algo ele pega a posição do click ele atira e cria um novo objeto sapawnado que some no tempo determinado
        if (Physics.Raycast(raio, out hit))
        {
            Vector3 posicaoClique = hit.point;
            Vector3 posicaoSpawn = posicaoPlayer;
            GameObject novoObjeto = Instantiate(tiro, posicaoSpawn, Quaternion.identity);
            Vector3 direcao = (posicaoClique - posicaoSpawn).normalized;

            MoviDirecionado movimento = novoObjeto.AddComponent<MoviDirecionado>();
            movimento.Inicializar(direcao, veloMovimento, tempoVida);
        }
    }
}
