using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameOver : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // botão para o usuário tentar a fase novamente
    public void TentarNovamente()
    {
        SceneManager.LoadScene("Nivel01"); // mudar depois para ir para a fase anterior
    }
}
