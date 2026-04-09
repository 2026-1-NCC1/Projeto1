using UnityEngine;
using UnityEngine.UI;

public class Municao : MonoBehaviour

{
    //variavel em comentario vai ser usada para mostrar a quantidade de municao que o jogador tem (feedback), a variavel municao é a quantidade de municao que o jogador tem
    //[SerializeField] Text textoMunicao;
    public int municao = 3;

    //caso passe pela caixa de munição, o jogador coleta a munição e o texto na tela (feedback) é atualizado (o comentario vai ser usado futuramente)
    private void OnTriggerEnter(Collider hit)
    {
        //verifica se bateu na caixa de munição, se sim coleta a munição e mostra isso pro jogador
        if (hit.gameObject.tag == "ammo")

        {
            Destroy(hit.gameObject);
            municao = 3;
            //atualizarMunicao();

        }

    }
    //metodo comentado que atualiza o texto da municao (feedback para o jogador)
    /*public void atualizarMunicao()
    {
        textoMunicao.text = "Munição:" + municao;
    }*/
}

