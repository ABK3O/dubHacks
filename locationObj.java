package Location;

import java.util.ArrayList;
import java.util.List;

public class locationObj {

  private List<String> place;

  public locationObj(){
    place=new ArrayList<>();
  }

  public void add(String variable){
    if(place.size()!=5){
      place.add(variable);
    }
  }


}
