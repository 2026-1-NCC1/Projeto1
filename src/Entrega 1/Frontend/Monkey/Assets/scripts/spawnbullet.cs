using UnityEngine;

public class spawnbullet : MonoBehaviour
{
    //variaveis para controlar o spawn do tiro do inimigo, a direcao do tiro e a velocidade do tiro, o tempo que ele vai esperar para atirar novamente.
    public Transform spawnPoint;
    public Transform playerObj;
    public float timer = 0.7f;
    private float bulletTime;
    public GameObject tiroInimigo;
    public float bulletSpeed = 12f;

    // Controla o disparo do inimigo, spawna o tiro em direcao ao player no intervalo definido pelo timer,
    // para de atirar se o player passou o inimigo no eixo Z
    void Update()
    {
        // para de atirar se o player passou o inimigo no eixo Z
        if (playerObj.position.z > transform.position.z)
        {
            return;
        }

        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        
        bulletTime = timer;
        GameObject bulletObj = Instantiate(tiroInimigo, spawnPoint.position, Quaternion.identity);
        Vector3 directionToPlayer = playerObj.position - spawnPoint.position;
        if (directionToPlayer.magnitude < 0.01f)
            directionToPlayer = Vector3.forward;
        directionToPlayer.Normalize();
        inimigos bulletScript = bulletObj.GetComponent<inimigos>();

        if (bulletScript != null)
        {
            bulletScript.SetDirection(directionToPlayer);
            bulletScript.speed = bulletSpeed;
        }
    }
}