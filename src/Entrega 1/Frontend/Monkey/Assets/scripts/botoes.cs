using UnityEngine;
using UnityEngine.SceneManagement;

public class botoes : MonoBehaviour
{
    public void TentarNovamente()
    {
        int fase = PlayerPrefs.GetInt("FaseAtual");
        SceneManager.LoadScene(fase);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Nivel01");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Avancar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void JogarFase1()
    {
        SceneManager.LoadScene("Nivel01");
    }

    public void JogarFase2()
    {
        SceneManager.LoadScene("Nivel02");
    }
}