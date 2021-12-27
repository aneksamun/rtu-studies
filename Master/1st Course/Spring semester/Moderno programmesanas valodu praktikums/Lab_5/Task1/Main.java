package graphics;

import java.applet.*;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.util.LinkedList;

public class Main extends Applet {

    private static final long serialVersionUID = 1L;
    private LinkedList<Point> points = new LinkedList<Point>();
    private boolean drawLine = false;
    
    public void init() {
        setBackground(Color.BLUE);
        
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
    
    public void paint(Graphics e) {
        
        Point previousPoints = null;

        for (Point point : points) {
            
            if (previousPoints != null && point != null)
                e.drawLine(point.x, point.y, previousPoints.x, previousPoints.y);
            
            previousPoints = point;
        }
    }
}
