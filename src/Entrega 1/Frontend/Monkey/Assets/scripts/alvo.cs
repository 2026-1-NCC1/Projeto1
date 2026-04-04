using UnityEngine;
using UnityEngine.UI;
public class alvo : MonoBehaviour
{
    //public Text textoAlvos;
    public static int alvosAcertados = 0;
    public int qtdAlvos = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //textoAlvos = GameObject.FindWithTag("textoAlvos").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "projetil")
        {
            alvosAcertados++;
            Destroy(gameObject);
            //textoAlvos.text = "Alvos:" + alvosAcertados;
        }
    }
}
