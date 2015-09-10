using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Class for uniformly handling UI elements
/// Use the Singleton Instance variable to access methods from anywhere
/// (Ex. UIManager.Instance.RemoveHP(0.10f);)
/// </summary>
public class UIManager : MonoBehaviour {

    public Image XpBar, HpBar, ApBar;
    public GameObject AbilityPicker,AbilityBar,PauseMenu;
    public static UIManager Instance { get { return _instance; } }

    public bool apBarDraining = false;
    //Time it takes to drain the chargeBar,approximately in seconds
    private float drainTime=3.0f;
    //Singleton
    private static UIManager _instance;
    void Start() {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (ApBar.fillAmount<=0.0f) {
           AbilityBar.SetActive(false);
           apBarDraining = false;
        }
        if (apBarDraining&&AbilityBar.activeInHierarchy) {
            ApBar.fillAmount -= Time.deltaTime/drainTime;
        }
	
	}

    /// <summary>
    /// Adds XP to the current amount,filling the XP bar a percentage relative to the current total
    /// </summary>
    /// <param name="amount">The amount of XP to gain,as a <b>percentage</b> of the current total</param>
    public void AddXP(float amount) {
        float newXP = XpBar.fillAmount + amount;
        XpBar.fillAmount = newXP < 1.0f ? newXP : 1.0f;
    }

    public void ClearXP() {
        XpBar.fillAmount = 0;
    }

    /// <summary>
    /// Adds HP to the current amount,filling the HP bar a percentage relative to the current total
    /// </summary>
    /// <param name="amount">The amount of HP to gain,as a <b>percentage</b> of the current total</param>
    public void AddHP(float amount) {
        float newHP = HpBar.fillAmount + amount;
        HpBar.fillAmount = newHP < 1.0f ? newHP : 1.0f;
    }

    public void RemoveHP(float percentage) {
        float newHP = HpBar.fillAmount - percentage;
        HpBar.fillAmount = newHP > 0.0f ? newHP : 0.0f;
    }

    /// <summary>
    /// Shows the Ability charge bar and sets the drain time.
    /// </summary>
    /// <param name="time">The time in seconds it takes to drain the bar</param>
    public void ShowAPBar(float time) {
        this.drainTime = time;
        ApBar.fillAmount = 1.0f;
        AbilityBar.SetActive(true);
    }

    public void DrainAPBar(float percentage) {
      ApBar.fillAmount -= percentage;     
    }

    public void TogglePause() {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
    }

    public void ShowPicker() {
        AbilityPicker.SetActive(true);
    }
}
