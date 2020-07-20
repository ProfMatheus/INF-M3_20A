using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// O script <see cref="ControlInput"/> pertence à <see cref="MonoBehaviour"/>.
/// Esse script verifica os Inputs feitos pelo player (jogador) e baseado neles define os valores das variáveis booleanas correspondentes
/// </summary>
public class ControlInput : MonoBehaviour
{

    /// <summary>
    /// iSpace é a variável booleana que recebe o valor true quando a tecla Espaço é pressionada
    /// </summary>
    public bool iSpace;

    /// <summary>
    /// iW é a variável booleana que recebe o valor true quando a tecla W é pressionada
    /// </summary>
    public bool iW;

    /// <summary>
    /// iA é a variável booleana que recebe o valor true quando a tecla A é pressionada
    /// </summary>
    public bool iA;

    /// <summary>
    /// iS é a variável booleana que recebe o valor true quando a tecla S é pressionada
    /// </summary>
    public bool iS;

    /// <summary>
    /// iD é a variável booleana que recebe o valor true quando a tecla D é pressionada
    /// </summary>
    public bool iD;

    /// <summary>
    /// iE é a variável booleana que recebe o valor true quando a tecla E é pressionada
    /// </summary>
    public bool iE;

    
    void Update()
    {
        CheckInputs();
    }

    /// <summary>
    /// Essa função serve para limpar as variáveis booleanas caso necessário
    /// </summary>
    public void ClearInputs()
    {

        iSpace = false;
        iW = false;
        iA = false;
        iS = false;
        iD = false;
        iE = false;

    }

    /// <summary>
    /// Esta função serve para checar os inputs das teclas Espaço, W, A, S, D e E
    /// </summary>
    public void CheckInputs()
    {

        //Armazena se a tecla Espaço foi pressionada
        iSpace = Input.GetKeyDown(KeyCode.Space);
        if(iSpace == true)
        {
            //Chama o que precissar aqui
        }
       
        //Armazena se alguma das teclas W,A,S,D foram pressionadas
        iW = Input.GetKeyDown(KeyCode.W);
        if(iW == true)
        {
            //Chama o que precissar aqui
        }
        iA = Input.GetKeyDown(KeyCode.A);
        if(iA == true)
        {
            //Chama o que precissar aqui
        }
        iS = Input.GetKeyDown(KeyCode.S);
        if(iS == true)
        {
            //Chama o que precissar aqui
        }
        iD = Input.GetKeyDown(KeyCode.D);
        if(iD == true)
        {
            //Chama o que precissar aqui
        }

        //Armazena se a tecla E foi pressionada
        iE = Input.GetKeyDown(KeyCode.D);
        if(iE == true)
        {
            //Chama o que precissar aqui
        }

    }

}
