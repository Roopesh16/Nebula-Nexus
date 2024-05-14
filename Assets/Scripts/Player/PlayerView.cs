using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition;
        private PlayerController playerController;

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        private void Update()
        {
            MovementInput();
            ShootInput();
        }

        private void MovementInput()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                playerController.MovePlayer(Direction.RIGHT);
            if (Input.GetAxisRaw("Horizontal") < 0)
                playerController.MovePlayer(Direction.LEFT);
        }

        private void ShootInput()
        {
            if (Input.GetMouseButton(0))
                playerController.ShootBullet(spawnPosition);

        }
    }
}