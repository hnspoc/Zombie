using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Zombie
{
    public class GameFacade
    {
        private static GameFacade _instance = new GameFacade();
        private bool mIsGameOver = false;
        private Form currform;
        public static GameFacade Insance { get { return _instance; } }

        public bool isGameOver { get { return mIsGameOver; } }

        public Form Currform { get => currform; set => currform = value; }
        public CampSystem MCampSystem { get => mCampSystem;}
        public int[] enyrowPos;
        public int[] botanyrowPos;
        private GameFacade() { }

        private CampSystem mCampSystem;
        private CharacterSystem mCharacterSystem;
        private SubscribeSystem mGameEventSystem;
         private StageSystem mStageSystem;
        public void Init()
        {
            mCampSystem = new CampSystem();
            mCharacterSystem = new CharacterSystem();  
            mGameEventSystem = new SubscribeSystem();
            mStageSystem = new StageSystem();
            mCampSystem.Init();
            mCharacterSystem.Init();
            mGameEventSystem.Init();
            mStageSystem.Init();
        }
        public void UpdateRender(Graphics g)
        {
            mCharacterSystem.UpdateRender(g);
        }
        
        public void Update()
        {
            mCampSystem.Update();
            mCharacterSystem.Update();
            mGameEventSystem.Update();
            mStageSystem.Update();
        }
        public void Release()
        {
            mCampSystem.Release();
            mCharacterSystem.Release();
            mGameEventSystem.Release();
            mStageSystem.Release();
        }
        public void AddBotany(IBotany botany)
        {
            mCharacterSystem.AddBotany (botany);
        }
        public void RemoveBotany(IBotany botany)
        {
            mCharacterSystem.RemoveBotany (botany);
        }
        public void AddEnemy(IEnemy enemy)
        {
            mCharacterSystem.AddEnemy(enemy);
        }
        public void RemoveEnemy(IEnemy enemy)
        {
            mCharacterSystem.RemoveEnemey(enemy);
        }
        public void RegisterObserver(GameEventType eventType, IObserver observer)
        {
            mGameEventSystem.RegisterObserver(eventType, observer);
        }
        public void RemoveObserver(GameEventType eventType, IObserver observer)
        {
            mGameEventSystem.RemoveObserver(eventType, observer);
        }
        public void NotifySubject(GameEventType eventType)
        {
            mGameEventSystem.NotifySubject(eventType);
        }
    }
}
