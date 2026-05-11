using UnityEngine;

public class rotateBox : MonoBehaviour
{
    //variaveis para controlar a velocidade de rotacao da caixa de municao
    public float speedX;
    public float speedY = 0.7f;
    public float speedZ;

    //faz a rotacao da caixa de municao no eixo Y
    void Update()
    {
        transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime);
    }

}
