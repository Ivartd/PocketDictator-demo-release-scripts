using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitVFX : MonoBehaviour
{
    public GameObject hitAnim;

    public AudioSource source;
    public AudioClip[] clips;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Environment" || col.gameObject.tag == "Blade")
        {
            var hitInstance = Instantiate(hitAnim, transform.position, Quaternion.identity);
            Destroy(hitInstance, 2f);

            int randomClip = Random.Range(0, clips.Length);
            source.clip = clips[randomClip];
            source.Play();
        }
    }
}
