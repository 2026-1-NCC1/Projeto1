using UnityEngine;

public class inimigos : MonoBehaviour
{
    public float speed = 12f;
    public float life = 3f;
    private Vector3 direction;
    private bool hasDirection = false;

    void Start()
    {
        Destroy(gameObject, life);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        hasDirection = true;
    }

    void Update()
    {
        if (hasDirection)
        {
            // Move na direção definida
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    // Usando TRIGGER 
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("limites") || other.CompareTag("obstaculos") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
