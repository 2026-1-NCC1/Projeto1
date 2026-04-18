using UnityEngine;
using UnityEngine.UI;
public class alvosBonus : MonoBehaviour
{
    public Text textoAlvosBonus;
    public playerMove scriptPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            Destroy(gameObject);
            playerMove.pontos += 10;
            textoAlvosBonus.text = "Pontos:" + playerMove.pontos;
            Destroy(hit.gameObject);
        }
    }
}
