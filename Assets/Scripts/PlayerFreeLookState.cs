using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoName
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            _playerStateMachine.Animator.Play(AnimationNames.FREE_LOOK_1H);
        }

        public override void Tick(float delta)
        {
            Vector3 movement = CalculateMovement();
            Move(movement * _playerStateMachine.RunningSpeed, delta);

            if (movement.sqrMagnitude != 0)
            {
                targetRotation = Quaternion.LookRotation(movement);
                _playerStateMachine.transform.rotation = Quaternion.Slerp(_playerStateMachine.transform.rotation, targetRotation, _playerStateMachine.RotationSmoothTime * delta);
            }

            _playerStateMachine.UpdateLocomotionAnimationValues(0f, movement.magnitude * (_playerStateMachine.IsSprinting ? 2 : 1)) ;
        }

        public override void Exit()
        {
            
        }

    }
}