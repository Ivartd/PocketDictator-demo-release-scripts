using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HingeJoint2D))]
public class DamageControl : MonoBehaviour
{
    public GameObject heart;
    public GameObject bloodSplatter;

    public SpriteRenderer sr;
    public HingeJoint2D hg;

    public Sprite lowDamageSprite;
    public Sprite mediumDamageSprite;
    public Sprite fullDamageSprite;

    public int lowDamageLimit;
    public int midDamageLimit;
    public int fullDamageLimit;
    public int cutLimbLimit;

    private int touchesCount;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        hg = gameObject.GetComponent<HingeJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Environment") {
            touchesCount++;
            heart.gameObject.GetComponent<HealthControl>().UpdateHealth(+1);
            SpriteChange();
        }
        if (col.gameObject.tag == "Blade")
        {
            touchesCount += 200;
            var splatterInstance = Instantiate(bloodSplatter, transform.position, Quaternion.identity);
            Destroy(splatterInstance, 2f);
            SpriteChange();
        }
    }

    private void SpriteChange()
    {
        if (touchesCount == lowDamageLimit)
            sr.sprite = lowDamageSprite;

        if (touchesCount == midDamageLimit)
            sr.sprite = mediumDamageSprite;

        if (touchesCount == fullDamageLimit)
            sr.sprite = fullDamageSprite;

        if (touchesCount >= cutLimbLimit && hg != null)
        {
            heart.gameObject.GetComponent<HealthControl>().UpdateHealth(+200);
            hg.gameObject.SetActive(false);
        }
    }
}
