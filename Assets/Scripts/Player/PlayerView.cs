using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                playerController.MovePlayer(Direction.RIGHT);
            if (Input.GetAxisRaw("Horizontal") < 0)
                playerController.MovePlayer(Direction.LEFT);
        }
    }
}