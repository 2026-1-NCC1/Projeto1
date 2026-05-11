using UnityEngine;
using UnityEngine.UI;

public class destruirObjetosTiro : MonoBehaviour
{
    //declaracao de variaveis a serem utilizadas para o texto dos pontos e dos alvos, alem da quantidade deles
    Text textoAlvos;
    Text textoPontos;
    public static int alvosAcertados = 0;
    public static int qtdAlvos = 3;

    // Inicializa o contador de alvos e busca os textos de UI pelas tags na cena
    private void Start()
    {
        alvosAcertados = 0;
        textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
        textoPontos = GameObject.FindWithTag("textoPontos").GetComponent<Text>();
    }

    // Verifica a tag do objeto atingido pelo projetil e adiciona pontos de acordo,
    // alem de atualizar os textos de UI e destruir tanto o alvo quanto o projetil
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            if (gameObject.tag == "alvos")
            {
                alvosAcertados++;
                textoAlvos.text = "Alvos:" + alvosAcertados;
                playerMove.pontos += 5;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            else if (gameObject.tag == "alvoBonus")
            {
                playerMove.pontos += 10;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            else if (gameObject.tag == "inimigo")
            {
                playerMove.pontos += 15;
                textoPontos.text = "Pontos:" + playerMove.pontos;
            }
            Destroy(gameObject);
            Destroy(hit.gameObject);
        }
    }
}