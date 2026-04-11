using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    bool dead = false;

    void Start()
    {

    }

    void Update()
    {
        if ((transform.position.y < -1.5f) && (dead == false))
        {
            Die();
        }
    }

   /* private void OnTriggerEnter(Collider hit)
    {
        if ((hit.gameObject.tag == "obstaculos") || hit.gameObject.tag == "limites")
        {
            Die();
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "alvos" || collision.gameObject.tag == "obstaculos" || collision.gameObject.tag == "limites")
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<playerMove>().enabled = false;
        dead = true;
        Invoke(nameof(GameOver), 0.8f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
