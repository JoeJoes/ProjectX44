#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include "usart.h"

void setup(void) {
DDRB=0x00; //11111110
//printf("\n\rHello world\n\r");
usart_setup();
}

void find_start(void)
{
	int count, r;
	do {
		count = 0; //reset počtu
		
		for(int i = 0; i < 985; i++) { //přibližně minuta
			//r = PINB;
			if(~PINB & 0x01) { //počítáme, kolikrát se v minutě objeví signál 1 (ve skutečnosti 0, ovšem pro jednodušší práci je veškerý vstup invertován)
				count++;
				//usart_putchar('1'); //debug
			}
			//else usart_putchar('0');
			//printf("%r\n\r",r);
			_delay_ms(1);
		}
		if(count >= 50 && count < 120) { //debug
			usart_putchar('0');
		}
		if(count > 140 && count < 240) { //debug
			usart_putchar('1');
		}
		usart_putchar('t'); //debug
	} while(count > 50); //dokud je počet log 1 větší něž je délka signálu 0, cykli - pokud se neobjeví dostatečný počet signálů, značí to začátek vysílání - můžeme skončit
	usart_putchar('S'); //debug
}

int byte(void) {
		int count;
	//do {
		count = 0; //reset počítadla
		
		for(int i = 0; i < 985; i++) { //přibližně minuta
			//r = PINB;
			if(~PINB & 0x01) { //pokud detekujeme log 1
				count++;
				//usart_putchar('1');
			}
			//else usart_putchar('0');
			//printf("%r\n\r",r);
			_delay_ms(1);
		}
		if(count >= 50 && count < 120) { //signál 0
			//usart_putchar('0');
			return 0;
		}
		if(count > 140 && count < 240) { //signál 1
			//usart_putchar('1');
			return 1;
		}
		//usart_putchar('t');
	//} while(count > 50);
	//usart_putchar('S');

}

int main(void) {
setup();
//char read;
//int last, value, count, last_count, byte_time, byte;
int min = 0, hod = 0; //hodnoty minut a hodin
int value[59]; //pole hodnot získaných z DCF

//value = 0; //binary hodnota
//count = 0; //počet cyklů
//byte = 0; //pozice
//byte_time = 0x00; //výstup
//last = PINB; //přečte první hodnotu
 
for (int i=0;i<8;++i) { //debug??
	  usart_putchar(PINB & ( 0x80 >> i) ? '1':'0');
	  }
	find_start(); //počkej na start signál
 
while(1) { //hlavní smyčka
	//min = 0;
	//hod = 0;
	for(int b = 0; b < 60; b++) { //přečti signály
		value[b] = byte();
	}

	for(int m = 21; m < 28; m++) { //neotestováno, nejspíš nefunkční?
		min += value[m]?pow(2,(m-21)):0; //počítání minut - pokud je bit minut 1, pak přičti adekvátní mocninu čísla 2
	}
	
	printf("%min\n\r",min);
	/*if(PINB == last)
	{
		count++; //pokud stejná hodnota
	}
	else //při změně hodnoty
	{
		if(count < 90)
		{
			count = last_count;
			//value = ~value;
		}
		else if(count < 110)
		{
			count = 0;
			value = 0;
		}
		else if(count > 190)
		{
			count = 0;
			value = 1;
		}
		last_count = count;
		count = 1;
		value = ~value;
	}
	//usart_putchar('1');
	//read = PINB;
	//printf(read);
	if(PINB & 1)
	{
		usart_putchar('1');
	}
	else
	{
		usart_putchar('0');
	}*/
    _delay_ms(1);
  }
return 1;
}