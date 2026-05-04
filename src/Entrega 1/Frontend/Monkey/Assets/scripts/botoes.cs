using UnityEngine;
using UnityEngine.SceneManagement;

public class botoes : MonoBehaviour
{

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Nivel01"); // mudar depois para ir para a fase anterior
    }
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Nivel01");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
