using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovimentoController : NetworkBehaviour
{
    public CharacterController characterController;
    public float velocidade = 4f;
    public Animator animator;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

            #region 1 forma de movimentacao
            //Vector3 direcao = new Vector3 (horizontal, 0, vertical);
            //if (direcao.magnitude > 0.1f)
            //{
            //    characterController.Move(direcao * velocidade * Runner.DeltaTime); // movimento do personagem
            //    transform.rotation = Quaternion.LookRotation(direcao); // rotacao do personagem
            #endregion

                #region 2 forma de movimentacao 
                //movimentacao do personagem
                characterController.Move(transform.forward * vertical * velocidade * Runner.DeltaTime);

                //rotacao do personagem
                float velocidadeRotacao = velocidade * 50f;
                transform.Rotate(new Vector3(0, horizontal * velocidade * Runner.DeltaTime, 0));
                #endregion

                animator.SetBool("PodeAndar", true);
            }
            else
            {
                animator.SetBool("PodeAndar", false);
            }

            
	}


	}

