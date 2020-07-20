using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; set; }

    public Stat damage;
    public Stat armor;
    public Stat range;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage          -= armor.GetValue();
        damage          = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth   -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        Debug.Log(transform.name + " takes " + damage + " damage. Current health is: " + currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(Random.Range(5,10));
    }

    public virtual void Die()
    {
        currentHealth = 0;
        Debug.Log(transform.name + " died.");
    }
}
