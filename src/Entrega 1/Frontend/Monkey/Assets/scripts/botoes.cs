using UnityEngine;
using UnityEngine.SceneManagement; 

// Classe para controlar os botões de navegação entre cenas do jogo
public class botoes : MonoBehaviour
{
    // Reinicia a cena anterior (usada geralmente na tela de "Game Over")
    public void TentarNovamente()
    {
        // Carrega a cena com índice anterior ao da cena atual no Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Inicia o jogo carregando a primeira fase
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Nivel01"); // Carrega a cena chamada "Nivel01"
    }

    // Volta para o menu principal
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); // Carrega a cena chamada "Menu"
    }
}