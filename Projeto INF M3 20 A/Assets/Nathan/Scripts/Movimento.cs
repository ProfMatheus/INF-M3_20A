using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    //---------------------------------------------------------------VARIAVEIS------------------------------------------------------------------//

    public float Velocidade = 10;

    public float Girar = 200;

    private Rigidbody rigidbodyJogador;

    public Vector3 direcaoDoPulo = new Vector3(0, 1, 0);
    
    public float forcaDoPulo = 5.0f;
    
    public float DistanciaDoChao = 1;

    public float TempoPorPulo = 1.5f;

    public LayerMask LayersNaoIgnoradas = -1;

    private bool estaNoChao, contar = false;

    private float cronometro = 0;

    private Rigidbody corpoRigido;

    //------------------------------------------------------------------------------------------------------------------------------------------//

    /// <summary>
    /// Função chamada quando um script é ativado antes de qualquer método de atualização ser chamado pela primeira vez. 
    /// <see cref="corpoRigido"/> Está recebendo o componente Rigidbody.
    /// <see cref="rigidbodyJogador"/> Está recebendo o componente Rigidbody.
    /// </summary>
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();

        rigidbodyJogador = GetComponent<Rigidbody>();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------//

    /// <summary>
    /// Função que acontece a cada atualização de tela
    /// <see cref="estaNoChao"/> Retorna true se houver algum colisor cruzando a linha entre o início e o fim.
    /// </summary>
    void Update()
    {
        //-------------------------------------------------------------------PULAR-------------------------------------------------------------//
        
        estaNoChao = Physics.Linecast(transform.position, transform.position - Vector3.up * DistanciaDoChao, LayersNaoIgnoradas);


        //-------------------Este if é para acontecer o pulo e acionar o contador de tempo que o personagem ficará no ar-----------------------//
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == true && contar == false)
            {
                corpoRigido.AddForce(direcaoDoPulo * forcaDoPulo, ForceMode.Impulse);

                estaNoChao = false;

                contar = true;
            }
        
        //Caso aconteça o if acima, este if é para adicionar valor a variavel cronometro, tempo de conclusão em segundos desde o último quadro//
        if (contar == true)
            {
                cronometro += Time.deltaTime;
            }

        //--------Se o tempo de cronometro for maior igual ao tempo de pulo, contar passa a ser falso e reseta o valor de cronometro---------//
        if (cronometro >= TempoPorPulo)
        {
                contar = false;

                cronometro = 0;
        }

        //------------------------------------------------------MOVIMENTAÇÃO-------------------------------------------------------------------//

        //----------------------------------Retornando o valor das axisas para andar e girar o personagem-------------------------------------//
        float translate = (Input.GetAxis("Vertical") * Velocidade) * Time.deltaTime;

        float rotate = (Input.GetAxis("Horizontal") * Girar) * Time.deltaTime;

        //----------------------------Move suavemente o Rigidbody de um objeto entre os quadros-----------------------------------------------//
        rigidbodyJogador.MovePosition(rigidbodyJogador.position + (transform.forward * translate));

        //-----------------------------------Move o objeto enquanto também considera sua rotação.--------------------------------------------//
        Vector3 rotation = transform.up * rotate;
        
        //----------------------------------------------Transforma a rotação de numeros para angulos-----------------------------------------//
        Quaternion deltaRotation = Quaternion.Euler(rotation);

        //------------------Gira o Rigidbody para rotação. Gira continuamente um corpo rígido em cada atualização de tela-------------------//
        rigidbodyJogador.MoveRotation(rigidbodyJogador.rotation * deltaRotation);
    }
}
