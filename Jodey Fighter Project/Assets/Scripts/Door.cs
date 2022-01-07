
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform RoomSebelumnya;
    [SerializeField] private Transform RoomSelanjutnya;
    [SerializeField] private CameraController camera;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                camera.MoveToAnotherRoom(RoomSelanjutnya);
            else
                camera.MoveToAnotherRoom(RoomSebelumnya);
        }
    }

}
