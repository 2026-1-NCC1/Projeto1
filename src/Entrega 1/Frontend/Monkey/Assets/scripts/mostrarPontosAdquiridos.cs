using UnityEngine;
using UnityEngine.UI;
public class mostrarPontosAdquiridos : MonoBehaviour
{
    //variavel que contem o texto de quantos alvos o jogador acertou
    [SerializeField] Text textoPontos;

    //mostra quantos alvos o jogador acertou, na tela de game over
    void Start()
    {
        textoPontos.text = "Você conseguiu " + playerMove.pontos  + " pontos";
    }
}
