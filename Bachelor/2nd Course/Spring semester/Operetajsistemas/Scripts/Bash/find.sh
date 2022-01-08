# !/bin/bash
clear
echo "***********************************"
echo "*** Ierakstu meklesana katologa ***"
echo "***********************************"
echo
echo Izvelieties pec kura kriterija meklet ierakstus:
echo
echo [1] Pec nosaukuma
echo [2] Pec lappuses daudzuma
echo
read NUMBER
LOOP = 1
while [ "$LOOP" != 0 ]
do
    #Parbaudam vai izvele tika veikta
    if [ -z "$NUMBER" ]; then
        echo "Izvele netika veikta"
        echo "Ievadiet atkartoti:"
        read NUMBER
    else
        #Parbaudam vai ievadits skaitlis
        expr $NUMBER + 10 > /dev/null 2>&1
        if [ $? != 0 ]; then
            echo "Izvelei jabut pozitivam skaitlim!"
            echo "Ievadiet atkartoti: "
            read NUMBER
        else
            #Parbaudam vai izvele veikta korekti
            if [ "$NUMBER" -ne "1" -a "$NUMBER" -ne "2" ]; then
                echo "Izvele $NUMBER nav 1 vai 2!"
                echo "Ievadiet atkartoti:"
                read NUMBER
            else
                #Izvele veikta korekti
                LOOP=0
            fi
        fi
    fi
done

# *** Meklejam gramatas nosaukumu ***
if [ "$NUMBER" = 1 ]; then
    echo "Ievadiet gramatas nosaukumu:"
    read BOOK
    #Parbaudam vai gramatas nosaukums ir ievadits
    if [ -z "$BOOK" ]; then
        while [ -z "$BOOK" ]
        do
            echo "Gramatas nosaukums netika ievadits!"
            echo "Ievadiet atkartoti:"
            read BOOK
        done
    fi
    grep "$BOOK" ./library.txt | most
fi

# *** Meklejam pec lpp daudzuma ***
if [ "$NUMBER" = 2 ]; then
    echo "Ievadiet lpp. daudzumu:"
    read QUANTITY
    LOOP = 1
    while [ "$LOOP" != 0 ]
    do
        #Parbaude vai tika noradits lpp. daudzums
        if [ -z "$QUANTITY" ]; then
            echo "Nav ievadits lpp. daudz."
            echo "Ievadiet atkartoti: "
            read QUANTITY
        else
        #Parbaude vai ievadita skaitliska vertiba
            expr $QUANTITY + 10 > /dev/null 2>&1
            if [ $? != 0 ]; then
                echo "Daudzumam janorada pozitivi skaitli!"
                echo "Ievadiet atkartoti: "
                read QUANTITY
            else
                #Parbaude vai lpp. daudzums ievadits korekti
                if [ "$QUANTITY" -gt "1000" ]; then
                    echo "Lpp daudzums $QUANTITY ir neatbilstoss!"
                    echo "Lappusem ir jabut nevairak ka 1000!"
                    echo "Ievadiet atkartoti:"
                    read QUANTITY
                else
                    #Ievaditais lpp. daudzums ir korekts
                    LOOP=0
                fi
            fi
        fi
    done
    grep "$QUANTITY" ./library.txt | most 
fi

exit 0
