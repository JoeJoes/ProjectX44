
#include <stdio.h>
#include <sys/io.h>

int toWrite[] = {0xff, 0xff};
int reader[] = {0xff, 0xff};
int *readerPrev = reader;
int portNum;

void customio(int ports) 
{
	int permOk;
	setbuf(stdout, NULL);
	printf("ioperm");
	permOk = !(ioperm(0x300,ports,1));
	printf(permOk?"gut":"nop");
	portNum = ports;
}

void setPin(int pin, int val)
{
	int port = pin / portNum;
	int portBit = pin % 8;
	
	toWrite[port] = val ? toWrite[port] & ~(1 << portBit) : toWrite[port] | (1 << portBit);
}

void portWrite()
{
	for(int i = 0; i < portNum; i++)
	{
		outb(toWrite[i], 0x300+i);
	}
}

int readPin(int pin)
{
	int port = pin / portNum;
	int portBit = pin % 8;
	
	return ((reader[port] & 1 << portBit) >> portBit); //výpis jednoho "pinu" - zahodíme všechny nepotřebné bity
}

int portRead()
{
	int stateChange = 0;
	for(int i = 0; i < portNum; i++)
	{
		readerPrev[i] = reader[i];
		reader[i] = inb(0x300+i);
		stateChange = readerPrev[i] != reader[i];
	}
	return stateChange; //detekce nezměněného stavu
}