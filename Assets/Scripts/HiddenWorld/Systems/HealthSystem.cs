using HiddenWorld.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class handles the health state of a game object.
/// 
/// Implementation Notes: 2D Rigidbodies must be set to never sleep for this to interact with trigger stay damage
/// </summary>\
namespace HiddenWorld.Systems
{
	public class HealthSystem : MonoBehaviour
	{
		[Header("Team Settings")]
		[Tooltip("The team associated with this damage")]
		public int teamId = 0;

		[Header("Health Settings")]
		[Tooltip("The default health value")]
		[SerializeField]
		private float defaultHealth = 100.0f;
		[Tooltip("The maximum health value")]
		[SerializeField]
		private float maximumHealth = 100.0f;
		[Tooltip("The current in game health value")]
		[SerializeField]
		private float currentHealth = 100.0f;
		[Tooltip("Invulnerability duration, in seconds, after taking damage")]
		[SerializeField]
		private float invincibilityTime = 0.3f;
		[Tooltip("Whether or not this health is always invincible")]
		[SerializeField]
		private bool isAlwaysInvincible = false;

		[Header("Lives settings")]
		[Tooltip("The amount of time to wait before respawning")]
		[SerializeField]
		private float respawnWaitTime = 3f;
		// The specific game time until the player will respawn
		private float respawnTime;
		// The position that the health's gameobject will respawn at
		private Vector3 respawnPosition;
		// The specific game time when the health can be damged again
		private float timeToBecomeDamagableAgain = 0;
		// Whether or not the health is invincible
		private bool isInvincableFromDamage = false;

		[Header("Effects & Polish")]
		[Tooltip("The effect to create when this health dies")]
		public GameObject deathEffect;
		[Tooltip("The effect to create when this health is damaged (but does not die)")]
		public GameObject hitEffect;
		[Tooltip("A list of events that occur when the health becomes 0 or lower")]
		public UnityEvent eventsOnDeath;
		[Tooltip("A list of events that occur when the health becomes 0 or lower")]
		public UnityEvent eventsOnHit;
		[Tooltip("A list of events that occur on respawn")]
		public UnityEvent eventsOnRespawn;

		void Start()
		{
			SetRespawnPoint(transform.position);
		}

		void Update()
		{

		}

		/// <summary>
		/// Description:
		/// Checks to see if the health gameobject should be respawned yet and only respawns it if the alloted time has passed
		/// Input:
		/// none
		/// Return:
		/// void (no return)
		/// </summary>
		private void RespawnCheck()
		{
			if (respawnWaitTime != 0 && currentHealth <= 0)
			{
				if (Time.time >= respawnTime)
				{
					Respawn();
				}
			}
		}
		/// <summary>
		/// Description:
		/// Changes the respawn position to a new position
		/// Input:
		/// Vector3 newRespawnPosition
		/// Returns:
		/// void (no return)
		/// </summary>
		/// <param name="newRespawnPosition">The new position to respawn at</param>
		public void SetRespawnPoint(Vector3 newRespawnPosition)
		{
			respawnPosition = newRespawnPosition;
		}

		/// <summary>
		/// Description:
		/// Repositions the health's game object to the respawn position and resets the current health to the default value
		/// Input:
		/// none
		/// Return:
		/// void (no return)
		/// </summary>
		void Respawn()
		{
			if (GetComponent<CharacterController>() != null)
			{
				GetComponent<CharacterController>().enabled = false;
				transform.position = respawnPosition;
				GetComponent<CharacterController>().enabled = true;
			}
			eventsOnRespawn?.Invoke();

			currentHealth = defaultHealth;
		}

		/// <summary>
		/// Description:
		/// Applies damage to the health unless the health is invincible.
		/// Input:
		/// int damageAmount
		/// Return:
		/// void (no return)
		/// </summary>
		/// <param name="damageAmount">The amount of damage to take</param>
		public void TakeDamage(float damageAmount)
		{
			if (isInvincableFromDamage || currentHealth <= 0 || isAlwaysInvincible)
			{
				return;
			}
			else
			{
				if (hitEffect != null)
				{
					Instantiate(hitEffect, transform.position, transform.rotation, null);
				}
				eventsOnHit?.Invoke();
				StartCoroutine(StartInvincibility());
				currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maximumHealth);
				CheckDeath();
			}
		}

		/// <summary>
		/// Description:
		/// Applies healing to the health, capped out at the maximum health.
		/// Input:
		/// int healingAmount
		/// Return:
		/// void (no return)
		/// </summary>
		/// <param name="healingAmount">How much healing to apply</param>
		public void ReceiveHealing(float healingAmount)
		{
			currentHealth += healingAmount;
			if (currentHealth > maximumHealth)
			{
				currentHealth = maximumHealth;
			}
			CheckDeath();
		}

		public void AddMaxHealth(int level)
		{
			maximumHealth += 20 * Mathf.Pow(1.3f, level);
			currentHealth = maximumHealth;
		}


		/// <summary>
		/// Description:
		/// Checks if the health is dead or not. If it is, true is returned, false otherwise.
		/// Calls Die() if the health is dead.
		/// Input:
		/// none
		/// Return:
		/// bool
		/// </summary>
		/// <returns>bool: A boolean value representing if the health has died or not (true for dead)</returns>
		bool CheckDeath()
		{
			if (currentHealth <= 0)
			{
				Die();
				return true;
			}
			return false;
		}

		/// <summary>
		/// Description:
		/// Handles when health is 0.
		/// Input:
		/// none
		/// Return:
		/// void (no return)
		/// </summary>
		void Die()
		{
			if (deathEffect != null)
			{
				if (deathEffect != null)
				{
					Instantiate(deathEffect, transform.position, transform.rotation, null);
				}
			}

			// Do on death events
			eventsOnDeath?.Invoke();

			Respawn();
		}

		/// <summary>
		/// Description:
		/// Tries to notify the game manager that the game is over
		/// Input: 
		/// none
		/// Return: 
		/// void (no return)
		/// </summary>
		public void GameOver()
		{

		}

		private IEnumerator StartInvincibility()
		{
			isInvincableFromDamage = true;
			yield return new WaitForSecondsRealtime(invincibilityTime);
			isInvincableFromDamage = false;
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}

