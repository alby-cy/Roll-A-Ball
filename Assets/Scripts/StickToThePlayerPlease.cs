using UnityEngine;

public class StickToThePlayerPlease : MonoBehaviour
{
    public GameObject player;
    public float yOffset = 0;
    void Update() 
    { 
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z);
    }
}
