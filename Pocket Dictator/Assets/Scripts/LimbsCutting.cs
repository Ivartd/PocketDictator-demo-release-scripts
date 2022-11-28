using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsCutting : MonoBehaviour
{
    public GameObject bloodSplatter;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Blade")
        {
            Destroy(gameObject);
            var splatterInstance = Instantiate(bloodSplatter, transform.position, Quaternion.identity);
            Destroy(splatterInstance, 2f);
        }
    }
}
