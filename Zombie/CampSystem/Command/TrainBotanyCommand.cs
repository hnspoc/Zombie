using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class TrainBotanyCommand : ITrainCommand
    {
        CharacterName mBotanyType;
        Point mPosition;
        int RowPos;
        public TrainBotanyCommand(CharacterName st, Point pos,int rowPos)
        {
            mBotanyType = st;
            mPosition = pos;
            RowPos = rowPos;
        }
        public void Execute()
        {
            switch (mBotanyType)
            {
                case CharacterName.nRepeater:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicRepeater>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;
                default:
                    break;
            }
        }
    }
}
