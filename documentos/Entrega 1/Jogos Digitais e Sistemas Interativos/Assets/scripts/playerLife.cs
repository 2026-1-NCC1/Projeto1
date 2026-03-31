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
        if ((transform.position.y < -0.5f) && (dead == false))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if ((hit.gameObject.tag == "obstaculos") || hit.gameObject.tag == "limites" || hit.gameObject.tag == "alvos")
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<playerMove>().enabled = false;
        dead = true;
        Invoke(nameof(ReloadLevel), 0.8f);

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
