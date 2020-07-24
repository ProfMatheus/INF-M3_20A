using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimenta : MonoBehaviour
{

    private Transform movimento;
    private Rigidbody moviementofisico;

    private float boost;

    public float velocidade;

    public float sensibilidade = 2f;

    public bool travar = true;
    public float mouseX = 0f;

    void Start()
    {
        if (!travar)
        {
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        moviementofisico = GetComponent<Rigidbody>();
        movimento = GetComponent<Transform>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        mouseX = mouseX + (Input.GetAxis("Mouse X") * sensibilidade);
        movimento.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = 40;
        }
        else
        {
            boost = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movimento.transform.Translate((boost+velocidade) * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimento.transform.Translate(-((boost + velocidade) * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movimento.transform.Translate(0, 0, (boost + velocidade) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimento.transform.Translate(0, 0, -((boost + velocidade) * Time.deltaTime));
        }

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moviementofisico.velocity = new Vector3(0,3000,0);
        }
        else
        {
            moviementofisico.velocity = new Vector3(0, -50, 0);
        }
        */
    }

}
