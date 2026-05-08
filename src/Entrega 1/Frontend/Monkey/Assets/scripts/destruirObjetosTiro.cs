using UnityEngine;
using UnityEngine.UI;

public class destruirObjetosTiro : MonoBehaviour
{
    Text textoAlvos;
    Text textoPontos;
    public static int alvosAcertados = 0;
    public static int qtdAlvos = 3;

    private void Start()
    {
        alvosAcertados = 0;
        textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
        textoPontos = GameObject.FindWithTag("textoPontos").GetComponent<Text>();
    }

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