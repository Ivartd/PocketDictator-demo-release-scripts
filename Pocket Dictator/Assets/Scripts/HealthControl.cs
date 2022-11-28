using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HealthControl : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public GameObject deathPanel;

    public int recievedDamage;

    Animator m_anim;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        head = GameObject.Find("/Dictator/Head");
        body = GameObject.Find("/Dictator/Body");
    }

    public void UpdateHealth(int damage) 
    {
        if(body.activeSelf && head.activeSelf )
        {
            recievedDamage += damage;
            if (recievedDamage >= 500)
                m_anim.speed = 2;
            if (recievedDamage >= 1000)
                m_anim.speed = 3;
            if (recievedDamage >= 1200)
                m_anim.speed = 6;
            if (recievedDamage >= 1600)
                m_anim.speed = 10;
        }
        else
        {
            Debug.Log("Dictator pomer, zemlya steklom");
            m_anim.speed = 0;
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
