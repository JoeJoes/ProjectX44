#include <stdio.h>
#include <sys/io.h>
#include <unistd.h>
#include <time.h>
#include "customio.h"

void motorMove(int m, int d)
{
	setPin(0,1);
	setPin(1,!d);
	setPin(m+1,1);
	portWrite();
	setPin(0,0);
	portWrite();
	resetWrite();
	nanosleep((struct timespec[]){{0,2500000}},NULL);
}

void mainloop()
{
	customio(2);
	/*int motor = 2;
	int direction = 1;
	for(int j = 0; j < 8; j++)
	{
		for(int i = 0; i < 400; i++)
		{
			motorMove((j+2)/2, direction);
		}
		//motor++;
		direction = direction ^ 1;
	}*/
	int motors[4] = {0,0,0,0};
	
	while(1){
	portRead();
	int motorMoving = 0;
	int toMove = 0;
	int altMove = 0;
	if(readPin(12))altMove = 1;
	for(int i = 0; i < 4; i++)
	{
		if(readPin(i+8))
		{
			
			if(altMove) {
				motorMove((i/2)+3,i%2);
				motors[i/2+2]+=i%2?1:-1;
				}
			else {
				motorMove((i/2)+1,i%2);
				motors[i/2]+=i%2?1:-1;
			break;
		}
	
	}
	
	printf("%d %d %d %d\n",motors[0],motors[1],motors[2],motors[3]);
	/*
	char ch;
	scanf("%c\n",&ch);
	
	if(ch == "q\n")
	{
		printf("reset\n");
		for(int m = 0; m < 4; m++)
		{
			while(motors[m]!=0)
			{
				if(motors[m]>0)
				{
					motorMove(m+1,0);
					motors[m]-=1;
				}
				else
				{
					motorMove(m+1,1);
					motors[m]+=1;
				}
			}
		}
	}*/
	}
	/*if(readPin(8))
	{
	motorMove(1,1);
	}
	if(readPin(9))
	{
	motorMove(1,0);
	}*/
	
	}
}
int main(void)
{
	
	mainloop();
	return 0;
}