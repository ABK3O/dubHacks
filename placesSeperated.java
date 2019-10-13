package seperate;

import Location.locationMap;
import Location.locationObj;

import java.util.Iterator;

public class placesSeperated {

  public static locationMap buildMap(Iterator<UserModel> userModelIterator){
    locationMap curMap=new locationMap();
    while(userModelIterator.hasNext()){
      UserModel currentTerm = userModelIterator.next();
      locationObj cur=new locationObj();
      cur.add(currentTerm.getProgramName());
      cur.add(currentTerm.getLocation());
      cur.add(currentTerm.getPhoneNumber());
      cur.add(currentTerm.getMealInformation());
      cur.add(currentTerm.getWebsite());
      curMap.add(cur);
    }
    return curMap;
  }
}
