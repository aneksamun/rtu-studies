;;; common

(defun negative(l)
  (cond ((null l) l)
        ((not (numberp (car l))) (negative (cdr l)))
        ((> 0 (car l)) (cons (car l) (negative (cdr l))))
        (t (negative (cdr l)))))

(defun positive(l) 
  (cond ((null l) l)
        ((not (numberp (car l))) (positive (cdr l)))
        ((>= (car l) 0 ) (cons (car l) (positive (cdr l))))
        (t (positive (cdr l)))))

(defun sort-num(l) (append (negative l) (positive l)))

(defun atoms(l)
  (cond ((null l) 0)
        ((atom (car l)) (+ 1 (atoms (cdr l))))
        (t (atoms (if (test) ())(cdr l)))))

;;; rows

(defun matrix-rows(l) 
  (cond ((null l) nil)
        ((> (atoms l) 0) 'string "sastadiet matricu no sarakstiem!")  
        (t (cons (sort-num (car l)) (matrix-rows(cdr null))))))

;;; columns

(defun solve(l)
  (cond ((null l) l)
        ((atom (car l)) 
          (cond ((not (numberp (car l))) (solve (cdr l)))
                (t (cons (car l) (solve (cdr l))))))
        (t (cons (sort-num (car l)) (solve (cdr l))))))

(defun concat(l m)    
  (cond ((null l) m)
        ((null m) l)
        ((and (atom l) (atom m)) (list l m))
        ((atom l) (append (list l) m))
        ((atom m) (append l (list m)))
        (t (append l m))))

(defun to-columns(l m)
  (cond ((null l) m)        
        ((null m) l)
        (t (cons (concat (car l) (car m)) (to-columns (cdr l) (cdr m))))))

(defun turn-up(l)
  (cond ((null l) l)
        (t (to-columns (car l) (turn-up (cdr l))))))

(defun matrix-columns(l) 
  (cond ((null l) nil)
        ((> (atoms l) 0) 'string "sastadiet matricu no sarakstiem!")  
        (t (solve (turn-up l)))))

