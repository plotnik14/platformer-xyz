using PixelCrew.Model;
using PixelCrew.Model.Definition.Player;

namespace PixelCrew.Components.Health
{
    public class HeroHealthComponent : HealthComponent
    {
        protected override void Start()
        {
            _isInvincible = false;
            UpdateMaxHealth();
        }
        
        public void SetHealth(int health)
        {
            _health = health;
            UpdateMaxHealth();
        }

        private void UpdateMaxHealth()
        {
            _maxHealth = (int) GameSession.Instance.StatsModel.GetValue(StatId.Hp);
        }
        
    }
}