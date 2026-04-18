using UnityEngine;
using UnityEngine.UI;
public class alvo : MonoBehaviour
{
    //declaracao de variaveis do texto que vai ser usado para feedback de alvos acertados, a quantidade de alvos acertados e a quantidade total de alvos na fase
    Text textoAlvos;
    public Text textoAlvosBonus;
    public static int alvosAcertados = 0;
    public static int qtdAlvos = 3;
    public playerMove scriptPlayer;


    //metodo que inicia a quantidade de alvos acertados em 0 e o pega o componente de texto que mostrara a quantidade de alvos acertados na tela.
    void Start()
    {
        alvosAcertados = 0;
        textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
    }


    //metodo que detecta a colisao do projetil com o alvo, incrementa a quantidade de alvos acertados e destroi o alvo
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            alvosAcertados++;
            Destroy(gameObject);
            textoAlvos.text = "Alvos:" + alvosAcertados;
            playerMove.pontos += 5;
            textoAlvosBonus.text = "Pontos:" + playerMove.pontos;
            Destroy(hit.gameObject);

        }
    }
}
