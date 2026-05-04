using UnityEngine;

public class destruirObjetos : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            Destroy(gameObject);
            Destroy(hit.gameObject);

        }
    }
}
