# Simple makefile presenting basic posibilities of make usage
# 2013/09/07 Tomas Kolousek - t.kolousek@gmail.com
#   - created as supporting material for V4 lab lessons on SPS & VOS Chomutov
#   - this one using multiple targets for all gcc demos
#   - for more info see "An Introduction to Unix make utility" tutorial

# general syntax:
# target [target2...] : [dependencies] [; commands]
# [<tab> command] 

# defines some macros ("variables") which can be used later in the makefile
CFLAGS = -std=c99 -O2
DEFS = -D_POSIX_C_SOURCE=199309L

# -- target1 : build the simplest gcc demo using simple dependency demo.o
demo : demo.o
	mv demo.o demo

demo.o :
	gcc -o demo.o demo.c

main:
	$(CC) $(CFLAGS) $(DEFS) main.c -o main


all : 

clean :
# the @ character before command prevents the command self to print on stdout
	@echo Cleaning all temporary and unnecessary files ...
	rm -f *.o
	rm -f a.out
        # again better approach - use internal RM macro for file erase sommand
	${RM} ${APPFILES}
	${RM} *.c~
	@echo Done!