# !/bin/bash
clear
echo "***************************************"
echo "*** Bibliotekas kataloga uzturesana ***"
echo "***************************************"
# *** Gramatas nosaukuma ievade ***
echo
echo Ievadiet, ludzu, gramatas nosaukumu:
read NAME
#Parbaude vai tika noradits gramatas nosaukums
if [ -z "$NAME" ]; then
     #Pieprasijums lietotajam par atkartotas vertibas ievades
     while [ -z "$NAME" ]
     do
         echo "Nav ievadits gramatas nosaukums!"
         echo "Ievadiet atkartoti: "
         read NAME
     done
fi

# *** Gramatas autora ievade ***
echo
echo Ievadiet, ludzu, gramatas autoru:
read AUTHOR 
#Parbaude vai tika noradits autors
if [ -z "$AUTHOR" ]; then
    while [ -z "$AUTHOR" ]
    do
        echo "Nav ievadits gramatas autors!"
        echo "Ievadiet atkartoti: "
        read AUTHOR
    done
fi

# *** Izdevniecibas ievade ***
echo
echo Ievadiet, ludzu, izdevniecibu:
read PRESS
#Parbaude vai tika noradita izdevnieciba
if [ -z "$PRESS" ]; then
    while [ -z "$PRESS" ]
    do
        echo "Nav ievadita izdevnieciba!"
        echo "Ievadiet atkartoti: "
        read PRESS
    done
fi

# *** Gramatas izdosanas gada ievade ***
echo
echo Ievadiet, ludzu, gadu:
read YEAR
LOOP = 1
while [ "$LOOP" != 0 ] 
do
    #Parbaude vai tika noradits gads 
    if [ -z "$YEAR" ]; then
        echo "Nav ievadits gads!"
        echo "Ievadiet atkartoti: "
        read YEAR
    else
    #Parbaude vai ievadita skaitliska vertiba
        expr $YEAR + 10 > /dev/null 2>&1
        if [ $? != 0 ]; then
            echo "Gadam jaievada pozitivi skaitli!"
            echo "Ievadiet atkartoti: "
            read YEAR
        else
            #Parbaude vai gads ir noradits atbilstosi
            #LEN=${#YEAR}
            if [ "$YEAR" -gt `date +%Y` -o "$YEAR" -lt "1000" ]; then
                echo "Gads $YEAR ir neatbistoss!"
                echo "Tas nevar but lielaks par `date +%Y` un mazaks par 1000!"
                echo "Ievadiet atkartoti: "
                read YEAR
            else
                #Gads ievadits korekti
                LOOP=0
            fi
        fi
    fi
done

# *** Lpp. daudzuma ievade ***
echo
echo Ievadiet, ludzu, lpp. daudz.:
read PAGES
LOOP = 1
while [ "$LOOP" != 0 ]
do
    #Parbaude vai tika noradits lpp. daudzums
    if [ -z "$PAGES" ]; then
        echo "Nav ievadits lpp. daudz."
        echo "Ievadiet atkartoti: "
        read PAGES
    else
        #Parbaude vai ievadita skaitliska vertiba
        expr $PAGES + 10 > /dev/null 2>&1
        if [ $? != 0 ]; then
            echo "Daudzumam janorada pozitivi skaitli!"
            echo "Ievadiet atkartoti: "
            read PAGES
        else
            #Parbaude vai lpp. daudzums ievadits korekti
            if [ "$PAGES" -gt "1000" ]; then
                echo "Lpp daudzums $PAGES ir neatbilstoss!"
                echo "Lappusem ir jabut nevairak ka 1000!"
                echo "Ievadiet atkartoti:"
                read PAGES
            else
                #Ievaditais lpp. daudzums ir korekts
                LOOP=0
            fi
        fi
    fi
done 

# Mainigo vertibu ierakstisana faila
echo "$NAME $AUTHOR $PRESS $YEAR $PAGES" >> ./library.txt
# Faila satura izvade
echo 
echo bibliotekas katologa saturs:
cat ./library.txt | most
echo 

exit 0
