using System;

public class MoveToAction : ActionBase
{
        private LogicObject _moveObject;
        private VInt3 _targetPosition;
        private VInt3 _initPosition;
        private VInt _times;
        private Action _onMoveFinish;
        private VInt _lerpTime = 0;
        public MoveToAction(LogicObject moveObject,VInt3 targetPosition,VInt times,Action complete)
        {
                this._moveObject = moveObject;
                this._targetPosition = targetPosition;
                this._times = times;
                this._onMoveFinish = complete;
                this._initPosition = moveObject.LogicPosition;
        }

        public override void OnLogicFrameUpdate()
        {
#if CLIENT_LOGIC
                _lerpTime += (VInt)LogicFrameSyncConfig.LogicFrameIntervalMs;
                VInt leapValue = _lerpTime / _times;
                _moveObject.LogicPosition = VInt3.Lerp(_initPosition, _targetPosition, leapValue.RawFloat);
                if (leapValue >= VInt.one)
                {
                        _onMoveFinish?.Invoke();
                        IsFinished = true;
                        return;
                }
#else
                _onMoveFinish?.Invoke();
                IsFinished = true;
#endif

        }
}