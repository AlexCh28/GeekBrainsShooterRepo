using UnityEngine.SceneManagement;

public class PlayerHealthBar : HealthBarController
{
    public override void GetDamage(float damage){
        base.GetDamage(damage);
        if (_health <= 0) {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
