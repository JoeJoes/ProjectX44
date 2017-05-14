#include <stdio.h>
#include <sys/io.h>
#include <unistd.h>
#include <time.h> 

#include "main.h"

int setupPerm() {
  return ioperm(0x300,2,1);
}

int mainLoop() {
//struct timespec t;
//t.tv_sec = 0;
//t.tv_nsec = 20000000;
int t = 20;
	int val;
	int *display;
	display = MSG2;
	printf("taxi");
	for (;;)
	{
		val=0;
		for(int i=0;i<4;i++)
		{
			outb(1 << i ^ 0xff, 0x301);
			outb(*(display+i), 0x300);
			val = inb(0x301);
			if (val != 0xff)
			{
			if (i == 0){display = MODE;}
			if (i == 1){display = UP;}
			if (i == 2){display = DOWN;}
			if (i == 3){display = SET;}
			}
			//nanosleep (&t,NULL);
			nanosleep( (struct timespec[]) {{0,4000000}}, NULL);
		}
	}
	return 0;
}
int main()
{
	//struct timespec t;
	//t.tv_sec = 0;
	//t.tv_nsec =20000;
	//int t = 20;
	int permOk;
	setbuf(stdout,NULL);
	
	printf("Enabling io port access ...");
  permOk = !setupPerm();
  printf(permOk?"Done.\n":"Failed!.\n");
  if (!permOk)
    return(1);
// t.tv_sec = 0;
// t.tv_nsec = 20000;

	mainLoop();
return 0;
}