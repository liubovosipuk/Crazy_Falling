using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody; // для перемещения персонажа по платформам 

    //Лучше ставить 2f, 1f маловато
    public float moveSpeed = 2f; // скорость перемещения персонажа по платформам 


    
    void Awake()
    {
        //если мы используем такие компоненты и присваиваем им значения в переменных, 
        //то данное название делать обязательно иначе если мы будем обращаться к данному компоненту
        //из других функций без его предварительного объявления, то нам IDE выдат ошибку
        myBody = GetComponent<Rigidbody2D>();

    }



    // Для перемещения объектов с компонентами лучше использовать FixedUpdate - он больше подходит 
    // Для перобразования, как например с наши платформами нам достаточно Update
    void FixedUpdate()
    {
        Move();
    }




    // Задание надо будет исправить этот код (как он говорил  в прошлых уроках )
    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        
        if (Input.GetAxisRaw("Horizontal") < 0f)
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

    }




    // Для перемещения игрока по платфомам 
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);

    }





} // class
// оставляем строки немного местя якобы для лучшего перемещения персонажа





























































