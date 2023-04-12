using Assets.Scripts.Managers;
using Assets.Scripts.MyScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        public Color Color { get => _spriteRenderer.color; }
        
        protected SpriteRenderer _spriteRenderer;
        
        private GameManager _gm;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _gm = GameManager.Instance;
        }

        private void OnEnable()
        {
            SetColor();
        }

        private void SetColor()
        {
            switch (_gm.SpawnTypes)
            {
                case SpawnTypes.RedAndBlue:
                    _spriteRenderer.color = Random.value > .5f ? Color.red : Color.blue;
                    break;
                case SpawnTypes.AllRandom:
                    _spriteRenderer.color = Random.ColorHSV();
                    break;
                default:
                    Debug.LogError("Not type selected!");
                    break;
            }
        }

        public void SetName(string newName)
        {
            name = newName;
        }
    }
}
