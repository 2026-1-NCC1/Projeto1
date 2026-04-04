using UnityEngine;

public class gameManager : MonoBehaviour
{
    GameObject jogador;
    [Header("Stats Player")]
    [SerializeField] float velocidade;
    [SerializeField] float pulo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       jogador = GameObject.FindWithTag("Player");
       jogador.GetComponent<playerMove>().moveSpeed = velocidade;
       jogador.GetComponent<playerMove>().jumpForce = pulo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
