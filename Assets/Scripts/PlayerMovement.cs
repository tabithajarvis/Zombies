using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody rigid_body_;
    public Transform main_camera_;
    public float move_speed_ = 0.25f;
    public float turn_speed_ = 3.0f;
    public float look_speed_ = 3.0f;
    
    private bool move_forward_ = false;
    private bool move_backward_ = false;
    private bool move_left_ = false;
    private bool move_right_ = false;

    private float turn_amount_ = 0.0f;
    private float look_amount_ = 0.0f;

    // Use this for initialization
    void Start() {
    }

    // Used to handle player input and other non-physics updates.
    void Update() {
        move_forward_  = Input.GetKey(KeyCode.W);
        move_backward_ = Input.GetKey(KeyCode.S);
        move_left_     = Input.GetKey(KeyCode.A);
        move_right_    = Input.GetKey(KeyCode.D);

        turn_amount_ = Input.GetAxis("Mouse X");
        look_amount_ = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (move_forward_ && !move_backward_) {
            MoveForward();
        } else if (move_backward_ && !move_forward_) {
            MoveBackward();
        }

        if (move_left_ && !move_right_) {
            MoveLeft();
        } else if (move_right_ && !move_left_) {
            MoveRight();
        }

        Turn(turn_amount_);
        Look(look_amount_);
    }

    void MoveForward() {
        transform.position += transform.forward * move_speed_;
    }
    void MoveBackward() {
        transform.position -= transform.forward * move_speed_;
    }
    void MoveLeft() {
        transform.position -= transform.right * move_speed_;
    }
    void MoveRight() {
        transform.position += transform.right * move_speed_;
    }
    void Turn(float turn_amount) {
        transform.Rotate(0, turn_amount * turn_speed_, 0);
    }
    void Look(float look_amount) {
        main_camera_.Rotate(-look_amount_, 0,0);
    }
}

