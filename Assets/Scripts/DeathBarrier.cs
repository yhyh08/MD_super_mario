using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathBarrier : MonoBehaviour
{
    //public AudioSource deathSource;
    //public AudioClip deathClip;
    //[SerializeField] SoundManager soundManager;
    //[SerializeField] AudioClip deathClip;

    private void Start()
    {
        //deathSource = GetComponent<AudioSource>();
        //deathSource.clip = deathClip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the death sound effect
            //deathSource.Play();
            //soundManager.PlaySoundFX(deathClip);

            // Deactivate the player GameObject
            other.gameObject.SetActive(false);
            // Reset the level after a delay
            GameManager.Instance.ResetLevel(3f);
        }
        else
        {
            // Destroy other colliding GameObjects
            Destroy(other.gameObject);
        }
    }
}
