(defun sort-num(l) 
  (cond 
    ((null l) nil)
    ((null (cdr l)) (car l)) 
    (t (append (negative l) (positive l)))))

(defun negative(l)
  (cond
    ((null l) l)
    ((not (numberp (car l))) (negative (cdr l)))
    ((> 0 (car l)) (cons (car l) (negative (cdr l))))
    (t (negative (cdr l)))))

(defun positive(l) 
  (cond
    ((null l) l)
    ((not (numberp (car l))) (positive (cdr l)))
    ((>= (car l) 0 ) (cons (car l) (positive (cdr l))))
    (t (positive (cdr l)))))
