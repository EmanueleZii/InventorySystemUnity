using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Player player; // da assegnare via Inspector
    public int damage = 10;

    

    public void OnClick()
    {
        if (player != null)
        {
            player.health -= damage;
            Debug.Log("Danno inflitto: " + damage);
        }
        else
        {
            Debug.LogWarning("Player non assegnato!");
        }
    }
}
