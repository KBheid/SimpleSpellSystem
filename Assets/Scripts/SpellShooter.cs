using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public Spell spell;

    // Start is called before the first frame update
    void Start()
    {
        SpellShootState.OnShootSpellInput += ShootSpell;

        spell.enabled = false;
    }

    private void ShootSpell()
	{
        // Shoot the spell in front of the player
        Spell newSpell = spell.CreateCopy();

        newSpell.SetOwner(gameObject);

        newSpell.gameObject.SetActive(true);
        newSpell.enabled = true;

        newSpell.transform.position = transform.position;
        newSpell.direction = transform.forward;
	}
}
