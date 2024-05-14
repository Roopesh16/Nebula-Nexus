using UnityEngine;

namespace NebulaNexus.Interfaces
{
    public interface IBullet
    {
        public void MoveBullet();
        public void OnTrigger(GameObject other);
    }
}