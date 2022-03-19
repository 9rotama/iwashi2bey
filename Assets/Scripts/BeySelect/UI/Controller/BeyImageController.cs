using UnityEngine;
using UnityEngine.UI;

namespace BeySelect.UI.Controller
{
    public class BeyImageController : MonoBehaviour
    {
        private Image _imgComp;
        [SerializeField] private Sprite[] sprites;

        public void SetSprite(BeyType type)
        {
            _imgComp.sprite = sprites[(int)type];
        }
    
        // Start is called before the first frame update
        void Awake()
        {
            _imgComp = GetComponent<Image>();
            SetSprite(BeyType.Candy);
        }
    }
}
