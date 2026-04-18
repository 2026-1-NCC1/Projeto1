using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    //variavel para verificar se o jogador esta morto ou nao, para evitar que o metodo de morte seja chamado mais de uma vez
    bool dead = false;

    //metodo que verifica se o jogador caiu do mapa, caso sim chama o metodo de morte
    void Update()
    {
        if ((transform.position.y < -1.5f) && (dead == false))
        {
            Die();
        }
    }

    //metodo que verifica se o jogador colidiu com um obstaculo, limite ou alvo, caso tenha chama o metodo de morte
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "alvos" || collision.gameObject.tag == "obstaculos" || collision.gameObject.tag == "limites")
        {
            Die();
            //bateu em algum desses
        }
    }

    //metodo que desativa o mesh renderer, o rigidbody e o script de movimento do jogador (assim o personagem some e nao se move mais
    //Alem de chamar o metodo de game over (UI/feedback de q ele perdeu) apos um curto periodo de tempo
    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<playerMove>().enabled = false;
        dead = true;
        Invoke(nameof(GameOver), 0.8f);
    }

    //metodo que carrega a cena de game over (feedback visual de que perdeu)
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
