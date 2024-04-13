using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate the player GameObject
            other.gameObject.SetActive(false);
            
            GameManager.Instance.ResetLevel(3f);
            
        }
        else
        {
            // Destroy other colliding GameObjects
            Destroy(other.gameObject);
        }
    }
}
