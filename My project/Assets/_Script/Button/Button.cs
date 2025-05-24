using UnityEngine;

public class DamageButton : MonoBehaviour
{
    public Player player; // da assegnare via Inspector
    public int damage = 10;

    public void OnClick()
    {
        if (player != null)
        {
            player.Health -= damage;
            Debug.Log("Danno inflitto: " + damage);
        }
        else
        {
            Debug.LogWarning("Player non assegnato!");
        }
    }
}
