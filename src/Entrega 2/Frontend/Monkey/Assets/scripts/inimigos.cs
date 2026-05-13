using UnityEngine;

public class inimigos : MonoBehaviour
{
    public float speed = 12f;
    public float life = 3f;
    private Vector3 direction;
    private bool hasDirection = false;

    // Destroi o objeto automaticamente apos o tempo de vida definido
    void Start()
    {
        Destroy(gameObject, life);
    }

    // Recebe a direcao do spawnbullet e marca que ja tem uma direcao definida
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        hasDirection = true;
    }

    // Move o tiro na direcao definida enquanto tiver uma direcao valida
    void Update()
    {
        if (hasDirection)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    // Destroi o tiro ao colidir com limites, obstaculos ou fim de fase
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "limites" || collision.gameObject.tag == "obstaculos" || collision.gameObject.tag == "fimFase")
        {
            Destroy(gameObject);
        }
    }
}