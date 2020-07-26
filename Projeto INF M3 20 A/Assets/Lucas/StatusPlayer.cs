using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.UIElements;

public class StatusPlayer : MonoBehaviour
{
    /// <summary>
    /// Variável para guardar o nome do personagem
    /// </summary>
    string nome = "";

    /// <summary>
    /// Variável para guardar valor da velocidade normal do personagem
    /// </summary>
    float velocidade;

    /// <summary>
    /// Velocidade para guardar a velocidade máxima ao fazer com que o personagem corra
    /// </summary>
    float velocidadeCorrer;

    /// <summary>
    /// Variável para validar se personagem está correndo
    /// </summary>
    private bool ativarCorrer = false;

    /// <summary>
    /// Variável para controlar qual é o seu personagem
    /// </summary>
    bool meuJogador = false;

    /// <summary>
    /// Variável para validar se personagem está pegando ou fugindo
    /// Se false = fugindo
    /// Se true = pegando
    /// </summary>
    bool pegador = false;


    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// Encontrar uma forma de validar se é o seu jogador, através da cor
        /// </summary>
        /*if ()
        {
            meuJogador = true;
        }
        */





        /// <summary>
        /// Quando apertar a tecla shift (da esquerda), a variável receberá valor true
        /// </summary>
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ativarCorrer = true;
        }

        /// <summary>
        /// Quando ativarCorrer for true
        /// a velocidade subirá gradativamente 
        /// até receber o valor de velocidadeCorrer,
        /// durante um Time.deltaTime
        /// </summary>
        if (ativarCorrer == true)
        {
            velocidade = Mathf.Lerp(velocidade, velocidadeCorrer, Time.deltaTime);
        }
    }
}
