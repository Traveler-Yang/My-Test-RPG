﻿using Entities;
using Managers;
using SkillBridge.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityContorller : MonoBehaviour, IEntityNotify{

	public Animator anim;
	public Rigidbody rb;
	private AnimatorStateInfo currentBaseState;

	public Entity entity;

	public UnityEngine.Vector3 position;
	public UnityEngine.Vector3 direction;
	Quaternion rotation;

	public UnityEngine.Vector3 lastPosition;
	Quaternion lastRotation;

    public float speed;
    public float animSpeed = 1.5f;
    public float jumpPower = 3.0f;

	public bool isPlayer  = false;

	void Start ()
	{
		if (entity != null)
		{
			EntityManager.Instance.RegisterEntityChangeNotify(entity.entityId, this);
			this.UpdateTransform();
		}

        if (!this.isPlayer)
            rb.useGravity = false;
    }

    private void Update()
    {
		anim.SetFloat("Walk",rb.velocity.z);
    }

    void UpdateTransform()
	{
		this.position = GameObjectTool.LogicToWorld(entity.position);
		this.direction = GameObjectTool.LogicToWorld(entity.direction);

		this.rb.MovePosition(this.position);
		this.transform.forward = this.direction;
		this.lastPosition = this.position;
		this.lastRotation = this.rotation;
	}

	void OnDestroy()
	{
		if (entity != null)
			Debug.LogFormat("{0} OnDestroy :ID:{1} POS:{2} DIR:{3} SPD:{4}", this.name, entity.entityId, entity.position, entity.direction, entity.speed);

		if(UIWorldElementManager.Instance != null)
		{
			UIWorldElementManager.Instance.RemoveCharacterNameBar(this.transform);
		}
	}

	void FixedUpdate()
	{
		if (this.entity == null)
			return;

		this.entity.OnUpdate(Time.fixedDeltaTime);

        if (!this.isPlayer)
        {
            this.UpdateTransform();
        }
    }

    public void OnEntityRemoved()
    {
        if (UIWorldElementManager.Instance != null)
            UIWorldElementManager.Instance.RemoveCharacterNameBar(this.transform);
        Destroy(this.gameObject);
    }

    public void OnEntityEvent(EntityEvent entityEvent)
    {
        switch(entityEvent)
        {
            case EntityEvent.Idle:
                anim.SetBool("Move", false);
                anim.SetTrigger("Idle");
                break;
            case EntityEvent.MoveFwd:
                anim.SetBool("Move", true);
                break;
            case EntityEvent.MoveBack:
                anim.SetBool("Move", true);
                break;
            case EntityEvent.Jump:
                anim.SetTrigger("Jump");
                break;
        }
    }

    public void OnEntityChanged(Entity entity)
    {
        Debug.LogFormat("OnEntityChanged :ID:{0} POS:{1} DIR:{2} SPD:{3}", entity.entityId, entity.position, entity.direction, entity.speed);
    }
}
