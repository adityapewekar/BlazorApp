using System.Collections.Generic;
using System.Collections;
public class StateService{
    public IEnumerable<State> GetListOfState(){
        var list= new List<State>();
        list.Add(new State(){ StateId=1, StateName="Maharashtra"});
        list.Add(new State(){ StateId=2, StateName="Assam"});
        return list;
    }
}