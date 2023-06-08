using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Se for verdade, anda para direita
        if(isFacingRight())
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else //Se não, anda para esquerda
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
    }
    //Quando o colisor sair da plataforma
    private void OnTriggerExit2D(Collider2D other) {
        /*
        esse código vai mudar a escala inteira do player, rotacionando ele por inteiro.
        quando a gente altera o Scale em X no unity, o objeto é todo girado para o lado contrário
        a gente vai usar isso para que toda vez que ele encontrar o fim de uma plataforma ele trocar o sinal
        o Math.Sign() serve para pegar o sinal atual do objeto que estiver sendo usado de referencia
        nesse caso, a gente pega o sinal do rb.velocity.x e inverte, fazendo o player virar.

        o transform.localScale.y vai manter a posição y sem alteração.
        
        */
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }

    private bool isFacingRight()
    {
        /* 
        O objeto virado para a direita é 1 e para esquerda é -1
        se é o x dele tá 1 então ele tá olhando para direita 
        */
        return transform.localScale.x == 1;  
    }
}
