'''
Created on Jun 9, 2011

@author: aneksamun
'''

import math
import sys
import random

def bernulli(p, n):
    try:
        n = int(n)
    except ValueError:
        print("Bernulli: You must write a number of the series.")
        return
        
    try:
        p = float(p)
    except ValueError:
        print("Experiment: You must write a number of the probability.")
        return
    
    print ("Bernulli: n=%d, p=%.3f" % (n, p))
    
    i = 0
    q = 1 - p
    
    for i in range (0, n + 1):
        a = math.factorial(n) / (math.factorial(n - i) * math.factorial(i))
        b = p**i * q**(n - i)
        P = a * b
        sys.stdout.write("%.3f " % P)
        
def experiment(p, n):
    try:
        n = int(n)
    except ValueError:
        print("Experiment: You must write a number of the series.")
        return
    
    try:
        p = float(p)
    except ValueError:
        print("Experiment: You must write a number of the probability.")
        return
    
    print ("Experiment: n=%d, p=%.3f" % (n, p))
    
    series = 2
    
    for _ in range(0, n + 1):
        sum = 0
        
        for _ in range (0, series):
            item = round(random.uniform(0.0, p), 3)
            sum += item
        
        sys.stdout.write("%.3f " % (sum / series))
            
            
bernulli(0.5, 3)

print("\n")

experiment(0.5, 3)
