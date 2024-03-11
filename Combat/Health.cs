using System;
using UnityEngine;

namespace Jun.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private int maxMana;

        public float health;
        public int mana;
        
        public bool isDead => health == 0;
        
        public event Action OnTakeDamage;
        public event Action OnDie;

        private void Awake()
        {
            maxHealth = 100;
            maxMana = 100;
            health = maxHealth;
            mana = maxMana;
        }

        public void DealDamage(int damage)
        {
            if (health <= 0) return;
        
            health = Mathf.Max(health - damage, 0);

            OnTakeDamage?.Invoke();

            if (health == 0){
                OnDie?.Invoke();
            }
        }

        public float GetPercentage()
        {
            return health / maxHealth;
        }
    }
}