using UnityEngine;
using UnityEngine.SceneManagement; 

// Classe para controlar os botões de navegação entre cenas do jogo
public class botoes : MonoBehaviour
{
    // Reinicia a cena anterior (usada geralmente na tela de "Game Over")
    public void TentarNovamente()
    {
        int fase = PlayerPrefs.GetInt("FaseAtual"); // pega o valor da variável chamada "FaseAtual"
        SceneManager.LoadScene(fase);
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

    // Avança para o próxima cena
    public void Avancar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Vai para a fase 1
    public void JogarFase1()
    {
        SceneManager.LoadScene("Nivel01");
    }

    // Vai para a fase 2
    public void JogarFase2()
    {
        SceneManager.LoadScene("Nivel02");
    }
}