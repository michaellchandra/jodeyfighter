
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPositionX;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;


    public GameoverScreen GameoverScreen;
    int maxPlatform = 0;

    public void GameOver()
    {
        GameoverScreen.Setup(maxPlatform);
    }

    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3(player.position.x , transform.position.y, transform.position.z);
        
    }

    public void MoveToAnotherRoom (Transform _newRoom)
    {
        currentPositionX = _newRoom.position.x;

    }
}
