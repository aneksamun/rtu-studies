import java.sql.*;
import java.util.HashSet;
import java.util.Set;

class Grāmata {

    private int grāmatasID;
    private String nosaukums;
    private String izdevniecība;
    private Set<Autors> autori;

    public int getGrāmatasID() {
        return grāmatasID;
    }
    
    public String getNosaukums() {
        return nosaukums;
    }
    
    public String getIzdevniecība() {
        return izdevniecība;
    }
    
    public Set<Autors> getAutori() {
        return autori;
    }
    
    public void setGrāmatasID(int bookID) {
        this.grāmatasID = bookID;
    }
    
    public void setNosaukums(String title) {
        this.nosaukums = title;
    }
    
    public void setIzdevneicība(String publishingHouse) {
        this.izdevniecība = publishingHouse;
    }
    
    public void setAutori(Set<Autors> authors) {
        this.autori = authors;
    }
}

class Autors {

    private int autoraID;
    private String vārds;
    private String uzvārds;
    private Set<Grāmata> grāmatas;
    
    public int getAutoraID() {
        return autoraID;
    }
    
    public String getVārds() {
        return vārds;
    }
    
    public String getUzvārds() {
        return uzvārds;
    }
    
    public Set<Grāmata> getGrāmatas() {
        return grāmatas;
    }
    
    public void setAutoraID(int authorID) {
        this.autoraID = authorID;
    }
    
    public void setVārds(String firstname) {
        this.vārds = firstname;
    }
    
    public void setUzvārds(String lastname) {
        this.uzvārds = lastname;
    }
    
    public void setGrāmatas(Set<Grāmata> books) {
        this.grāmatas = books;
    }
}

public class JDBCBaseDemo {

    /**
     * @param args
     */
    public static void main(String[] args) {

        String connectionUrl = "jdbc:jtds:sqlserver://localhost:1433;databaseName=TestDB;integratedSecurity=true";
      
        Connection con = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;

        Set<Grāmata> grāmatas = new HashSet<Grāmata>();
          
        try {
            // Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            con = DriverManager.getConnection(connectionUrl);
             
            // Create and execute an SQL statement that returns some data.
            String SQL = "SELECT GrāmatasID, Nosaukums, Izdevniecība " +
                         "FROM dbo.Grāmata " +
                         "WHERE Izdevniecība = ?";
             
            stmt = con.prepareStatement(SQL);
            stmt.setString(1, "ZvaigzneABC");
            rs = stmt.executeQuery();

             // Iterate through the data in the result set and display it.
            while (rs.next()) {
                Grāmata grāmata = new Grāmata();
                grāmata.setGrāmatasID(rs.getInt(1));
                grāmata.setNosaukums(rs.getString(2));
                grāmata.setIzdevneicība(rs.getString(3));
                grāmatas.add(grāmata);
            }
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            if (rs != null) rs.close();
            if (stmt != null) stmt.close();
            if (con != null) con.close();
        }
          
        for (Grāmata g : grāmatas) {
            System.out.println(
                g.getGrāmatasID() + " " + 
                g.getNosaukums() + " " + 
                g.getIzdevniecība());
        }
    }
}
