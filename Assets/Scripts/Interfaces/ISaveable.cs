using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{

    void MyPosition ( SaveData saveStorage );


}

public interface ISaveablePlayer : ISaveable
{

    //OtherStuff that needs to be saved when player
    
}

public interface ISaveAbleObject : ISaveable
{

    void MyType ( SaveData saveStorage );

}
