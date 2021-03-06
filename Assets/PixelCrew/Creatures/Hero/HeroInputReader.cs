using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew.Creatures
{

    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Interact();
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Attack();
            }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Throw(context.duration);
            }
        }

        public void OnHeal(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Heal();
            }
        }

        public void OnShowMenu(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.ShowMainMenuInGame();
            }
        }
    }
}