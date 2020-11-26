using UnityEngine;

namespace Ball
{
    public interface IBallLogic
    {
        bool canFly();
        void setThrown(bool thrown);
        void setCollided(bool collided);
        
        bool isCollided();
        void setFlying(bool flying);
        bool isFlying();
        
        bool isOverTheFence();
        void setThrownByPlayer(bool thrownByPlayer);

        void setOverTheFence(bool overTheFence);

        void setCanBeThrown(bool canBeThrown);
        
        bool isThrownByPlayer();
    }
}