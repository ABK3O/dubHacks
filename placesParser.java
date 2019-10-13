
package seperate;

import com.opencsv.bean.CsvToBeanBuilder;

import java.io.IOException;
import java.io.Reader;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Iterator;

/**
 * Parser utility to load the Marvel Comics dataset.
 * <p>
 * Not an ADT
 */
public class placesParser {

  /**
   * Reads the Marvel Universe dataset. Each line of the input file contains a character name and a
   * comic book the character appeared in, separated by a tab character
   *
   * @param filename the file that will be read
   * @return Iterator containing UserModel classes created from given file
   * @spec.requires filename is a valid file path
   */
  public static Iterator<UserModel> parseData(String filename) {

    try {
      Reader reader = Files.newBufferedReader(Paths.get(filename));
      return
        new CsvToBeanBuilder<UserModel>(reader).withType(UserModel.class)
          .withSeparator(',')
          .withIgnoreLeadingWhiteSpace(true)
          .build().iterator();
    } catch (IOException e) {
      e.printStackTrace();
    }
    return null;
  }


}
