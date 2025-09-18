//using UnityEngine;

//public class CharacterMovement : MonoBehaviour
//{
//    private Character _character;
//    //private Vector2 _targetPos;


//    public void InitMovement(Character character)
//    {
//        _character = character;

//        //CoroutineManager.Instance.StartManagedCoroutine(FindToTarget_Coroutine(0.15f), DefineClass.FindToTargetCoroutineKey);
//        _character.StateMachine.ChanageState(_character.StateMachine.moveState);
//    }

//    private void Update()
//    {
//        if(_character.StateMachine.CurrentCharacterState == ECharacterState.Move)
//            transform.position = Vector2.MoveTowards(_character.transform.position, _targetPos, Time.deltaTime);
//    }

//    //IEnumerator FindToTarget_Coroutine(float interval)
//    //{
//    //    while (true)
//    //    {
//    //        if (BattleManager.Instance != null)
//    //        {
//    //            Character character = BattleManager.Instance.GetNearEnemy(_character.IsPlayerTeam, _character.transform.position);
//    //            if (character != null) _targetPos = character.transform.position;
//    //        }

//    //        yield return YieldCache.WaitForSeconds(interval);
//    //    }
//    //}
//}
