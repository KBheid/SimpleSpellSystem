using System.Collections.Generic;
using UnityEngine;


public abstract class SpellStage
{
    public delegate void StageChanged(SpellStage stage);
    protected StageChanged _stateChangedCallback;

    protected Spell owner;
    public float stageRange = 10f;
    public float currentDistance = 0f;

    protected SpellStage nextStage;

    protected List<SpellModifier> spellModifiers = new List<SpellModifier>();

    public void SetCallback(StageChanged callback)
	{
        _stateChangedCallback = callback;
    }
    public void SetSpell(Spell s)
    {
        owner = s;

        foreach (SpellModifier sm in spellModifiers)
            sm.SetSpell(s);
    }
    public void AddMovementDistance(float dist)
	{
        currentDistance += dist;
        if (currentDistance >= stageRange)
		{
            EnterNextState();
		}
    }
    public void SetNextStage(SpellStage ss)
    {
        nextStage = ss;
    }
    public void AddModifier(SpellModifier sm)
    {
        spellModifiers.Add(sm);
    }

    public abstract SpellStage CreateCopy();
    protected List<SpellModifier> CreateModifierCopies()
	{
        List<SpellModifier> modifiers = new List<SpellModifier>();

        foreach (SpellModifier sm in spellModifiers)
		{
            modifiers.Add(sm.CreateCopy());
		}

        return modifiers;
    }

    protected virtual void EnterStage()
	{
        foreach (SpellModifier sm in spellModifiers)
            sm.OnApply();
	}
    protected virtual void ExitStage() { }
    public virtual void OnPeriodic(float deltaTime)
	{
        foreach (SpellModifier sm in spellModifiers)
		{
            sm.OnPeriodic(deltaTime);
		}
	}
    protected void EnterNextState()
	{
        if (nextStage != null)
		{
            nextStage.EnterStage();

            _stateChangedCallback?.Invoke(nextStage);

            ExitStage();
        }

        else
            _stateChangedCallback?.Invoke(null);
    }

    public void OnCollision(GameObject other)
    {
        foreach (SpellModifier sm in spellModifiers)
        {
            sm.OnCollision(other);
        }
    }
}

public abstract class SpellModifier
{
    protected Spell owner;

    public void SetSpell(Spell spell) { owner = spell; }

    public virtual void OnPeriodic(float deltaTime) { }
    public virtual void OnApply() { }
    public virtual void OnCollision(GameObject other) { }

    public abstract SpellModifier CreateCopy();
}

public class Spell : MonoBehaviour
{
    private GameObject owner;

    public Vector3 direction;
    public float speed;
    public float rawDamage;
    public float fireDamage;
    public float lightningDamage;

    public List<SpellStage> spellStages = new List<SpellStage>();
    private int _currentStage;

    void Start()
    {
        _currentStage = 0;

        if (spellStages.Count == 0)
		{
            Straight s = new Straight();
            s.SetCallback(NextStage);
            s.SetSpell(this);
            spellStages.Add(s);
		}

    }

    void NextStage(SpellStage next)
	{
        if (next == null)
            Destroy(gameObject);

        _currentStage++;
	}

    // Update is called once per frame
    void Update()
    {
        if (_currentStage >= spellStages.Count)
            return;

        Vector3 offset = speed * Time.deltaTime * direction.normalized;
        spellStages[_currentStage].OnPeriodic(Time.deltaTime);
        spellStages[_currentStage].AddMovementDistance(offset.magnitude);

        transform.position += offset;
    }

    public void SetSpell(List<SpellStage> stages)
	{
        _currentStage = 0;

        spellStages.Clear();

        SpellStage lastStage = null;
        foreach (SpellStage stage in stages)
		{
            SpellStage cpy = stage.CreateCopy();
            cpy.SetSpell(this);
            cpy.SetCallback(NextStage);

            if (lastStage != null)
                lastStage.SetNextStage(cpy);

            spellStages.Add(stage);

            lastStage = cpy;
		}
	}

    public void SetOwner(GameObject owner)
	{
        this.owner = owner;
	}

    public Spell CreateCopy()
	{
        Spell s = Instantiate(gameObject, transform.parent).GetComponent<Spell>();
        s.owner = owner;
        s.direction = direction;
        s.rawDamage = rawDamage;
        s.fireDamage = fireDamage;
        s.lightningDamage = lightningDamage;

        SpellStage lastSpellStage = null;
        foreach (SpellStage sp in spellStages.GetRange(_currentStage, spellStages.Count - _currentStage))
		{

            SpellStage newSp = sp.CreateCopy();
            newSp.SetSpell(s);
            newSp.SetCallback(s.NextStage);
            s.spellStages.Add(newSp);

            if (lastSpellStage != null)
                lastSpellStage.SetNextStage(newSp);

            lastSpellStage = newSp;
		}

        return s;
	}

	private void OnTriggerEnter(Collider other)
	{
        spellStages[_currentStage].OnCollision(other.gameObject);
	}
}
