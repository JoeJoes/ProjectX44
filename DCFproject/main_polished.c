#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include "usart.h"

void setup(void) {
DDRB=0x00;
usart_setup();
}

void find_start(void)
{
	int count, r;
	do {
		count = 0; //reset počtu
		
		for(int i = 0; i < 985; i++) { //přibližně minuta
			if(~PINB & 0x01) { //počítáme, kolikrát se v minutě objeví signál 1 (ve skutečnosti 0, ovšem pro jednodušší práci je veškerý vstup invertován)
				count++;
			}
			_delay_ms(1);
		}
	} while(count > 50); //dokud je počet log 1 větší něž je délka signálu 0, cykli - pokud se neobjeví dostatečný počet signálů, značí to začátek vysílání - můžeme skončit
}

int byte(void) {
		int count;
		count = 0; //reset počítadla
		for(int i = 0; i < 985; i++) { //přibližně minuta
			if(~PINB & 0x01) { //pokud detekujeme log 1
				count++;
			}
			_delay_ms(1);
		}
		if(count >= 50 && count < 120) { //signál 0
			return 0;
		}
		if(count > 140 && count < 240) { //signál 1
			return 1;
		}

}

int main(void) {
setup();
int min = 0, hod = 0; //hodnoty minut a hodin
int value[59]; //pole hodnot získaných z DCF

	find_start(); //počkej na start signál

while(1) { //hlavní smyčka
	min = 0;
	hod = 0;
	for(int b = 0; b < 60; b++) { //přečti signály
		value[b] = byte();
	}

	for(int m = 21; m < 28; m++) { //neotestováno, nejspíš nefunkční?
		min += value[m]?pow(2,(m-21)):0; //počítání minut - pokud je bit minut 1, pak přičti adekvátní mocninu čísla 2
	}
	
	//zde by měl být podobný kód pro hodiny adt.
	
	printf("%min\n\r",min); //z nějakého důvodu nevypisuje?
    _delay_ms(1);
  }
return 1;
}