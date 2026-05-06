using UnityEngine;

public class spawnbullet : MonoBehaviour
{
   
    public Transform spawnPoint;
    public Transform playerObj;
    public float timer = 0.3f;
    private float bulletTime;
    public GameObject tiroInimigo;
    public float bulletSpeed = 12f;

    public bool playerFrente = true;

    void Update()
    {

        if (playerFrente)
        {
            // Olha para FRENTE: para de atirar se player passou (Z maior)
            if (playerObj.position.z > transform.position.z)
            {
                return;
            }
        }
        else
        {
            // Olha para TRÁS: para de atirar se player passou (Z menor)
            if (playerObj.position.z < transform.position.z)
            {
                return;
            }
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
