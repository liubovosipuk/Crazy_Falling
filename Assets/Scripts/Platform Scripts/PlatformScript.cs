using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f; // скорость движения платформ
    public float bound_Y = 6f; // граница по оси Y, за которую будет выходить платформа и потом появляться снова

    //именуем каждую платформу
    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform; 
    public Animator anim;

    private void Awake()
    {
        
        if (is_Breakable)
            anim = GetComponent<Animator>();
    }


    void Update()
    {
        // вызываем нашу функцию MOve()
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime; // * на Time.deltaTime - чтобы платформа быстро не улетала и ее скорость сглаживаласт 
        transform.position = temp;

        //делаем проверку, достигла ли наша платформа определнной координаты по оси Y для того чтобы она стала не активной
        if (temp.y >= bound_Y)
            gameObject.SetActive(false);

    }// move

    

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f); // разлом платформы будет вызываться каждые 0,3 секунды
    }


    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {

            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);// при столкновении с шипами убираем игрока с поля зрения
                SoundManager.instance.GameOverSound(); // задаем звук окончания игры
                GameManager.instance.RestartGame(); // перезапускаем игру

            }
        }

    } // on trigger enter



    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {

            //если платформа разрушаемая, то запускаем анимацию и звук
            if (is_Breakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();

            }
                
        }
    } // on clollision enter




    void OnCollisionStay2D(Collision2D target)
    {


        //по заданию движение надо будет как-то задать в отдельную переменую 

        //при столкновении игрока с платформой движ, он будет приходить в движение право лево
        if(target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            
            if (moving_Platform_Right)
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
        }
    } // on collision stay


} // class





































