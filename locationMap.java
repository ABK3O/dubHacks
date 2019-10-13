package Location;

import java.util.HashSet;
import java.util.Set;

public class locationMap {
  private Set<locationObj> places;

  public locationMap(){
    places=new HashSet<locationObj>();
  }

  public void add(locationObj location){
    places.add(location);
  }
}
