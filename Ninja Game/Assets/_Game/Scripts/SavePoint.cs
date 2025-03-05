using _Game.Scripts.StateMachine.PlayerSM;
using UnityEngine;

namespace _Game.Scripts
{
    public class SavePoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;
            
            Debug.Log("Save Point");
            
            Player player = collision.GetComponent<Player>();

            if (player != null && player.playerBB != null)
            {
                player.playerBB.SetSavePoint(this.transform.position);
            }
        }
    }
}
