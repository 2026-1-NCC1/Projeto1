using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // botão para usuário iniciar o jogo
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Nivel01");
    }
}
