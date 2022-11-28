using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding : MonoBehaviour
{
    public GameObject[] bloodsplash;

    public void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Environment")
        {
            GameObject Bleeding = Instantiate(bloodsplash[Random.Range(0, bloodsplash.Length)], transform.position, Quaternion.identity);
            Destroy(Bleeding, 4f);
        }


    }


}
