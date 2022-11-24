using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer render;
    Animator anim;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate() //�������� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    {
        //1.���� �ش�
        //rigid.AddForce(inputVec);

        //2,�ӵ�����
        //rigid.velocity= inputVec;

        //3.��ġ �̵�(MovePosition)
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //fixedDeltaTime = ���� ������ �ϳ��� �Һ��� �ð�
        rigid.MovePosition(rigid.position + nextVec); //moveposition�� ��ġ �̵��̶� ���� ��ġ�� ������� ��.
    }
    //void OnMove(InputValue value) //�ڵ��ϼ��� �ȵǱ⿡ ��Ÿ ����, input manager�� �ִ� �Լ�
    //{
    //    inputVec = value.Get<Vector2>(); //vector2 �������� 
    //}
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); //setFloat�� ù��° ("�Ķ������ �̸�", �ݿ��� float ��(magnitude:������ ũ��))

        if (inputVec.x != 0)
        {
            render.flipX = inputVec.x < 0; //���� ������ true�� �տ� ��
        }    
    }
}
