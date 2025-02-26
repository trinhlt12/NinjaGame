using UnityEngine;

namespace _Game.Scripts
{
    public class SavePoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;
            Debug.Log("Save Point");
            collision.GetComponent<Player>().SetSavePoint(this.transform.position);
        }
    }
}
