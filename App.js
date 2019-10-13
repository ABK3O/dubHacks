import React, {Component} from 'react';
class App extends Component{

  constructor(props){
    super(props)
    this.state={
      places:"",
      start:"",
      locations:parseData(MarvelParser.parseData(fileName))
    }
  }

  findPlaces=(place)=>{
    this.setState({start:place})
    for(String place:)
  }
  sendRequestforBuildings = async (dest) => {
    try {
      let response = await get("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Seattle&destinations="+ dest+ "key=AIzaSyD9Hk2b2gANk_MKJWJbUK13bbiWMgO9Yoo")
      if (!response.ok) {
        alert("ERROR@");
        return;
      }
      let parsed = await response.json()
      this.setState({
        buildings: parsed
      })
    } catch (e) {
      alert("ERROR EXCEPTION" + e);
    }
  }



}
