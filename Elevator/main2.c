#include <stdio.h>
#include <sys/io.h>
#include <unistd.h>
#include <time.h>
#include "main.h"
#include "customio.h"

void setup()
{
	portRead();
	portWrite(); //set all outputs to default
	cur_floor = find_floor();
	display();
	
	//go with cabin slightly up to remove any starting problems (cabin can start below first sensor uh)
	setPin(0,1);
	portWrite();
	nanosleep((struct timespec[]){{0,500000000}},NULL);
	setPin(0,0);
	portWrite();
	
	if(cur_floor == 0){
		setPin(1, MS=1);
		setPin(0, 1);
		portWrite();
		while(!(readPin(8)||readPin(9)||readPin(10)||readPin(11))){portRead();} //just find out if cabin is in any floor
		setPin(0, 0);
		portWrite();
		cur_floor = find_floor(); //and find which floor is it (redundant?)
		display();
	}
}


void mainloop(){
while(1)
{
	portRead(); //ensure that we always read on start of new cycle
	
	if(readPin(13)||readPin(12)) 
	{
		setPin(2, 1); //matko rozsvit
		alt = 4;
	}
	else 
	{
		setPin(2, 0);
		alt = 0;
	}
	
	/*for(int i = 1; i <= floors; i++)
	{
		if(readPin(7+i)){
			cur_floor = i;
			break;
		}
	}*/
	if(!(readPin(12))) //isn't door open?
	{
		for(int i = 1; i <= floors; i++)
		{
			portRead();
			if(readPin(i-1+alt) && i!=cur_floor){
				is_moving = 1;
				setPin(1, MS = (i > cur_floor ? 0 : 1));
				setPin(0, 1);
				portWrite();
				while(!readPin(i+7)){display();}
				setPin(0, 0);
				is_moving = 0;
				display();
				portWrite();
			}
		}
	}
	
	portWrite(); //ensure that we always write something on end of cycle
}}


int main(void)
{
	customio(2);
	setup();
	mainloop();
	return 0;
}