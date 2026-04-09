using UnityEngine;
using UnityEngine.UI;
public class alvo : MonoBehaviour
{
    //declaracao de variaveis do texto que vai ser usado para feedback de alvos acertados(comentario), a quantidade de alvos acertados e a quantidade total de alvos na fase
    //public Text textoAlvos;
    public static int alvosAcertados = 0;
    public int qtdAlvos = 3;

    //metodo que inicia a quantidade de alvos acertados em 0 e o comentario pega o componente de texto que mostrara a quantidade de alvos acertados (feedback para o player)
    void Start()
    {
        alvosAcertados = 0;
        //textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
    }

    //metodo que detecta a colisao do projetil com o alvo, incrementa a quantidade de alvos acertados e destroi o alvo (o comentario vai se tornar o feedback para o player)
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            alvosAcertados++;
            Destroy(gameObject);
            //textoAlvos.text = "Alvos:" + alvosAcertados;
        }
    }
}
