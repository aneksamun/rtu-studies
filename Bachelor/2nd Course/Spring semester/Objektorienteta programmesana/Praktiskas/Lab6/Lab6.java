class CoordPoint {
   private int x, y;

   public CoordPoint() {
      x = 0;
      y = 0;
   }
   public CoordPoint(int x, int y)	{
      this.x = X;
      this.y = Y;
   }

   public int getX() {
      return x;
   }
   public int getY() {
      return y;
   }

   public void setX(int x) {
      this.x = x;
   }
   public void setY(int y) {
      this.y = y;
   }

   public String toString() {
      return "X:" + x + ", Y:" + y + ".";
   }
}

public class Lab6 {
   public static void main(String[] args) {
      CoordPoint cp1 = new CoordPoint(1, 2), 
                 cp2 = new CoordPoint();

      System.out.println(cp1.toString());
      System.out.println(cp1);
      System.out.println(cp2);

      cp2.setX(3);
      cp2.setY(4);

      System.out.println(cp2);
      System.out.println("\nPress \"Enter\" to finish program... ");

      try {
         System.in.read();
      }
      catch(java.io.IOException e) {
         System.out.println("Input/output exception.");
      }
   }
}
