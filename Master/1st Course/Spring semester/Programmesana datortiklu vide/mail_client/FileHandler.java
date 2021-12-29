package mailing.example;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileHandler {

    private static String filePath = ""; 
    
    /**
     * Reads response file content.
     * @return
     */
    public static String processResponse() {
        StringBuilder responseText = new StringBuilder();
        String newLine = System.getProperty("line.separator");
        Scanner scanner = null;
        
        try {
            scanner = new Scanner(new FileInputStream(filePath), "utf-8");
            
            while (scanner.hasNextLine()) {
                responseText.append(scanner.nextLine() + newLine);
            }
        } 
        catch (FileNotFoundException e) {
            return null;
        } 
        finally {
            scanner.close();
        }
        
        return responseText.toString();
    }
    
    /**
     * Checks if file exists.
     * @param path
     * @return
     */
    public static boolean isValidFilePath(String path) {
        filePath = path;
        return new File(path).exists();
    }
}
