using UnityEngine;

public class rotateBanana : MonoBehaviour
{
    //variaveis para controlar a velocidade de rotacao da banana
    float speedX;
    float speedY;
    float speedZ = 5f;

    //faz a rotacao inicial da banana no eixo Y e depois rotaciona a banana constantemente no eixo Z, girando no ar

    private void Start()
    {
        transform.Rotate(0, 90, 0);
    }
    void Update()
    {
        transform.Rotate(speedX, speedY, 360 * speedZ * Time.deltaTime);

    }

}