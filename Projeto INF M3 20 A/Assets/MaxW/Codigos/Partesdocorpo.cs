using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class Partesdocorpo : MonoBehaviour
{
    private Transform parte;
    private Transform corpo;

    public int eixoX;
    public int eixoY;
    public int eixoZ;

    public int rotacaoZ;
    private bool inversor;

    private float[] cronometro = new float[3];

    public void Start()
    {
        parte = GetComponent<Transform>();
        corpo = GameObject.FindWithTag("Corpo").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cronometro[0] = Time.fixedTime;

        Direito();
    }
    public void Direito()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (inversor == false && (cronometro[1] < cronometro[0]))
            {
                parte.transform.localPosition = (new Vector3(x: corpo.localPosition.x - eixoX, y: corpo.localPosition.y - eixoY, z: corpo.localPosition.z + eixoZ));
                parte.transform.localEulerAngles = new Vector3(x: corpo.localEulerAngles.x, y: corpo.localEulerAngles.y, z: corpo.localEulerAngles.z - rotacaoZ);

                cronometro[2] = cronometro[0] + 0.3f;
                inversor = true;
            }
            else if (inversor == true && (cronometro[2] < cronometro[0]))
            {
                parte.transform.localPosition = (new Vector3(x: corpo.localPosition.x + eixoX, y: corpo.localPosition.y - eixoY, z: corpo.localPosition.z + eixoZ));
                parte.transform.localEulerAngles = new Vector3(x: corpo.localEulerAngles.x, y: corpo.localEulerAngles.y, z: corpo.localEulerAngles.z + rotacaoZ);

                cronometro[1] = cronometro[0] + 0.3f;
                inversor = false;
            }
        }
        else
        {
            parte.transform.localPosition = (new Vector3(x: corpo.localPosition.x, y: corpo.localPosition.y - eixoY, z: corpo.localPosition.z + eixoZ));
            parte.transform.localEulerAngles = new Vector3(x: corpo.localEulerAngles.x, y: corpo.localEulerAngles.y, z: corpo.localEulerAngles.z);
        }
    }
}
