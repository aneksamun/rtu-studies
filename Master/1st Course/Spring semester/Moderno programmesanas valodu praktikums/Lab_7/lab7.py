'''
Created on Jun 8, 2011

@author: aneksamun
'''

import re

def addfirst():
    city = raw_input("Title of the city: ")
    
    exp = re.compile('\d+(\.\d+)?') 
    area = raw_input("Total area: ")
    
    while exp.match(area) == None:
        print("You need to write number!")
        area = raw_input("Total area: ")
        
    area = float(area)
        
    population = raw_input("Total population: ")
    
    while not population.isdigit():
        print("You need to write number!")
        population = raw_input("Total population: ")
        
    population = int(population)
    
    cities[0:0] = [[city, area, population]]


def addlast():
    city = raw_input("Title of the city: ")
    
    exp = re.compile('\d+(\.\d+)?') 
    area = raw_input("Total area: ")
    
    while exp.match(area) == None:
        print("You need to write number!")
        area = raw_input("Total area: ")
        
    area = float(area)
        
    population = raw_input("Total population: ")
    
    while not population.isdigit():
        print("You need to write number!")
        population = raw_input("Total population: ")
        
    population = int(population)
    
    cities[len(cities):len(cities)] = [[city, area, population]]


def removefirst():
    try:
        del cities[0]
    except IndexError:
        print("List is empty!")


def removelast():
    if len(cities) == 0:
        print("List is empty!")
        return
    
    del cities[-1]
    
    
def orderasc():
    print("Sort by:")
    print("0 - Title.")
    print("1 - Area.")
    print("2 - Population.\n")

    value = raw_input("Choice: ")
    
    if not value.isdigit():
        print("Unexpected value.")
        return
    
    value = int(value)
    
    if value > 2 or value < 0:
        print("Sorting is canceled.")
        return
    
    cities.sort(key = lambda city: city[value])
    
def orderdesc():
    print("Sort descending by:")
    print("0 - Title.")
    print("1 - Area.")
    print("2 - Population.\n")

    value = raw_input("Choice: ")
    
    if not value.isdigit():
        print("Unexpected value.")
        return
    
    value = int(value)
    
    if value > 2 or value < 0:
        print("Sorting is canceled.")
        return
    
    cities.sort(key = lambda city: city[value], reverse = True)
    
def bye():
    print("See you...")

cities = [["Riga", 370.17, 740000],
          ["Daugavpils", 73.50, 110000],
          ["Liepaja", 60.40, 86000]]

options = { 1 : addfirst,
            2 : addlast,
            3 : removefirst,
            4 : removelast,
            5 : orderasc,
            6 : orderdesc,
            7 : bye }

choice = 0

while choice != 7:
    print("%-4s %-12s %-8s %-11s" % ("No.", "City", "Area", "Population"))
    
    i = 0
    
    for city in cities:
        i = i + 1
        print("%-4d %-12s %-8.2f %-3d" % (i, city[0], city[1], city[2]))
        
    print("*************************************\n")
    
    print("1 - Add city as FIRST record.")
    print("2 - Add city as LAST record.")
    print("3 - Remove FIRST record.")
    print("4 - Remove LAST record.")
    print("5 - Order by population (ASCENDING).")
    print("6 - Order by population (DESCENDING).")
    print("7 - Exit.\n")
    
    choice = raw_input("Choice: ")
    print("")
    
    if not choice.isdigit():
        continue
    
    choice = int(choice)
    
    if 0 < choice < 8:
        options[choice]()
        print("")
        
        
