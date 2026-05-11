using UnityEngine;
using UnityEngine.UI;

public class Municao : MonoBehaviour

{
    //variavel para mostrar a quantidade de municao que o jogador tem (feedback), e a variavel municao e a quantidade de municao que o jogador tem
    [SerializeField] Text textoMunicao;
    public static int municao = 6;
    int qtdMaxMunicao = 6;
    int qtdRecarga = 3;

    private void Start()
    {
        municao = 6;
    }



    //caso passe pela caixa de municao, o jogador coleta a municao e o texto e atualizado
    private void OnTriggerEnter(Collider hit)
    {
        //verifica se bateu na caixa de municao, se sim coleta a municao e mostra isso pro jogador
        if (hit.gameObject.tag == "ammo")

        {
            Destroy(hit.gameObject);

            // Estrutura condicional para nao deixar o player utrapassar a quantidade maxima de municao
            if(municao + qtdRecarga < qtdMaxMunicao)
            {
                municao += qtdRecarga;
            }
            else
            {
                municao = qtdMaxMunicao;
            }
            
            atualizarMunicao();

        }

    }
    //metodo que atualiza o texto da municao (feedback para o jogador), o metodo foi criado pois é reutilizado em outro script
    public void atualizarMunicao()
    {
        textoMunicao.text = "Munição:" + municao;
    }
}

