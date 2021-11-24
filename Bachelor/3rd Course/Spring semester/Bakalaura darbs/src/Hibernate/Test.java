import java.util.Iterator;
import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.Query;
import org.hibernate.criterion.Restrictions;

import com.example.hibernate.Autors;
import com.example.hibernate.Grāmata;
import com.example.hibernate.util.HibernateUtil;;

public class Test {

    /**
     * @param args
     */
    @SuppressWarnings("unchecked")
    public static void main(String[] args) {
        // TODO Auto-generated method stub	

        Session session = HibernateUtil.getSessionFactory().openSession();
        
        Grāmata grāmata = (Grāmata)session.load(Grāmata.class, 1);
        Autors autors = (Autors)session.load(Autors.class, 2);
        
        grāmata.getAutori().add(autors);
        
        session.beginTransaction();
        session.saveOrUpdate(grāmata);
        session.getTransaction().commit();
        
        Query q = session.createQuery("from Grāmata");
        
        List<Grāmata> grāmatas = q.list();
        
        for (Grāmata g : grāmatas)
            System.out.println(g.getNosaukums());
        
        System.out.println();
        
        Iterator<?> bookWithAuthors = session.createQuery(
                "select grāmatas.nosaukums, autori.vārds, autori.uzvārds " + 
                "from Grāmata grāmatas " + 
                "join grāmatas.autori autori")
                .list()
                .iterator();
        
        while(bookWithAuthors.hasNext()) {
            Object[] tuple = (Object[]) bookWithAuthors.next();
            String book = (String) tuple[0];
            String author = ((String) tuple[1] + " " + (String)tuple[2]);
            
            System.out.println(book + " -> " + author);
        }
        
        System.out.println();
        
        Criteria criteria = session.createCriteria(Grāmata.class)
                .createCriteria("autori")
                .add(Restrictions.eq("uzvārds", "Sovickis"));
        
        List<Grāmata> results = criteria.list();
        
        for (Grāmata g : results)
            System.out.println(g.getNosaukums());
        
        session.close();
    }
}
