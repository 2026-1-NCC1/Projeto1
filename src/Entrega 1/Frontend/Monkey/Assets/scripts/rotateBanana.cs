using UnityEngine;

public class rotateBanana : MonoBehaviour
{
    //variaveis para controlar a velocidade de rotacao da caixa de municao
    float speedX;
    float speedY;
    float speedZ=5f;

    //faz a rotacao da caixa de municao no eixo Y

    private void Start()
    {
        transform.Rotate(0, 90, 0);
    }
    void Update()
    {
        transform.Rotate(360 * speedX * Time.deltaTime, speedY, 360 * speedZ * Time.deltaTime);

    }

}
