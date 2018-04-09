using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHC.WareHouseMis.Com;
using WHC.Framework.Commons;

namespace WHC.WareHouseMis.Com
{
   public class StateMachine
    {

       public  StateMachine()
       {
          

       }
       public  StateMachine(StateEvent dataEvent)
       {
           this.dataEvent = DataEvent;
         

       }
        public  enum AnimationState
        {
            IDLE = 1,
            CAR_IN,
            CAR_ReadyWeight,
            CAR_GetNo,
            CAR_WeightLing,
            CAR_Weighted,
            CAR_OUT
        }

       
        private State currentState = null;
        private State previousState = null;
        private StateEvent dataEvent = null;
        private bool isStop;
       

       
            public StateEvent DataEvent
            {
                get { return dataEvent; }
                set { dataEvent = value; }
            }
          

            private State CurrentState
            {
                get
                {
                    return currentState;
                }
            }
            private State PreviousState
            {
                get
                {
                    return previousState;
                }
            }
            private bool IsStop
            {
                get
                {
                    return isStop;
                }

                set
                {
                    isStop = value;
                }
            }

            private State GetState(AnimationState animationState)
            {
                switch (animationState)
                {
                    case AnimationState.CAR_IN: return new CAR_IN();
                    case AnimationState.CAR_ReadyWeight: return new CAR_ReadyWeight();
                    case AnimationState.CAR_GetNo: return new CAR_GetNo();
                    case AnimationState.CAR_WeightLing: return new CAR_WeightLing();
                    case AnimationState.CAR_Weighted: return new CAR_Weighted();
                    case AnimationState.CAR_OUT: return new CAR_OUT();
                }
                return new IDLE();
            }

            private void ChangeState(AnimationState animationState, StateEvent data, StateEvent previousData = null)
            {
                ChangeState(GetState(animationState), data, previousData);
            }

            private void ChangeState(State state, StateEvent data, StateEvent previousData = null)
            {
                //如果切换的状态就是本状态,就退出
                if (currentState != null && state.GetStateId == currentState.GetStateId)
                    return;

                //退出上一个状态
                if (previousState != null)
                    previousState.Exit(previousData);

                //设置进状态,进入新状态
                currentState = state;

                currentState.Enter(data);
            }


            public void Update()
            {

                
                if (currentState == null)
                {
                    currentState = new IDLE();
                    currentState.Enter(dataEvent);

                  
                }
                else if (IsStop)
                {
                    Console.WriteLine("状态机已经停止");
                    return;
                }
                else
                {
                    currentState.Execute(dataEvent);
                 
                }
            }



            //初始化状态
            public class IDLE : State
            {
                private const int ID = 1;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_IN;
                public static int changeCountMax = 5;
                private int changeCount = 1;

                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                  
                    LogTextHelper.Info("this is IDLE Enter next state:");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {
                        
                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                      
                        LogTextHelper.Info("this is IDLE Execute next state:--->>CAR_IN");
                    }else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is IDLE Exit next state:");
                }
            }



            //初始化状态
            public class CAR_IN : State
            {
                private const int ID = 2;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_ReadyWeight;
                public static int changeCountMax =6;
                private int changeCount = 1;

                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_IN Enter");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {

                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_IN Execute next state:--->>CAR_ReadyWeight");
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_IN Exit ");
                }
            }



            //初始化状态
            public class CAR_ReadyWeight : State
            {
                private const int ID = 3;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_GetNo;
                public static int changeCountMax = 7;
                private int changeCount = 1;
                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_ReadyWeight Enter ");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {
                        
                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_ReadyWeight Execute next state:--->>CAR_GetNo");
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_ReadyWeight Exit ");

                }
            }




            //初始化状态
            public class CAR_GetNo : State
            {
                private const int ID =4;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_WeightLing;
                public static int changeCountMax =8;
                private int changeCount = 1;
                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_GetNo Enter ");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {

                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_GetNo Execute next state:--->>CAR_WeightLing");
                        
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_GetNo Exit");
                }
            }


         //初始化状态
            public class CAR_WeightLing : State
            {
                private const int ID = 5;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_Weighted;
                public static int changeCountMax = 9;
                private int changeCount = 1;
                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_WeightLing Enter");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {

                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_WeightLing Execute next state:--->>CAR_Weighted");
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_WeightLing Exit");
                }
            }


            //初始化状态
            public class CAR_Weighted : State
            {
                private const int ID = 6;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.CAR_OUT;
                public static int changeCountMax = 10;
                private int changeCount = 1;
                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_Weighted Enter");
                }

                public override void Execute(StateEvent data)
                {

                    if (changeCount >= changeCountMax)
                    {

                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_Weighted Execute next state:--->>CAR_OUT");
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_Weighted Exit");
                }
            }

            //初始化状态
            public class CAR_OUT : State
            {
                private const int ID = 7;
                private const string ledShowText = "一车一杆 严禁跟车";
                private const string voiceText = "一车一杆 严禁跟车";
                private AnimationState nextAnimationState = AnimationState.IDLE;
                public static int changeCountMax = 11;
                private int changeCount = 1;
                public override int GetStateId
                {
                    get
                    {
                        return ID;
                    }
                }

                public override void Enter(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_OUT Enter");
                }

                public override void Execute(StateEvent data)
                {
                    if (changeCount >= changeCountMax)
                    {

                        data.stateMachine.previousState = this;
                        data.stateMachine.ChangeState(nextAnimationState, data);
                        LogTextHelper.Info("this is CAR_OUT Execute next state:--->>IDLE");
                    }
                    else
                    {
                        changeCount++;
                    }
                }

                public override void Exit(StateEvent data)
                {
                    LogTextHelper.Info("this is CAR_OUT Exit ");
                }
            }

       

    }
}
