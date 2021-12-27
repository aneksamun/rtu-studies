package lab3.applet;

import java.applet.Applet;
import java.awt.*;
import lab3.concepts.*;

public class SimpleApplet extends Applet {
    
    private Object[] streets = {
        new Human(),
        new Auto(),
        new Vehicle(),
        new Bus(),
        new Bus(),
        new Human(),
        new Human(),
        new String()
    };
    
    private static final long serialVersionUID = 1L;
    private Label lblText = new Label();
    
    public void init() {
        this.setSize(650, 50);
        lblText.setText(Main.check3(streets));
        add(lblText);
    }
}
