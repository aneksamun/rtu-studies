import java.sql.Connection;
import oracle.jdbc.OracleTypes;
import oracle.sql.CLOB;
import java.sql.*;
import java.sql.DriverManager;
import java.sql.SQLException;
import oracle.jdbc.driver.OracleConnection;
import oracle.spatial.geometry.DataException;
import java.io.OutputStream;
import java.io.ByteArrayOutputStream;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.io.IOException;
import oracle.jdbc.driver.OracleDriver;
import oracle.sql.STRUCT;
import oracle.spatial.util.*;
import oracle.spatial.geometry.*;



public class talk_GML
{
  public talk_GML()
  {
  }

  protected static Connection  m_conn;


  /**
   *
   * @param args
   */

  public static void main(String[] args) throws SQLException, IOException
  {

      Statement stmt = null;
      ResultSet rslt = null;
      STRUCT geom = null;

    Connection conn = null;
    try {
     DriverManager.registerDriver(new OracleDriver()) ;
     m_conn =  DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:orcl", "scott", "tiger"); }

    catch(SQLException e) { e.printStackTrace();}


      stmt = m_conn.createStatement();
      rslt = stmt.executeQuery("select geom  " +
                               "from geod_counties " +
                               "where sdo_filter (geom, sdo_geometry(2003,8307,null," +
                                                          "sdo_elem_info_array(1,1003,3)," +
                                                          "sdo_ordinate_array (-75,40,-74,41))) = 'TRUE'");

      String theGMLString = null;
      GML2 gmltest = new GML2();
      gmltest.setConnection((OracleConnection)m_conn);

      while (rslt.next()) {
        geom = (STRUCT) rslt.getObject(1);
        theGMLString = gmltest.to_GMLGeometry(geom);
        System.out.println(theGMLString);
      }

      stmt.close();
      rslt.close();
      m_conn.close();
  }
}
