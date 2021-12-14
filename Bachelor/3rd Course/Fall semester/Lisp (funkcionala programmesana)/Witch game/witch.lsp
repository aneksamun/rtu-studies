#| Making cards deck |# 

(defun mast (rnum)
  (cond ((equal rnum 0) 's)
        ((equal rnum 1) 'h)
        ((equal rnum 2) 'd)
        ((equal rnum 3) 'c)))

(defun rank (rnum) 
  (cond ((equal rnum 0) '6)
        ((equal rnum 1) '7)
        ((equal rnum 2) '8)
        ((equal rnum 3) '9)
        ((equal rnum 4) '10)
        ((equal rnum 5) 'j)
        ((equal rnum 6) 'q)
        ((equal rnum 7) 'k)
        ((equal rnum 8) 'a)))

(defun card() (cons (rank (random 9)) (list(mast(random 4)))))

(defun shuffle (l i)
  (cond ((equal i 0) l)
        (t (shuffle (cons (check (card) l)  l) (- i 1)))))

(defun check(c l)
  (cond 
    ((is-dublicate c l) (check (card) l))
    (t c)))

(defun is-dublicate(c l)
  (cond ((null (cdr l)) (cond ((or (equal c (car l)) (equal c (list 'q 'c))) t) (t nil)))
        ((or (equal c (car l)) (equal c (list 'q 'c))) t)
        (t (is-dublicate c (cdr l)))))

#| Serving cards for players |# 

(defun variety(num)
  (cond ((null num) 0)
        (t (+ 1 (variety (cdr num))))))

(defun serve (deck i n)
  (cond ((equal i 1) (list (mix deck (- n 1))))
        (t (append (list(mix deck n)) (serve (one-out deck n) (- i 1) n)))))

(defun mix (deck q)
  (cond ((equal q 1) (list (car deck)))
        (t (cons (car deck) (mix (cdr deck) (- q 1))))))

(defun one-out (deck q)
  (cond ((equal q 0) deck)
        (t (one-out (cdr deck) (- q 1)))))

#| Playing game |# 

(defun ragana (a b &optional c d) (prog (p)
    (cond
        ((and (null c) (not(null d))) (setq p (list a b d)))
        ((and (not(null c)) (null d)) (setq p (list a b c)))
        ((and (not(null c)) (not(null d))) (setq p (list a b c d)))
        (t (setq p (list a b))))
    (return (play p (serve (shuffle (list (card)) 34) (variety p) (/ 36 (variety p)))))
))

(defun play (players cards) 
  (prog (i)
    (format t "~a~%" "--------------------------------------------------------------------------")
    (format t "~a~%" "                           spele ragana                                   ")
    (format t "~a~%" "--------------------------------------------------------------------------")
    (setq i (variety players))
    (println players cards i)
    (format t "~a~%" "--------------------------------------------------------------------------")
    (format t "~a~%" "                         * paru izsviesana *                              ")
    (format t "~a~%" "--------------------------------------------------------------------------")
    (format t "visiem speletajiem tika automatiski izsviestas dubletas kartis!~%")
    (format t "~a~%" " ")
    (println players (cutcards cards ()) i)    
    (format t "~a~%" "--------------------------------------------------------------------------")
    (format t "~a~%" "                          * speles gaita *                                ")
    (format t "~a~%" "--------------------------------------------------------------------------")
    (return (game (cutcards cards ()) players))))

(defun println(players cards i)
  (cond ((equal i 0) nil)
        (t (format t "~a" "speletaja ") 
           (format t "~a" (car players)) 
           (format t "~a~%" " kartis pec izdales:")
           (format t "~a~%" " ")
           (format t "~a~%" (car cards))
           (format t "~a~%" " ") 
           (println (cdr players) (cdr cards) (- i 1)))))

(defun cut-cards(l l1)
  (cond ((null l) l1)
        (t (cut-cards (cdr l) (append l1 (list (del-dup(car l))))))))

(defun game (l p) (test1 l (count-players p 0) '1 '2 nil p))

(defun count-players (p n)
  (cond ((null p) n)
        (t (count-players (cdr p) (+ n 1)))))

(defun get-player (p n)
  (cond ((equal n 1) (car p))
        (t (get-player (cdr p) (- n 1)))))

(defun get-pc(p l)
  (cond ((not(equal p 1)) (get-pc(- p 1) (cdr l)))
        (t (car l))))

(defun overwrite-pc(p l l1 pl)
  (cond ((not (equal p 1))
        (overwrite-pc (- p 1) (cdr l) (append l1 (list (car l))) pl))
        (t (append l1  pl (cdr l)))))

(defun count-player-cards(l n)
  (cond ((null l) 0)
        ((null (cdr l)) (+ n 1)  )
        (t (count-player-cards (cdr l) (+ n 1)))))

(defun steal-card(l n)
  (cond ((equal n 1) (car l))
        (t (steal-card (cdr l) (- n 1)))))

(defun remove-card(l l1 n)
  (cond ((null l) l1)
        ((equal n 1) (remove-card (cdr l) l1  (- n 1)))
        (t (remove-card (cdr l) (append l1 (list (car l))) (- n 1)))))

(defun search-duplicate(l l1 c dama)
  (cond
    ((null l)(append (list `(q s) nil ) (list (append (list c)  l1 ))))
    ((and (not (or (equal (car l) dama) (equal c dama)))(equal (car(car l)) (car c))) (append (list c (car l)) (list(append l1 (cdr l)))))
    (t (search-duplicate (cdr l) (append l1 (list (car l))) c dama))))

(defun find1 (l c)
  (cond ((null l) nil) 
        ((equal c (car l)) (car l))
        (t (find1 (cdr l) c))))

(defun find2 (l c)
  (cond ((null l) nil) 
        ((and (not (or (equal (car l) '(q s)) (equal c '(q s))))(equal (car c) (car (car l)))) (car l))
        (t (find2 (cdr l) c))))

(defun del-dup (l) (del-thrown l (throw-start-duppl l ())()))

(defun del-thrown (l l1 l2)
  (cond ((null l) l2)
        ((null (find1 l1 (car l))) (del-thrown (cdr l) l1  (append l2 (list (car l)))))
        (t (del-thrown (cdr l) l1 l2))))

(defun throw-start-duppl  (l l1)
  (cond ((null l) l1)
        ((null (find2 (cdr l) (car l)) ) (throw-start-duppl (cdr l) l1 ))
        (t (cond ((and (null (find1 l1 (find2 (cdr l) (car l)) )) (null (find1 l1 (car l))))
                 (throw-start-duppl (cdr l) (append (list (car l)) (append (list (find2 (cdr l) (car l))) l1))))
                 (t (throw-start-duppl  (cdr l) l1))))))

(defun who-loses (l p)
  (cond ((not (null (car l))) p)
        (t (who-loses (cdr l) (+ p 1)))))

(defun test1 (l p p1 p2 pr names)
  (cond ((<= (check-end l 0) 1) 
          (format t "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||~%")
          (format t "||||||spele beigta! zaudejis ir speletajs       ~15a! |||||||~%"  (get-player names (who-loses l 1)))
          (format t "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||~%")) 
        ((equal 0 (count-player-cards (get-pc p1 l) 0)  ) (test1 l p (convert-num p (+ p1 1)) (convert-num p (+ p2 1)) pr names))
        ((or (equal p1 p2) (equal 0 (count-player-cards (get-pc p2 l) 0)) ) (test1 l p p1 (convert-num p (+ p2 1)) pr names))
        (t (cond ((and (not (null pr )) (not (equal 0 (count-player-cards (get-pc pr l) 0)))) (format t "jusu kartis ir ~a !~%" (get-pc pr l))))
           (cond ((or (not (equal 0 (count-player-cards (get-pc p1 l) 0)) ) (not (equal 0 (count-player-cards (get-pc p1 l) 0)))) (format t "~%") (format t "spele player ~a! -~a~%" p1 (get-player names p1))))
           (cond ((or (not (equal 0 (count-player-cards (get-pc p1 l) 0)) ) (not (equal 0 (count-player-cards (get-pc p1 l) 0)))) (format t "jusu kartis ir ~a !~%" (get-pc p1 l))))
           (test1 (get-card l p1 p2 '(q s) names) p  (convert-num p (+ p1 1)) (convert-num p (+ p2 1)) p1 names))))

(defun check-end(l n)
  (cond ((null l) n)
        ((equal 0 (count-player-cards (get-pc 1 l) 0)) (check-end (cdr l) n))
        (t (check-end (cdr l) (+ n 1)))))

(defun convert-num(p p1)
  (cond 
    ((> p1 p ) 1) 
    (t p1)))

(defun test-play (l names)
  (cond ((null l) nil)
        (t (test-play (get-card l 1 2 '(q s) names) names))))

(defun read1(n) (prog(temp)
  (setq temp (read))
  (cond 
    ((not (numberp temp)) (format t "~%ievadiet pareizo skaitli!~%")
    (return (read1 n)))
    ((or (> temp n)(< temp 1) )
    (format t "~%ievadiet pareizo skaitli!~%")
    (return (read1 n)))
    (t (return temp)))))

#| get-cards -> human takes the cards (PC allowed to do it, too, optional) |#

(defun get-card (l p1 p2 dama names) (prog (pl1 pl2 temprandom tempcard result newl)
  (setq pl1 (get-pc p1 l))
  (setq pl2 (get-pc p2 l))
  (format t "speletajs ~a ludzu izvelieties speletaja ~a karti (1-~a) : " (get-player names p1) (get-player names p2) (count-player-cards pl2 0))
  (setq temprandom (read1 (count-player-cards pl2 0)))
  ;(setq temprandom (+(random (count-player-cards pl2 0) ) 1))(format t "~a~%" temprandom)
  (setq tempcard (steal-card  pl2 temprandom))
  (setq pl2 (remove-card pl2 () temprandom))
  (setq result (search-duplicate pl1 () tempcard dama))
  (setq newl (overwrite-pc p1 l () (cdr(cdr result))))
  (setq newl (overwrite-pc p2 newl () (list pl2)))
  (setq pl1 (car(cdr(cdr result))))
  (format t  "speletajs ~a panema ~a`s karti ~a kas bija ~a " (get-player names p1) (get-player names p2) temprandom tempcard)
  (cond
    ((not(null (car(cdr result)))) (format t " un izvairijas no tas kopa ar savu ~a !" (car (cdr result))))
    (cond ((equal (count-player-cards pl2 0) 0)
      (format t "~%---------------------------------------------------------------------------~%")
      (format t "speletajam ~a vairs nepalika karsu, vins ir izgajis no speles !!!~%" (get-player names p2))
      (format t "---------------------------------------------------------------------------")))
    (cond ((equal (count-player-cards pl1 0) 0)
      (format t "~%---------------------------------------------------------------------------~%")
      (format t "speletajam ~a vairs nepalika karsu, vins ir izgajis no speles !!!~%" (get-player names p1))
      (format t "---------------------------------------------------------------------------")))
    (format t " ~%")
    (return newl)))
