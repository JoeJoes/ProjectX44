#include <stdio.h>
#include <sys/io.h>
#include <unistd.h>
#include <time.h>
#include "customio.h"

void motorMove(int m, int d) //posune motor m o jeden krok ve směru d
{
	setPin(0,1);   //aktivuj pin 0 (takt)
	setPin(1,!d);  //nastav směr
	setPin(m+1,1); //zapni motor m
	portWrite();   //zapiš na port
	setPin(0,0);   //deaktivuj takt
	portWrite();   //zapiš na port
	resetWrite();  //reset
	nanosleep((struct timespec[]){{0,2500000}},NULL); //2,5ms sleep
}

void mainloop()
{
	customio(2); //setup
	int motors[4] = {0,0,0,0}; //souřadnicový systém
	int altMove; //hodnota "alt" klávesy
	
	while(1){
	portRead(); //přečti porty
	altMove = 0 //resetuj alt
	if(readPin(12))altMove = 1; //pokud stisknut alt nastav hodnotu 1 (true)
	for(int i = 0; i < 4; i++) //pro 4 zbývající tlačítka
	{
		if(readPin(i+8)) //pokud stisknuto
		{
			
			if(altMove) { //pokud stisknut alt
				motorMove((i/2)+3,i%2); //alternativní pohyb -> horní dva motory (rameno chapadla a chapadlo)
				motors[i/2+2]+=i%2?1:-1; // inkrementace souřadnicového systému
				}
			else {
				motorMove((i/2)+1,i%2); //normální pohyb -> dolní dva motory (základna & rameno)
				motors[i/2]+=i%2?1:-1; //inkrementace souřadnicového systému
			break; //stisknuto tlačítko, nehledej další
		}
	
	}
	
	printf("%d %d %d %d\n",motors[0],motors[1],motors[2],motors[3]); //výpis hodnot souřadnicového systému
	}
	}
}
int main(void) //spustí hlavní smyčku programu
{
	
	mainloop();
	return 0;
}