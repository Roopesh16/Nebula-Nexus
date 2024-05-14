using UnityEngine;
using UnityEngine.UI;

namespace NebulaNexus.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private RawImage bgImage;
        [SerializeField] private float yScroll;

        private void Update()
        {
            bgImage.uvRect = new Rect(bgImage.uvRect.position + new Vector2(0, yScroll) * Time.deltaTime,
                                      bgImage.uvRect.size);
        }
    }
}
