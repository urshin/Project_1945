using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS_Player_move : MonoBehaviour
{

    //�̵� ���� ����, velocity �� ��������
    [SerializeField]
    private float speed = 2000f;
    private Rigidbody2D rb;


    //��ð��� ����
    private float dash_speed = 15f;
    private float dash_time = 0.4f;         //�� 0.1��
    private float dash_cool_time = 3f;  // �� 3��
    private Vector2 pre_velocity;
    public GameObject dash_trail_h;              //�ܻ� ������Ʈ
    public GameObject dash_trail_u;              //�ܻ� ������Ʈ
    public GameObject dash_trail_d;              //�ܻ� ������Ʈ
    


    //�ִϸ����� ���� ����
    private Animator animator;
    private string anim_idle = "Player_IDLE";
    private string anim_left = "Player_left";
    private string anim_right = "Player_right";
    private string anim_down = "Player_down";


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float axis_X = Input.GetAxisRaw("Horizontal");
        float axis_Y = Input.GetAxisRaw("Vertical");

        if (axis_Y < 0) animator.Play(anim_down);
        else if (axis_X > 0) animator.Play(anim_right);
        else if (axis_X < 0) animator.Play(anim_left);
        else animator.Play(anim_idle);


        rb.velocity = new Vector2(axis_X, axis_Y ) * speed* Time.deltaTime ;
        Dash(rb.velocity);

    }

    public void Dash(Vector2 preVelocity)
    {
        //Debug.Log($"dash cool : {dash_cool_time}  dash_time {dash_time } ");
        dash_cool_time -= Time.deltaTime;
        dash_time -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Debug.Log("dash.." + rb.velocity);
            
            dash_cool_time = Time.deltaTime * 180;
            dash_time = Time.deltaTime * 6;


        }

        if (dash_time > 0)
        {
            rb.velocity = rb.velocity * dash_speed;
            GameObject tmp_dash_trail = null;
            //���� �����ӿ� �ܻ� �����
            if (rb.velocity.x > 0)
            {
                tmp_dash_trail = Instantiate(dash_trail_h, transform.position, Quaternion.identity);
            }
            else if (rb.velocity.x < 0)
            {
                tmp_dash_trail = Instantiate(dash_trail_h, transform.position, Quaternion.identity);
                tmp_dash_trail.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (rb.velocity.y > 0)
            {
                tmp_dash_trail = Instantiate(dash_trail_u, transform.position, Quaternion.identity);
            }else if(rb.velocity.y < 0){
                tmp_dash_trail = Instantiate(dash_trail_d, transform.position, Quaternion.identity);
            }
            Destroy(tmp_dash_trail, 0.3f);
        }
        else
        {
            rb.velocity = preVelocity;
        }
    }


    

}
