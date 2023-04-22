using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class HealthBarController : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject FillPanel;
    [SerializeField]
    private float _maxHealth;
    protected float _health;

    private void Awake() {
        _health = _maxHealth;
    }

    private void ChangeHealtBar(){
        Vector3 newScale = new Vector3(_health/_maxHealth,1,1);
        FillPanel.transform.localScale = newScale;
    }

    public virtual void GetDamage(float damage){
        if (_health <= 0) return;

        _health -= damage;
        ChangeHealtBar();

        
    }
}
