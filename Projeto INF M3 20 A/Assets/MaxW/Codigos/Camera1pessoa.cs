using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Esse codigo tem como utilidade rotacionar 
/// no eixo "Z" na camera em primeira pessoa.
/// 
/// </summary>

public class Camera1pessoa : MonoBehaviour
{
    //Essa variavel do tipo float leva o valor da sensibilidade(ajustavel dentro da unity)
    //esta presente na mutiplicação ao obter a posição do mouse no exioY
    public      float       sensibilidade   =   2f;

    //Variavel Publica do tipo Float
    //
    public      float       mouseY          =   0f;

    void Update()
    {
        mouseY = mouseY + (Input.GetAxis("Mouse Y") * sensibilidade);
        if(mouseY > 60)
        {
            mouseY = 60f;
        }
        if (mouseY < -55)
        {
            mouseY = -55f;
        }
        transform.localEulerAngles = new Vector3(x: 0,y: 0,z: mouseY);
    }
    
}
