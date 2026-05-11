using UnityEngine;

public class spawnerControler : MonoBehaviour
{
    //organizar variaveis que serão controladas pelo inspector
    [Header("Configurações")]
    public GameObject tiro;
    public float veloMovimento = 5f;
    public float tempoVida = 3f;
    public GameObject player;
    [SerializeField] Municao municaoScript;

    // Verifica o input do clique esquerdo e se tem municao, spawna o tiro e atualiza a UI
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Municao.municao > 0))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Spawnar();
            Municao.municao--;
            municaoScript.atualizarMunicao();
        }
    }

    // Spawna o tiro na frente do player e decide se ele vai seguir um alvo ou seguir em linha reta,
    // dependendo da tag do objeto que o raycast acertou
    void Spawnar()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 posicaoPlayer = player.transform.position + new Vector3(0, 0, 1);

        if (Physics.Raycast(raio, out hit))
        {
            // acertou um alvo normal, tiro vai seguir o alvo
            if (hit.collider.CompareTag("alvos"))
            {
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);
                Debug.Log("TIRO SEGUE: " + hit.collider.name);
            }
            // acertou um alvo bonus, tiro vai seguir o alvo bonus
            else if (hit.collider.CompareTag("alvoBonus"))
            {
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);
                Debug.Log("TIRO SEGUE: " + hit.collider.name);
            }
            // acertou um inimigo, tiro vai seguir o inimigo
            else if (hit.collider.CompareTag("inimigo"))
            {
                GameObject novoTiro = Instantiate(tiro, posicaoPlayer, Quaternion.identity);
                moviDirecionado movimento = novoTiro.GetComponent<moviDirecionado>();

                if (movimento == null)
                {
                    movimento = novoTiro.AddComponent<moviDirecionado>();
                }

                movimento.InicializarSeguir(hit.collider.transform, veloMovimento, tempoVida);
                Debug.Log("TIRO SEGUE: " + hit.collider.name);
            }
            else
            {
                // Tiro normal sem seguir algum alvo
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