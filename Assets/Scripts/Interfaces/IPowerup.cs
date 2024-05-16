using System.Collections;
using UnityEngine;

namespace NebulaNexus.Interfaces
{
    public interface IPowerup
    {
        public void OnTrigger(GameObject other);
    }
}