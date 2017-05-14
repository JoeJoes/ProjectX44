#include <stdio.h>
#include <sys/io.h>

int toWrite[] = {0xff, 0xff}; //hodnoty k zápisu
int reader[] = {0xff, 0xff}; //přečtené hodnoty
int *readerPrev = reader; //momentálně nevyužité
int portNum; //počet portů

void customio(int ports) //nastaví ioperm pro daný počet portů
{
	int permOk;
	setbuf(stdout, NULL);
	printf("ioperm ");
	permOk = !(ioperm(0x300,ports,1));
	printf(permOk?"gut":"nop");
	portNum = ports;
}

void setPin(int pin, int val) //nastaví virtuální pin na hodnotu val
{
	int port = pin / 8;
	int portBit = pin % 8;
	
	toWrite[port] = val ? toWrite[port] & ~(1 << portBit) : toWrite[port] | (1 << portBit); //zapisuje invertovaně, to znamená neinvertovaná logika
}

void portWrite() //zapíše na port
{
	for(int i = 0; i < portNum; i++)
	{
		outb(toWrite[i], 0x300+i);
	}
}

int readPin(int pin) //získá hodnotu na virtuálním pinu
{
	int port = pin / 8;
	int portBit = pin % 8;
	
	return ((reader[port] & (1 << portBit)) >> portBit); //výpis jednoho "pinu" - zahodíme všechny nepotřebné bity
}

int portRead() //přečte všechny porty
{
	int stateChange = 0;
	for(int i = 0; i < portNum; i++)
	{
		readerPrev[i] = reader[i];
		reader[i] = inb(0x300+i) ^ 0xff; //přečte invertovaně
		stateChange = readerPrev[i] != reader[i];
		//printf("%d\n",reader[i]);
	}
	return stateChange; //detekce nezměněného stavu
}

void resetWrite() //resetuje toWrite na výchozí hodnotu
{
	for(int i = 0; i < portNum; i++)
	{
		toWrite[i] = 0xff;
	}
}