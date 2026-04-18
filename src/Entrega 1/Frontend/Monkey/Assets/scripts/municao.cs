using UnityEngine;
using UnityEngine.UI;

public class Municao : MonoBehaviour

{
    //variavel para mostrar a quantidade de municao que o jogador tem (feedback), e a variavel municao é a quantidade de municao que o jogador tem
    [SerializeField] Text textoMunicao;
    public int municao = 6;
    int qtdMaxMunicao = 6;
    int qtdRecarga = 3;

    //caso passe pela caixa de munição, o jogador coleta a munição e o texto é atualizado
    private void OnTriggerEnter(Collider hit)
    {
        //verifica se bateu na caixa de munição, se sim coleta a munição e mostra isso pro jogador
        if (hit.gameObject.tag == "ammo")

        {
            Destroy(hit.gameObject);

            // Estrutura condicional para não deixar o player utrapassar a quantidade máxima de munição
            if (municao < qtdMaxMunicao)
            {
                if(municao + qtdRecarga < qtdMaxMunicao)
                {
                    municao += qtdRecarga;
                }
                else
                {
                    municao = qtdMaxMunicao;
                }
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

