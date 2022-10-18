using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCreator : MonoBehaviour
{
	public Text textHolder;
	public SpellShooter shooter;
	private List<SpellStage> stages = new List<SpellStage>();

	private void OnEnable()
	{
		ResetSpell();
	}

	public void ResetSpell()
	{
		stages.Clear();
		textHolder.text = "Straight";
		stages.Add(new Straight());
	}

	public void AddStage(SpellStage s)
	{
		stages.Add(s);
		textHolder.text += "\n" + s.ToString();
	}

	public void AddModifier(SpellModifier sm)
	{
		stages[stages.Count - 1].AddModifier(sm);
		textHolder.text += "\n\t" + sm.ToString();
	}

	public void AcceptSpell()
	{
		shooter.spell.SetSpell(stages);
	}

	public void AddListUpwards()
	{
		AddStage(new ListUp());
	}
	public void AddTurnUp()
	{
		AddStage(new TurnUp());
	}
	public void AddListDown()
	{
		AddStage(new ListDown());
	}
	public void AddSplit()
	{
		AddStage(new Split());
	}
	public void AddTrail()
	{
		AddStage(new Trail());
	}
	public void AddSpeedUp()
	{
		AddModifier(new Mod_Speedup());
	}
	public void AddGravity()
	{
		AddModifier(new Mod_Gravity());
	}
	public void AddLightningDamage()
	{
		AddModifier(new Mod_LightningDamage());
	}
}
