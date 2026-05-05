using UnityEngine;
using UnityEngine.UI;
public class mostrarAlvosAcertados : MonoBehaviour
{
    //variavel que contem o texto de quantos alvos o jogador acertou
    [SerializeField] Text textoAlvos;

    //mostra quantos alvos o jogador acertou, na tela de game over
    void Start()
    {
        textoAlvos.text = "Você acertou " + spawnerControler.alvosAcertados + "/" + spawnerControler.qtdAlvos + " alvos";
    }
}
