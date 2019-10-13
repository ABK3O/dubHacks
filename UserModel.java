package seperate;

import java.util.*;
import com.opencsv.bean.CsvBindByName;


public class UserModel {
  @CsvBindByName
  private String ProgramName;

  @CsvBindByName
  private String Location;

  @CsvBindByName
  private String PhoneNumber;

  @CsvBindByName
  private String Website;

  @CsvBindByName
  private String MealInformation;


  /**
   * Gets the name of the hero
   *
   * @return the hero name of this UserModel
   */
  public String getProgramName() {

    return this.ProgramName;
  }

  public void setProgramName(String name) {

    this.ProgramName = name;
  }


  public String getLocation() {

    return this.Location;
  }

  public void setLocation(String name) {

    this.Location = name;

  }

  public String getPhoneNumber() {

    return this.PhoneNumber;
  }

  public void setPhoneNumber(String name) {

    this.PhoneNumber = name;

  }

  public String getWebsite() {

    return this.Website;
  }

  public void setWebsite(String name) {

    this.Website = name;

  }
  /**
   * Gets the name of the book
   *
   * @return the book name of this UserModel
   */
  public String getMealInformation() {

    return this.MealInformation;
  }


  public void setMealInformation(String mealInfo) {

    this.MealInformation = mealInfo;

  }


}
