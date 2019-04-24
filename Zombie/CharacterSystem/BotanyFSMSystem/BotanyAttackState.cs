using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class BotanyAttackState : IBotanyState
    {
        private float mAttackTime = 1;
        private float mAttackTimer = 1;

        public BotanyAttackState(BotanyFSMSytem fsm, ICharacter c) : base(fsm, c)
        {
            mStateID = BotanyStateID.Attack;
            mAttackTimer = mAttackTime;
        }
        public override void Act(List<ICharacter> targets)
        {
            mCharacter.Idle();
            if (targets == null || targets.Count == 0) return;
            mAttackTimer += 0.5f;
            if (mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(targets[0]);
                mAttackTimer = 0;
            }
        }

        public override void Reason(List<ICharacter> targets)
        {
            if (targets == null || targets.Count == 0)
            {
                mFSM.PerformTransition(BotanyTransition.NoEnmey); return;
            }
        }
    }
}
