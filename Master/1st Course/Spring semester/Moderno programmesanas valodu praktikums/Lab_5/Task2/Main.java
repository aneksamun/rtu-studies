package graphics;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.util.LinkedList;

import javax.swing.JFrame;

public class Main extends JFrame {

    private static final long serialVersionUID = 1L;
    private LinkedList<Point> points = new LinkedList<Point>();
    private boolean drawLine = false;
    
    public Main() {

        this.getContentPane().setBackground(Color.blue);
        this.setSize(200, 200);
        this.setVisible(true);
        
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        this.addMouseMotionListener(new MouseMotionAdapter() {
            
            @Override
            public void mouseMoved(MouseEvent e) {
                if (drawLine)
                    points.add(e.getPoint());
                
                repaint();
            }
        });
        
        this.addMouseListener(new MouseAdapter() {
            
            @Override
            public void mouseClicked(MouseEvent e) {
                drawLine = !drawLine;
                points.add(e.getPoint());
                points.add(e.getPoint());
                
                if (!drawLine)
                    points.add(null);
                
                repaint();
            }
        });
    }
    
    public void paint(Graphics g) {
        super.paint(g);
        
        Point previousPoints = null;

        for (Point point : points) {
            
            if (previousPoints != null && point != null)
                g.drawLine(point.x, point.y, previousPoints.x, previousPoints.y);
            
            previousPoints = point;
        }
    }
    
    public static void main(String... args) {
        new Main();
    }
}
