﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonEnigme : MonoBehaviour
{
    float timer;
    float Temps;
    
    public GameObject[] Lettre;
    
    public GameObject[] Light;

    public int cpt = 0;

    private bool CD = true;

    public bool Lettre_1 = false;
    public bool Lettre_2 = false;
    public bool Lettre_3 = false;

    private bool Comfirm_Lettre_1 = false;
    private bool Comfirm_Lettre_2 = false;
    private bool Comfirm_Lettre_3 = false;

    private bool Lettre1_pressed = false;
    private bool Lettre2_pressed = false;
    private bool Lettre3_pressed = false;
    private bool Lettre4_pressed = false;
    private bool Lettre5_pressed = false;
    private bool Lettre6_pressed = false;

    private void Start()
    {
        Temps = GameManager.instance.TimerLettre;
    }
    void Update()
    {
        if (cpt == 3)
        {
            if (Lettre_1 & Lettre_2 & Lettre_3)
            {
                GameManager.instance.LettreOK = true;
                GameManager.instance.Diode3.GetComponent<Renderer>().material.color = Color.green;
              
            }
            else
            {
                StartCoroutine(Cooldown());

                Lettre_1 = false;
                Lettre_2 = false;
                Lettre_3 = false;

                Comfirm_Lettre_1 = false;
                Comfirm_Lettre_2 = false;
                Comfirm_Lettre_3 = false;

                Lettre1_pressed = false;
                Lettre2_pressed = false;
                Lettre3_pressed = false;
                Lettre4_pressed = false;
                Lettre5_pressed = false;
                Lettre6_pressed = false;

                Light[0].SetActive(false);
                Light[1].SetActive(false);
                Light[2].SetActive(false);
                Light[3].SetActive(false);
                Light[4].SetActive(false);
                Light[5].SetActive(false);
                
                cpt = 0;
            }
            
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lettre")
        {
            timer = Temps;
        }
    }

    void Pressed(Collider other)
    {
        if (other.gameObject == Lettre[0] && !Lettre1_pressed)
        {
            Light[0].SetActive(true);
            Lettre1_pressed = true;
        }
        else if (other.gameObject == Lettre[1] && !Lettre2_pressed)
        {
            Light[1].SetActive(true);
            Lettre2_pressed = true;
        }
        else if (other.gameObject == Lettre[2] && !Lettre3_pressed)
        {
            Light[2].SetActive(true);
            Lettre3_pressed = true;
        }
        else if (other.gameObject == Lettre[3] && !Lettre4_pressed)
        {
            Light[3].SetActive(true);
            Lettre4_pressed = true;
        }
        else if (other.gameObject == Lettre[4] && !Lettre5_pressed)
        {
            Light[4].SetActive(true);
            Lettre5_pressed = true;
        }
        else if (other.gameObject == Lettre[5] && !Lettre6_pressed)
        {
            Light[5].SetActive(true);
            Lettre6_pressed = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Lettre" && CD == true)
        {
            
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Debug.Log("fin timer");

                if (cpt < 3)
                {

                    Debug.Log("choix Lettre");
                    if (((other.gameObject == Lettre[0] && !Lettre1_pressed) || (other.gameObject == Lettre[1] && !Lettre2_pressed) || (other.gameObject == Lettre[2] && !Lettre3_pressed)) && !Comfirm_Lettre_1)
                    {
                        Lettre_1 = true;
                        Comfirm_Lettre_1 = true;
                        Pressed(other);
                        cpt++;
                    }
                    else if (((other.gameObject == Lettre[0] && !Lettre1_pressed) || (other.gameObject == Lettre[1] && !Lettre2_pressed) || (other.gameObject == Lettre[2] && !Lettre3_pressed)) && !Comfirm_Lettre_2)
                    {
                        Lettre_2 = true;
                        Comfirm_Lettre_2 = true;
                        Pressed(other);
                        cpt++;
                    }
                    else if (((other.gameObject == Lettre[0] && !Lettre1_pressed) || (other.gameObject == Lettre[1] && !Lettre2_pressed) || (other.gameObject == Lettre[2] && !Lettre3_pressed)) && !Comfirm_Lettre_3)
                    {
                        Lettre_3 = true;
                        Comfirm_Lettre_3 = true;
                        Pressed(other);
                        cpt++;
                    }
                    else
                    {
                        if (((other.gameObject == Lettre[3] && !Lettre4_pressed) || (other.gameObject == Lettre[4] && !Lettre5_pressed) || (other.gameObject == Lettre[5] && !Lettre6_pressed)) && !Comfirm_Lettre_1)
                        {
                            Lettre_1 = false;
                            Comfirm_Lettre_1 = true;
                            Pressed(other);
                            cpt++;
                        }
                        else if (((other.gameObject == Lettre[3] && !Lettre4_pressed) || (other.gameObject == Lettre[4] && !Lettre5_pressed) || (other.gameObject == Lettre[5] && !Lettre6_pressed)) && !Comfirm_Lettre_2)
                        {
                            Lettre_2 = false;
                            Comfirm_Lettre_2 = true;
                            Pressed(other);
                            cpt++;
                        }
                        else if (((other.gameObject == Lettre[3] && !Lettre4_pressed) || (other.gameObject == Lettre[4] && !Lettre5_pressed) || (other.gameObject == Lettre[5] && !Lettre6_pressed)) && !Comfirm_Lettre_3)
                        {
                            Lettre_3 = false;
                            Comfirm_Lettre_3 = true;
                            Pressed(other);
                            cpt++;
                        }
                    }
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        CD = false;

        yield return new WaitForSeconds(2f);

        CD = true;
    }
}
