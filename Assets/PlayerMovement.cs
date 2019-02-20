using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hewwo hewwo
    // owo
    //pwease wet me move mw obama
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody Player_Rigidbody;
    int floor_Mask;
    float cam_Ray_Length = 100f;

    private void Awake()
    {
        floor_Mask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        Player_Rigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

        Turning();
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        Player_Rigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray cam_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floor_Hit;

        if (Physics.Raycast(cam_Ray, out floor_Hit, cam_Ray_Length, floor_Mask))
        {
            Vector3 player_to_mouse = floor_Hit.point - transform.position;

            player_to_mouse.y = 0f;

            Quaternion new_rotation = Quaternion.LookRotation(player_to_mouse);

            Player_Rigidbody.MoveRotation(new_rotation);
        }
    }


}