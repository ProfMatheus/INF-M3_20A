using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguobje : MonoBehaviour
{
    public string[] Tags;           // Numero de Tags que vai ter no script
    public GameObject ObjSegurando;
    [Space(20)]
    public float DistanciaMax; // Distancia que ele aceita pegar
    public bool Segurando;
    public GameObject Local;   //"BRAÇO" onde objeto vai ficar preso 
    public LayerMask Layoso;



    void Start()
    {
        
    }

   
    void Update()
    {
        if (Segurando == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Segurando = false;
                ObjSegurando.transform.parent = null;
                ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
                ObjSegurando = null;
                return;
            }
        }
        if(Segurando == false)
        {
            RaycastHit Hit = new RaycastHit();
            
            if(Physics.Raycast(transform.position, transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore)) //
            {
                Debug.DrawLine(transform.position, Hit.point, Color.green);

                ObjSegurando = Hit.transform.gameObject;
                for (int x = 0; x < Tags.Length; x++)
                {
                    if( Hit.transform.gameObject.tag == Tags[x])
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Segurando = true;
                            ObjSegurando = Hit.transform.gameObject;
                            if (ObjSegurando.GetComponent<Rigidbody>())
                            {
                                ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
                                ObjSegurando.transform.position = Local.transform.position;
                                ObjSegurando.transform.rotation = Local.transform.rotation;
                                ObjSegurando.transform.parent = Local.transform;
                            }
                            return;
                        }
                    }
                }
            }



            {

            }
        }


    }
}
