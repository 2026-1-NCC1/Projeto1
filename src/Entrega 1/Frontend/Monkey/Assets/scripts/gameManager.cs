using UnityEngine;

public class gameManager : MonoBehaviour
{
    //um gerenciador que une todos os scripts para facilitar a edicao de variaveis e o controle do jogo
    GameObject jogador;
    [Header("Stats Player")]
    [SerializeField] float velocidade;
    [SerializeField] float pulo;
    
    void Start()
    {
       //pega o  game object do player e muda a velocidade e o pulo do player para os valores determinados no inspector, facilitando a edicao desses valores
       jogador = GameObject.FindWithTag("Player");
       jogador.GetComponent<playerMove>().moveSpeed = velocidade;
       jogador.GetComponent<playerMove>().jumpForce = pulo;
    }

}
