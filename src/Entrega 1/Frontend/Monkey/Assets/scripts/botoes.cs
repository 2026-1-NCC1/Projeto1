using UnityEngine;
using UnityEngine.SceneManagement; 

// Classe para controlar os bot�es de navega��o entre cenas do jogo
public class botoes : MonoBehaviour
{
    // Reinicia a cena anterior (usada geralmente na tela de "Game Over")
    public void TentarNovamente()
    {
        int fase = PlayerPrefs.GetInt("FaseAtual"); // pega o valor da vari�vel chamada "FaseAtual"
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

    // Avan�a para o pr�xima cena
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

    public void Quit()
    {
      Debug.Log("Saindo do jogo...");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif  
    }
}