﻿using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public enum FSMState
	{
		Wander,		//随机游荡状态
		Seek,		//搜索状态
		Chase,		//追踪状态
		Attack,		//攻击状态
		Dead,		//死亡状态
	}



	public float wanderSpeed = 0.9f;			//	僵尸游荡速度
	public float runSpeed = 4.0f;				//	僵尸奔跑速度
	public float wanderScope = 15.0f;			//	游荡状态下，随机选择目标位置的范围
	public float seekDistance = 25.0f;			//	僵尸中枪后的搜索距离
	public float disappearTime = 3.0f;			//	僵尸尸体消失前的停留时间

	public float attackRange = 1.5f;			//	僵尸攻击距离
	public float attackFieldOfView = 60.0f;		//	僵尸攻击夹角
	public float attackInterval = 0.8f;			//	僵尸攻击间隔
	public int attackDamage = 10;				//	僵尸攻击力
	public AudioClip zombieAttackAudio; 		//	僵尸攻击音效

	public FSMState currentState;				//僵尸当前状态
	public float currentSpeed = 0.0f;			//僵尸当前速度

	public bool autoInit = false;				//是否自动初始化僵尸状态

	private Vector3 previousPos = Vector3.zero;	//僵尸上一次停留位置
	private float stopTime = 0;					//僵尸的停留时间
	private float attackTimer = 0.0f;			//僵尸攻击计时器
	private float disappearTimer = 0.0f;		//僵尸尸体消失计时器
	private bool disappeared = false;			//僵尸尸体是否已经消失

	private UnityEngine.AI.NavMeshAgent		agent;			//导航代理组件
	private Animator			animator;		//动画控制器组件
	private Transform 			zombieTransform;//僵尸transform组件
	private ZombieHealth	zombieHealth;		//僵尸生命值管理组件
	private ZombieSensor zombieSensor;			//僵尸感知器组件
	private ZombieRender	zombieRender;		//僵尸渲染器控制器组件
	private Transform targetPlayer;				//僵尸感知范围内的玩家

	private bool firstInDead = true;			//僵尸是否首次进入死亡状态


	void OnEnable()
	{
		//获取僵尸的各种组件
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		zombieHealth = GetComponent<ZombieHealth> ();
		zombieSensor = GetComponentInChildren<ZombieSensor> ();
		zombieRender = GetComponent<ZombieRender> ();
		zombieTransform = transform;
		//把僵尸感知到的玩家字段设置为null
		targetPlayer = null;
		//初始状态为死亡状态
		currentState = FSMState.Dead;
		//禁用导航代理组件
		agent.enabled = false;
		//自动初始化僵尸
		if (autoInit)
			Born ();
	}
	//在指定位置初始化僵尸
	public void Born(Vector3 pos)
	{
		zombieTransform.position = pos;
		Born ();
	}
	//
	public void Born()
	{
		//把僵尸感知到的玩家字段设置为null血量
		targetPlayer = null;
		//把僵尸的初始化状态设置为游荡状态，
		currentState = FSMState.Wander;
		//初始化僵尸生命值
		zombieHealth.currentHP = zombieHealth.maxHP;
		//启用导航代理组件
		agent.enabled = true;
		agent.ResetPath ();

		//启用动画控制器
		animator.applyRootMotion = false;
		GetComponent<CapsuleCollider> ().enabled = true;
		animator.SetTrigger("toReborn");

		disappearTimer = 0;
		disappeared = false;
		firstInDead = true;
		currentState = FSMState.Wander;
	}
	//禁用僵尸对象
	void Disable()
	{
		zombieTransform.gameObject.SetActive (false);
	}

	//定期更新僵尸状态机的状态
	void FixedUpdate()
	{
		FSMUpdate ();
	}

	//僵尸状态机更新函数
	void FSMUpdate()
	{
		//根据僵尸当前的状态调用相应的状态处理函数
		switch (currentState)
		{
		case FSMState.Wander: 
			UpdateWanderState();
			break;
		case FSMState.Seek:
			UpdateSeekState();
			break;
		case FSMState.Chase:
			UpdateChaseState();
			break;
		case FSMState.Attack:
			UpdateAttackState();
			break;
		case FSMState.Dead:
			UpdateDeadState ();
			break;
		}
		//如果僵尸处于非死亡状态，但是生命值减为0，那么进入死亡状态
		if (currentState != FSMState.Dead && !zombieHealth.IsAlive) 
		{
			currentState = FSMState.Dead;
		}
	}

	//判断僵尸是否在一次导航中到达了目的地
	protected bool AgentDone()
	{
		return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
	}

	//限制僵尸的当前移动速度，更新动画状态机
	private void setMaxAgentSpeed(float maxSpeed)
	{
		Vector3 targetVelocity = Vector3.zero;
		if (agent.desiredVelocity.magnitude > maxSpeed) {
			targetVelocity = agent.desiredVelocity.normalized * maxSpeed;
		} else {
			targetVelocity = agent.desiredVelocity;
		}
		agent.velocity = targetVelocity;
		currentSpeed = agent.velocity.magnitude;

		//设置动画状态
		animator.SetFloat("Speed", currentSpeed);

	}

	//计算僵尸在某个位置附近的停留时间
	private void caculateStopTime()
	{
		if (previousPos == Vector3.zero) 
		{
			previousPos = zombieTransform.position;
		}
		else 
		{
			Vector3 posDiff = zombieTransform.position - previousPos;
			if (posDiff.magnitude > 0.5) {
				previousPos = zombieTransform.position;
				stopTime = 0.0f;
			} else {
				stopTime += Time.deltaTime;
			}
		}
	}

	//游荡状态处理函数
	void UpdateWanderState()
	{
		//感知到周围有活着的玩家，进入追踪状态
		targetPlayer = zombieSensor.getNearbyPlayer ();
		if ( targetPlayer != null) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			return;
		}

		//如果受到伤害，那么进入搜索状态
		if (zombieHealth.getDamaged) {
			currentState = FSMState.Seek;
			agent.ResetPath ();
			return;
		}

		//如果没有目标位置，那么随机选择一个目标位置
		if (AgentDone () ) {
			Vector3 randomRange = new Vector3 ( (Random.value - 0.5f) * 2 * wanderScope, 
											0, (Random.value - 0.5f) * 2 * wanderScope);
			Vector3 nextDestination = zombieTransform.position + randomRange;
			agent.destination = nextDestination;
		} 
		//限制游荡的速度
		setMaxAgentSpeed(wanderSpeed);

		//统计僵尸在当前位置附近的停留时间
		caculateStopTime();

		// 如果在一个地方停留太久（各种原因导致僵尸卡住）
		// 那么选择僵尸背后的一个位置当做下一个目标
		if(stopTime > 1.0f)
		{
			Vector3 nextDestination = zombieTransform.position 
				- zombieTransform.forward * (Random.value) * wanderScope;
			agent.destination = nextDestination;
		}

		//进入普通状态
		if(zombieRender!=null)
			zombieRender.SetNormal();

	}

	//搜索状态处理函数
	void UpdateSeekState()
	{
		//如果僵尸感知范围内有玩家，进入追踪状态
		targetPlayer = zombieSensor.getNearbyPlayer ();
		if ( targetPlayer != null) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			return;
		}
		//如果僵尸受到攻击，那么向着玩家开枪时所在的方向进行搜索
		if (zombieHealth.getDamaged) {
			Vector3 seekDirection = zombieHealth.damageDirection;
			agent.destination = zombieTransform.position 
				+ seekDirection * seekDistance;
			//将getDamaged设置为false，表示已经处理了这次攻击
			zombieHealth.getDamaged = false;	
		}

		//如果到达搜索目标，或者卡在某个地方无法到达目标位置，那么回到游荡状态
		if (AgentDone () || stopTime > 1.0f ) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			return;
		} 
		//减速度限制为奔跑速度
		setMaxAgentSpeed(runSpeed);

		//进入狂暴状态
		if(zombieRender!=null)
			zombieRender.SetCrazy();

		//计算停留时间
		caculateStopTime();

	}

	//追踪状态处理函数
	void UpdateChaseState()
	{
		//如果僵尸感知范围内没有玩家，进入游荡状态
		targetPlayer = zombieSensor.getNearbyPlayer ();
		if (targetPlayer == null) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			return;
		}
		//如果玩家与僵尸的距离，小于僵尸的攻击距离，那么进入攻击状态
		if (Vector3.Distance(targetPlayer.position, zombieTransform.position)<=attackRange) {
			currentState = FSMState.Attack;
			agent.ResetPath ();
			return;
		}

		//设置移动目标为玩家
		agent.SetDestination (targetPlayer.position);

		//限制追踪的速度
		setMaxAgentSpeed(runSpeed);

		//进入狂暴状态
		if(zombieRender!=null)
			zombieRender.SetCrazy();

		//计算停留时间
		caculateStopTime();
	}

	void UpdateAttackState()
	{
		//如果僵尸感知范围内没有玩家，进入游荡状态
		targetPlayer = zombieSensor.getNearbyPlayer ();
		if (targetPlayer == null) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			animator.SetBool ("isAttack", false);
			return;
		}
		//如果玩家与僵尸的距离，大于僵尸的攻击距离，那么进入追踪状态
		if (Vector3.Distance(targetPlayer.position, zombieTransform.position)>attackRange) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			animator.SetBool ("isAttack", false);
			return;
		}



		PlayerHealth ph = targetPlayer.GetComponent<PlayerHealth> ();
		if (ph != null)
		{
			//计算僵尸的正前方和玩家的夹角，只有玩家在僵尸前方才能攻击
			Vector3 direction = targetPlayer.position - zombieTransform.position;
			float degree = Vector3.Angle (direction, zombieTransform.forward);
			if (degree < attackFieldOfView / 2 && degree > -attackFieldOfView / 2) {
				animator.SetBool ("isAttack", true);
				if (attackTimer > attackInterval) {
					attackTimer = 0;
					if (zombieAttackAudio != null)				
						AudioSource.PlayClipAtPoint (zombieAttackAudio, zombieTransform.position);
					ph.TakeDamage (attackDamage);
				}
				attackTimer += Time.deltaTime;
			} else {
				//如果玩家不在僵尸前方，僵尸需要转向后才能攻击
				animator.SetBool ("isAttack", false);
				zombieTransform.LookAt(targetPlayer);
			}
		}

		//攻击状态下的敌人应当连续追踪玩家
		agent.SetDestination (targetPlayer.position);

		//进入狂暴状态
		if(zombieRender!=null)
			zombieRender.SetCrazy();

		//限制追踪的速度
		setMaxAgentSpeed(runSpeed);

	}
		
	void UpdateDeadState()
	{
		//统计僵尸死亡后经过的时间，如果超过了尸体消失时间，那么禁用该僵尸对象
		if (!disappeared) {

			if ( disappearTimer > disappearTime) {
				zombieTransform.gameObject.SetActive (false);
				disappeared = true;
			}
			disappearTimer += Time.deltaTime;
		}
		//如果僵尸初次进入死亡状态，那么需要禁用僵尸的一些组件
		if (firstInDead) {
			firstInDead = false;

			agent.ResetPath ();
			agent.enabled = false;
			GetComponent<CapsuleCollider> ().enabled = false;

			animator.applyRootMotion = true;
			animator.SetTrigger ("toDie");

			disappearTimer = 0;
			disappeared = false;

			//进入普通状态
			if(zombieRender!=null)
				zombieRender.SetNormal();
			animator.ResetTrigger("toReborn");
		}

	}
}