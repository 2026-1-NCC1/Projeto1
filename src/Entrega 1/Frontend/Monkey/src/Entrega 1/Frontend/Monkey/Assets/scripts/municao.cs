using UnityEngine;
using UnityEngine.UI;

public class Municao : MonoBehaviour

{
    //[SerializeField] Text textoMunicao;
    public int municao = 3;

    void Update()
    {

    }

    //caso passe pela caixa de munição, o jogador coleta a munição e o texto é atualizado
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
    /*public void atualizarMunicao()
    {
        textoMunicao.text = "Munição:" + municao;
    }*/
}

