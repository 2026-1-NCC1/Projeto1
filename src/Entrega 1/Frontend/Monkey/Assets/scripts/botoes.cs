using UnityEngine;
using UnityEngine.SceneManagement;

public class botoes : MonoBehaviour
{

    public void TentarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
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