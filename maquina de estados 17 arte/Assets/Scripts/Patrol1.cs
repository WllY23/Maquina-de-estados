using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public enum Estados
{
    Ataque, Patrulla 
}

public class Patrol1 : EnemyAI
{
    public Animator anim;

    public Vector3 posH;
    public GameObject[] Wayp;
    public float rango;
    public float Vel;
    float m_internalSpeed;
    public int i;
    public float tiempoEspera;
    //public Transform pos;
    public GameObject Enemy;
    int estado;
    public GameObject Hero;
    public float direction;
    public int posicisionfinal;
    public bool attack;
    public bool patrullar = true;
    public Estados estados;
    public LayerMask heroe;
    public LayerMask obstaculos;

    

    public void Awake()
    {
        Maweke();
    }

    void Start()
    {
        
		Wayp = GameObject.FindGameObjectsWithTag("Waypoint");
        m_internalSpeed = Vel;
    }

    void Update()
    {
		Stados ();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10 /*Mathf.Infinity*/, obstaculos))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            attack = false;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,10 /*Mathf.Infinity*/, heroe))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
            attack = true;
            posH = new Vector3(-23, 21, 17);
            Hero.transform.position = posH;
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Perdiste");
    //        posH = new Vector3(-23, 21,17);
    //        Hero.transform.position = posH;
    //    }
    //}

    public void Ataque()
    {
       // attack = true;
        direction = (Hero.transform.position - transform.position).magnitude;
        if (direction <= rango)
        {
            attack = true;
            patrullar = false;
            target = Hero.transform;
            navmeshagent.SetDestination(Hero.transform.position);
            anim.SetTrigger("ataqueE");
        }
        else
        {
            attack = false;
            patrullar = true;
        }
    }

    public void Stados()
    { 
		direction = (Hero.transform.position - transform.position).magnitude;
		if (direction < rango) 
		{
			estados = Estados.Ataque;
		} else
		{
			estados = Estados.Patrulla;
		}

        switch (estados)
        {
            case Estados.Ataque:
                Ataque();
                break;
            case Estados.Patrulla:
                Patrulla();
                break;
        }
    }

    public void Patrulla()
    {
        attack = false;
        if (i < Wayp.Length)
        {
            direction = (Wayp[i].transform.position - transform.position).magnitude;
            
            if (direction > rango)
            {
                target = Wayp[i].transform;
                anim.SetTrigger("CaminarE");
            }

            if (direction <= rango)
            {
                i++;
            }
            if (i >= Wayp.Length)
            {
                anim.SetTrigger("IdleE");
                Vel = 0;
                i = 3;
                tiempoEspera += Time.deltaTime;
                if (tiempoEspera >= 3)
                {
                    i = 0;
                    Vel = m_internalSpeed;
                    tiempoEspera = 0;
                    
                }
            }
        }
            navmeshagent.SetDestination(Wayp[i].transform.position);
        
    }
}
