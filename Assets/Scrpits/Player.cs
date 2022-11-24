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

    void FixedUpdate() //물리연산 프레임마다 호출되는 생명주기 함수
    {
        //1.힘을 준다
        //rigid.AddForce(inputVec);

        //2,속도제어
        //rigid.velocity= inputVec;

        //3.위치 이동(MovePosition)
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //fixedDeltaTime = 물리 프레임 하나가 소비한 시간
        rigid.MovePosition(rigid.position + nextVec); //moveposition이 위치 이동이라 현재 위치도 더해줘야 함.
    }
    //void OnMove(InputValue value) //자동완성이 안되기에 오타 주의, input manager에 있는 함수
    //{
    //    inputVec = value.Get<Vector2>(); //vector2 가져오기 
    //}
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); //setFloat의 첫번째 ("파라미터의 이름", 반영할 float 값(magnitude:벡터의 크기))

        if (inputVec.x != 0)
        {
            render.flipX = inputVec.x < 0; //뒤의 연산이 true로 앞에 들어감
        }    
    }
}
